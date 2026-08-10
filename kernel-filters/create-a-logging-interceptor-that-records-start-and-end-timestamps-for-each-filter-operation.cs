// HOW-TO: Log Filter Execution Time and Save Image with Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    // Logs start and end timestamps for a filter operation, then saves the image.
    static void ApplyFilterWithLogging(RasterImage image, FilterOptionsBase filterOptions, string outputPath)
    {
        Console.WriteLine($"Filter start: {DateTime.UtcNow:O}");
        DateTime start = DateTime.UtcNow;

        // Apply the filter to the whole image.
        image.Filter(image.Bounds, filterOptions);

        DateTime end = DateTime.UtcNow;
        Console.WriteLine($"Filter end:   {end:O}");
        Console.WriteLine($"Duration: {(end - start).TotalMilliseconds} ms");

        // Ensure the output directory exists.
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Save the processed image.
        image.Save(outputPath);
    }

    static void Main()
    {
        try
        {
            // Hard‑coded input and output paths.
            string inputPath = @"C:\temp\sample.png";
            string outputPath = @"C:\temp\sample.filtered.png";

            // Verify input file exists.
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the image.
            using (Image img = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering.
                RasterImage raster = (RasterImage)img;

                // Example filter: Sharpen with kernel size 5 and sigma 4.0.
                var sharpenOptions = new SharpenFilterOptions(5, 4.0);

                // Apply filter with logging and save.
                ApplyFilterWithLogging(raster, sharpenOptions, outputPath);
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
 * 1. When you need to measure and record how long a Sharpen filter takes on a PNG image during automated processing.
 * 2. When you want to add timestamped logging around any Aspose.Imaging filter to audit image transformation steps in a C# application.
 * 3. When you are building a batch image‑processing pipeline that must save filtered images to a specific folder while ensuring the output directory exists.
 * 4. When you need to capture start and end times of a filter operation to calculate performance metrics for optimization of image‑filtering code.
 * 5. When you must handle missing input files gracefully and log filter execution details for troubleshooting in a .NET image‑processing service.
 */
