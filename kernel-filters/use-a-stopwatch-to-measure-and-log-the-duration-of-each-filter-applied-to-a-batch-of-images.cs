// HOW-TO: Measure Execution Time Of Multiple Image Filters In C# With Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Diagnostics;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDir = @"C:\Images\Input\";
            string outputDir = @"C:\Images\Output\";

            // List of image files to process
            string[] imageFiles = new[]
            {
                "sample1.png",
                "sample2.png"
            };

            // Define filter configurations
            var filters = new (string suffix, FilterOptionsBase options)[]
            {
                ("Median", new MedianFilterOptions(5)),
                ("Bilateral", new BilateralSmoothingFilterOptions(5)),
                ("Gaussian", new GaussianBlurFilterOptions(5, 4.0)),
                ("Sharpen", new SharpenFilterOptions(5, 4.0))
            };

            foreach (var fileName in imageFiles)
            {
                string inputPath = Path.Combine(inputDir, fileName);

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the image once per file
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to RasterImage to access Filter method
                    RasterImage rasterImage = (RasterImage)image;

                    foreach (var (suffix, options) in filters)
                    {
                        // Measure filter application time
                        Stopwatch sw = Stopwatch.StartNew();

                        rasterImage.Filter(rasterImage.Bounds, options);

                        sw.Stop();
                        Console.WriteLine($"Applied {suffix} filter to {fileName} in {sw.ElapsedMilliseconds} ms.");

                        // Prepare output path
                        string outputFileName = Path.GetFileNameWithoutExtension(fileName) + "." + suffix + ".png";
                        string outputPath = Path.Combine(outputDir, outputFileName);

                        // Ensure output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the processed image
                        rasterImage.Save(outputPath);
                    }
                }
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
 * 1. When you need to benchmark how long median, bilateral, Gaussian, and sharpen filters take on a set of PNG files before optimizing a photo‑editing pipeline.
 * 2. When processing a batch of product images you want to log the performance of each filter to ensure the server meets SLA requirements.
 * 3. When comparing different smoothing techniques on JPEG thumbnails you need precise timing data to choose the most efficient filter for a web service.
 * 4. When integrating Aspose.Imaging into an automated quality‑control system you must record filter execution times to detect performance regressions.
 * 5. When building a desktop application that applies multiple filters to user‑selected images you want to display the elapsed time for each operation to improve user experience.
 */
