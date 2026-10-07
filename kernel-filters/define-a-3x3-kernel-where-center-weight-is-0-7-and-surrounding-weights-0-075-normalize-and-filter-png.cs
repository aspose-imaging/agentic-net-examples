// HOW-TO: Apply Custom 3x3 Convolution Filter to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            double centerWeight = 0.7 / 1.3;
            double surroundWeight = 0.075 / 1.3;
            double[,] kernel = new double[3, 3];

            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    kernel[y, x] = surroundWeight;
                }
            }
            kernel[1, 1] = centerWeight;

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel));
                PngOptions options = new PngOptions();
                raster.Save(outputPath, options);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to soften a PNG image by applying a weighted blur using a custom 3x3 kernel in a C# application.
 * 2. When you want to enhance the central pixel influence while preserving surrounding details in a PNG before further processing.
 * 3. When you are building an automated image pipeline that normalizes and applies a specific convolution mask to every PNG file.
 * 4. When you need to replace the default Gaussian blur with a custom kernel to achieve a particular visual effect in a .NET image‑processing project.
 * 5. When you must ensure the output PNG retains its format after applying a convolution filter without losing metadata in a C# service.
 */
