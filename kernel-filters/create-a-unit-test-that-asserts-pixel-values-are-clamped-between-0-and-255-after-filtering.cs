using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output/output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Apply sharpen filter
                raster.Filter(raster.Bounds, new SharpenFilterOptions(5, 4.0));

                // Verify that all ARGB components are within 0-255
                bool allClamped = true;
                for (int y = 0; y < raster.Height && allClamped; y++)
                {
                    for (int x = 0; x < raster.Width; x++)
                    {
                        int argb = raster.GetArgb32Pixel(x, y);
                        int a = (argb >> 24) & 0xFF;
                        int r = (argb >> 16) & 0xFF;
                        int g = (argb >> 8) & 0xFF;
                        int b = argb & 0xFF;

                        if (a < 0 || a > 255 || r < 0 || r > 255 || g < 0 || g > 255 || b < 0 || b > 255)
                        {
                            allClamped = false;
                            break;
                        }
                    }
                }

                Console.WriteLine(allClamped
                    ? "All pixel values are within 0-255."
                    : "Pixel values out of range detected.");

                // Save the filtered image
                raster.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}