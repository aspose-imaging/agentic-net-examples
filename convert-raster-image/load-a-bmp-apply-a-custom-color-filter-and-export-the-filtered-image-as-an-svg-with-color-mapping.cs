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
        string inputPath = @"C:\Images\input.bmp";
        string outputPath = @"C:\Images\output.svg";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath) ?? ".";
            Directory.CreateDirectory(outputDir);

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

                // Apply a simple custom color filter:
                // Increase the red component and reduce the blue component for each pixel.
                for (int y = 0; y < raster.Height; y++)
                {
                    for (int x = 0; x < raster.Width; x++)
                    {
                        Color original = raster.GetPixel(x, y);
                        int newR = Math.Min(255, original.R + 50); // boost red
                        int newB = Math.Max(0, original.B - 30);   // reduce blue
                        Color filtered = Color.FromArgb(original.A, newR, original.G, newB);
                        raster.SetPixel(x, y, filtered);
                    }
                }

                // Save the filtered image as SVG with default options
                SvgOptions svgOptions = new SvgOptions();
                raster.Save(outputPath, svgOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}