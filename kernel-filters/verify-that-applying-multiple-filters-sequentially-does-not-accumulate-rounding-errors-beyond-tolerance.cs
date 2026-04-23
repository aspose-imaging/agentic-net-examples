using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "sample.png";
        string outputPath = "output\\filtered.png";

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

                // Capture original pixel data
                int[] originalPixels = raster.GetDefaultArgb32Pixels(raster.Bounds);

                // Apply first filter: Gaussian blur
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

                // Apply second filter: Sharpen
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));

                // Capture filtered pixel data
                int[] filteredPixels = raster.GetDefaultArgb32Pixels(raster.Bounds);

                // Verify rounding error tolerance
                int tolerance = 5;
                int maxDiff = 0;
                for (int i = 0; i < originalPixels.Length; i++)
                {
                    int diff = Math.Abs(originalPixels[i] - filteredPixels[i]);
                    if (diff > maxDiff) maxDiff = diff;
                }

                if (maxDiff > tolerance)
                {
                    Console.WriteLine($"Warning: Max pixel difference {maxDiff} exceeds tolerance {tolerance}.");
                }
                else
                {
                    Console.WriteLine($"Success: Max pixel difference {maxDiff} is within tolerance {tolerance}.");
                }

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