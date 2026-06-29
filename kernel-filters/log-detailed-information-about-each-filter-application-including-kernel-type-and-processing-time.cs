using System;
using System.IO;
using System.Diagnostics;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\sample.png";
        string outputPath = @"c:\temp\sample.SharpenFilter.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering
                RasterImage rasterImage = (RasterImage)image;

                // Create sharpen filter options (kernel size 5, sigma 4.0)
                var sharpenOptions = new SharpenFilterOptions(5, 4.0);

                // Log kernel type
                Console.WriteLine($"Applying filter: {sharpenOptions.GetType().Name}");

                // Measure processing time
                Stopwatch sw = Stopwatch.StartNew();

                // Apply filter to the whole image
                rasterImage.Filter(rasterImage.Bounds, sharpenOptions);

                sw.Stop();
                Console.WriteLine($"Filter applied in {sw.ElapsedMilliseconds} ms");

                // Save the processed image
                rasterImage.Save(outputPath);
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
 * 1. When a developer needs to automatically sharpen PNG images in a batch processing pipeline and log the filter type and execution time for performance monitoring.
 * 2. When building a desktop C# application that enhances scanned documents by applying a 5‑pixel sharpen filter and records processing duration to display progress to users.
 * 3. When creating a server‑side image service that receives image files, applies a custom SharpenFilterOptions (kernel size 5, sigma 4.0) and logs kernel details for audit trails.
 * 4. When troubleshooting image quality issues in a .NET workflow and needs to compare before‑and‑after results while measuring how long the filter takes on different image resolutions.
 * 5. When integrating Aspose.Imaging into an automated CI/CD test that validates that PNG assets are sharpened correctly and that the filter execution stays within acceptable time limits.
 */