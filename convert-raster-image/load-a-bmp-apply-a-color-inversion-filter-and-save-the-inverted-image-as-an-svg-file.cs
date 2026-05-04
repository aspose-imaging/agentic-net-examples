using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.bmp";
            string outputPath = @"C:\temp\output.svg";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load BMP as a raster image
            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                // Load pixel data (ARGB format)
                int[] pixels = raster.LoadArgb32Pixels(raster.Bounds);

                // Invert colors (preserve alpha)
                for (int i = 0; i < pixels.Length; i++)
                {
                    int argb = pixels[i];
                    int a = (argb >> 24) & 0xFF;
                    int r = (argb >> 16) & 0xFF;
                    int g = (argb >> 8) & 0xFF;
                    int b = argb & 0xFF;

                    r = 255 - r;
                    g = 255 - g;
                    b = 255 - b;

                    pixels[i] = (a << 24) | (r << 16) | (g << 8) | b;
                }

                // Write inverted pixel data back to the image
                raster.SaveArgb32Pixels(raster.Bounds, pixels);

                // Save the inverted image as SVG
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