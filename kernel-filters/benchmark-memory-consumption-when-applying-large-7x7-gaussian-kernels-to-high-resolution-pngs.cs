using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\Images\high_res.png";
        string outputPath = @"C:\Images\high_res_gaussian_7x7.png";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the high‑resolution PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering methods
                RasterImage rasterImage = (RasterImage)image;

                // Record memory usage before processing
                long memoryBefore = Aspose.Imaging.Cache.AllocatedMemoryBytesCount;

                // Apply a 7×7 Gaussian blur (size = 7, sigma = 1.0)
                var blurOptions = new GaussianBlurFilterOptions(7, 1.0);
                rasterImage.Filter(rasterImage.Bounds, blurOptions);

                // Save the processed image
                rasterImage.Save(outputPath);

                // Record memory usage after processing
                long memoryAfter = Aspose.Imaging.Cache.AllocatedMemoryBytesCount;

                // Output memory consumption statistics
                Console.WriteLine($"Memory allocated before: {memoryBefore} bytes");
                Console.WriteLine($"Memory allocated after : {memoryAfter} bytes");
                Console.WriteLine($"Memory increase        : {memoryAfter - memoryBefore} bytes");
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
 * 1. When a developer needs to measure the memory impact of applying a 7×7 Gaussian blur to a high‑resolution PNG image in a C# .NET application.
 * 2. When a performance engineer wants to compare allocated memory before and after using Aspose.Imaging’s RasterImage.Filter method on large raster graphics.
 * 3. When a QA tester must verify that processing a 7×7 Gaussian kernel does not cause excessive memory usage for PNG files in an automated test suite.
 * 4. When a software architect is evaluating the scalability of image‑processing pipelines that include high‑resolution PNG loading, filtering, and saving with Aspose.Imaging.
 * 5. When a developer is troubleshooting memory‑related exceptions while applying Gaussian blur filters to big PNG assets in a Windows service.
 */