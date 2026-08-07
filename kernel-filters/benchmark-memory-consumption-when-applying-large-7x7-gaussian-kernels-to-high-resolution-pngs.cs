using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "C:\\Images\\high_res.png";
            string outputPath = "C:\\Images\\high_res_gaussian.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Record memory usage before loading the image
            long memoryBeforeLoad = Aspose.Imaging.Cache.AllocatedMemoryBytesCount;

            // Load the high‑resolution PNG image
            using (PngImage pngImage = new PngImage(inputPath))
            {
                // Cast to RasterImage for filtering
                RasterImage rasterImage = (RasterImage)pngImage;

                // Record memory usage after loading
                long memoryAfterLoad = Aspose.Imaging.Cache.AllocatedMemoryBytesCount;

                // Apply a 7x7 Gaussian blur with sigma = 1.0
                var blurOptions = new GaussianBlurFilterOptions(7, 1.0);
                rasterImage.Filter(rasterImage.Bounds, blurOptions);

                // Record memory usage after applying the filter
                long memoryAfterFilter = Aspose.Imaging.Cache.AllocatedMemoryBytesCount;

                // Save the processed image
                rasterImage.Save(outputPath);

                // Record memory usage after saving
                long memoryAfterSave = Aspose.Imaging.Cache.AllocatedMemoryBytesCount;

                // Output memory consumption details
                Console.WriteLine($"Memory before load: {memoryBeforeLoad}");
                Console.WriteLine($"Memory after load: {memoryAfterLoad}");
                Console.WriteLine($"Memory after filter: {memoryAfterFilter}");
                Console.WriteLine($"Memory after save: {memoryAfterSave}");
                Console.WriteLine($"Increase due to processing: {memoryAfterFilter - memoryAfterLoad}");
            }

            // Force cleanup and report final memory usage
            GC.Collect();
            GC.WaitForPendingFinalizers();
            long finalMemory = Aspose.Imaging.Cache.AllocatedMemoryBytesCount;
            Console.WriteLine($"Final allocated memory: {finalMemory}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer is optimizing a desktop photo‑editing application that processes high‑resolution PNG files and needs to ensure the 7×7 Gaussian blur filter does not cause excessive memory usage.
 * 2. When a performance engineer is evaluating the memory footprint of batch‑processing pipelines that apply large Gaussian kernels to satellite imagery stored as PNGs before archiving.
 * 3. When a cloud‑based image‑service provider wants to benchmark the memory consumption of on‑the‑fly PNG transformations using Aspose.Imaging to size their VM instances correctly.
 * 4. When a QA tester is measuring how much memory is allocated during loading, filtering, and saving of ultra‑HD PNG assets in a C# game engine that uses Gaussian blur for visual effects.
 * 5. When a DevOps team needs to set memory limits for containerized micro‑services that perform high‑resolution PNG Gaussian blur operations with Aspose.Imaging to prevent out‑of‑memory crashes.
 */