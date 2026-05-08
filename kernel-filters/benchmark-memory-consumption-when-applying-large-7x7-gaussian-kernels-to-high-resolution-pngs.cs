using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "C:\\Images\\highres.png";
            string outputPath = "C:\\Images\\highres_gaussian.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Memory before loading the image
            long memoryBeforeLoad = Aspose.Imaging.Cache.AllocatedMemoryBytesCount;

            // Load the high‑resolution PNG
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Memory after loading
                long memoryAfterLoad = Aspose.Imaging.Cache.AllocatedMemoryBytesCount;

                // Apply a 7×7 Gaussian blur (size = 7, sigma = 1.0)
                var blurOptions = new GaussianBlurFilterOptions(7, 1.0);
                raster.Filter(raster.Bounds, blurOptions);

                // Memory after filtering
                long memoryAfterFilter = Aspose.Imaging.Cache.AllocatedMemoryBytesCount;

                // Save the processed image
                raster.Save(outputPath);

                // Memory after saving
                long memoryAfterSave = Aspose.Imaging.Cache.AllocatedMemoryBytesCount;

                // Output memory usage statistics
                Console.WriteLine($"Memory (bytes) before load: {memoryBeforeLoad}");
                Console.WriteLine($"Memory (bytes) after load: {memoryAfterLoad}");
                Console.WriteLine($"Memory (bytes) after filter: {memoryAfterFilter}");
                Console.WriteLine($"Memory (bytes) after save: {memoryAfterSave}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}