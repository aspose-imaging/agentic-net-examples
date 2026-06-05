using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.bmp";
        string outputPath = "output.svg";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for pixel manipulation
                RasterImage raster = image as RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("Loaded image is not a raster image.");
                    return;
                }

                // Invert colors pixel by pixel
                for (int y = 0; y < raster.Height; y++)
                {
                    for (int x = 0; x < raster.Width; x++)
                    {
                        // Get current pixel color
                        Color original = raster.GetPixel(x, y);
                        // Invert RGB channels, preserve alpha
                        Color inverted = Color.FromArgb(
                            original.A,
                            255 - original.R,
                            255 - original.G,
                            255 - original.B);
                        raster.SetPixel(x, y, inverted);
                    }
                }

                // Save as SVG
                var svgOptions = new SvgOptions();
                raster.Save(outputPath, svgOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}