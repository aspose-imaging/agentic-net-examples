using System;
using System.IO;
using System.Diagnostics;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDir = @"C:\Images\Input\";
            string outputDir = @"C:\Images\Output\";

            // List of image files to process (hardcoded)
            string[] files = new string[]
            {
                "sample1.png",
                "sample2.png",
                "sample3.png"
            };

            // Define filters to apply
            var filters = new (string Name, Func<FilterOptionsBase> Options)[]
            {
                ("Median", () => new MedianFilterOptions(5)),
                ("GaussianBlur", () => new GaussianBlurFilterOptions(5, 4.0)),
                ("Sharpen", () => new SharpenFilterOptions(5, 4.0))
            };

            foreach (var fileName in files)
            {
                string inputPath = Path.Combine(inputDir, fileName);

                // Input file existence check
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                foreach (var filter in filters)
                {
                    // Load image
                    using (Image image = Image.Load(inputPath))
                    {
                        RasterImage rasterImage = (RasterImage)image;

                        // Create filter options
                        FilterOptionsBase options = filter.Options();

                        // Measure filter application time
                        Stopwatch sw = Stopwatch.StartNew();
                        rasterImage.Filter(rasterImage.Bounds, options);
                        sw.Stop();

                        // Prepare output path
                        string outputFileName = $"{Path.GetFileNameWithoutExtension(fileName)}_{filter.Name}.png";
                        string outputPath = Path.Combine(outputDir, outputFileName);

                        // Ensure output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save filtered image
                        rasterImage.Save(outputPath);

                        // Log duration
                        Console.WriteLine($"Applied {filter.Name} to {fileName} in {sw.ElapsedMilliseconds} ms. Saved to {outputPath}");
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
 * 1. When a developer needs to profile the performance of median, Gaussian blur, and sharpen filters on a batch of PNG images to ensure the processing pipeline meets SLA requirements.
 * 2. When building an automated image‑enhancement service that applies multiple filters to uploaded JPEG files and must log the execution time of each filter for cost estimation.
 * 3. When optimizing a desktop C# application that uses Aspose.Imaging to process large raster images and wants to compare the runtime of different filter options before selecting the most efficient one.
 * 4. When creating a CI/CD test that validates that recent changes to the Aspose.Imaging filter algorithms do not introduce regressions by measuring filter execution times on a predefined set of sample images.
 * 5. When generating a performance report for a cloud‑based image‑processing microservice that applies median, Gaussian blur, and sharpen filters to PNG assets and needs precise Stopwatch measurements for each step.
 */