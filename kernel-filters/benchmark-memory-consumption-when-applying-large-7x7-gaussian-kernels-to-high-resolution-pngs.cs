using System;
using System.IO;
using System.Diagnostics;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\high_res.png";
        string outputPath = @"C:\Images\high_res_gaussian.png";

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
            // Measure memory before processing
            long memoryBefore = Aspose.Imaging.Cache.AllocatedMemoryBytesCount;

            // Load the high‑resolution PNG image
            using (PngImage pngImage = new PngImage(inputPath))
            {
                // Cast to RasterImage to apply filters
                RasterImage rasterImage = (RasterImage)pngImage;

                // Prepare a 7x7 Gaussian blur filter (size = 7, sigma = 1.0)
                var gaussianOptions = new GaussianBlurFilterOptions(7, 1.0);

                // Apply the filter to the whole image
                rasterImage.Filter(rasterImage.Bounds, gaussianOptions);

                // Save the processed image
                rasterImage.Save(outputPath);
            }

            // Measure memory after processing
            long memoryAfter = Aspose.Imaging.Cache.AllocatedMemoryBytesCount;

            // Output memory consumption details
            Console.WriteLine($"Memory allocated before: {memoryBefore} bytes");
            Console.WriteLine($"Memory allocated after : {memoryAfter} bytes");
            Console.WriteLine($"Memory used by operation: {memoryAfter - memoryBefore} bytes");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to benchmark memory usage while applying a 7x7 Gaussian blur to a high‑resolution PNG image in a C# application.
 * 2. When optimizing a .NET image‑processing pipeline that handles large PNG files and must ensure memory consumption stays within acceptable limits.
 * 3. When validating that the Aspose.Imaging cache correctly releases memory after applying a GaussianBlurFilterOptions to a raster image.
 * 4. When creating automated tests for high‑resolution PNG handling and wanting to log memory before and after the filter operation.
 * 5. When integrating image‑enhancement features into a C# desktop tool and need to measure the impact of a 7×7 Gaussian kernel on system resources.
 */