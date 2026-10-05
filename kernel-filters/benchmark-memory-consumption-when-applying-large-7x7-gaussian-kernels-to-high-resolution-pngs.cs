// HOW-TO: Measure Memory Usage of 7x7 Gaussian Blur on High Resolution PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            long beforeMemory = GC.GetTotalMemory(true);

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(7, 1.0);
                raster.Filter(raster.Bounds, filterOptions);

                var saveOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                raster.Save(outputPath, saveOptions);
            }

            long afterMemory = GC.GetTotalMemory(true);
            long diff = afterMemory - beforeMemory;
            Console.WriteLine($"Memory used: {diff} bytes");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to ensure your image processing pipeline can handle large Gaussian blur operations on 4K or larger PNG files without exceeding memory limits.
 * 2. When you want to compare memory consumption of different filter kernel sizes before deploying a desktop application that applies blur effects.
 * 3. When you are optimizing a server‑side service that receives high‑resolution PNG uploads and applies Gaussian smoothing, and you need to verify its RAM usage.
 * 4. When you are troubleshooting out‑of‑memory exceptions in a C# program that uses Aspose.Imaging to process medical or satellite PNG images with heavy blur filters.
 * 5. When you are writing automated tests to benchmark the impact of Aspose.Imaging’s GaussianBlurFilterOptions on .NET garbage collection for large raster images.
 */
