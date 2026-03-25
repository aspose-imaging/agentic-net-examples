using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.bmp";
        string outputPath = "output.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the BMP image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage for pixel access
            RasterImage raster = (RasterImage)image;

            // Apply a custom color filter
            // Example: replace pure red (255,0,0) with blue (0,0,255) and increase brightness of other pixels
            for (int y = 0; y < raster.Height; y++)
            {
                for (int x = 0; x < raster.Width; x++)
                {
                    Color pixel = raster.GetPixel(x, y);

                    if (pixel.R == 255 && pixel.G == 0 && pixel.B == 0)
                    {
                        // Change pure red to blue
                        raster.SetPixel(x, y, Color.FromArgb(pixel.A, 0, 0, 255));
                    }
                    else
                    {
                        // Increase brightness by 20 (clamped to 255)
                        int r = Math.Min(pixel.R + 20, 255);
                        int g = Math.Min(pixel.G + 20, 255);
                        int b = Math.Min(pixel.B + 20, 255);
                        raster.SetPixel(x, y, Color.FromArgb(pixel.A, r, g, b));
                    }
                }
            }

            // Save the filtered image as SVG
            SvgOptions svgOptions = new SvgOptions();
            image.Save(outputPath, svgOptions);
        }
    }
}