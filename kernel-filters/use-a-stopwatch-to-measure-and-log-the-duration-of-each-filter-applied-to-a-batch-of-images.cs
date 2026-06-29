using System;
using System.IO;
using System.Diagnostics;
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

            // List of input image files
            string[] inputFiles = new string[]
            {
                Path.Combine(inputDir, "sample1.png"),
                Path.Combine(inputDir, "sample2.png")
            };

            foreach (string inputPath in inputFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Apply Median filter
                ProcessFilter(
                    inputPath,
                    outputDir,
                    "Median",
                    () => new MedianFilterOptions(5));

                // Apply Gaussian Blur filter
                ProcessFilter(
                    inputPath,
                    outputDir,
                    "GaussianBlur",
                    () => new GaussianBlurFilterOptions(5, 4.0));

                // Apply Sharpen filter
                ProcessFilter(
                    inputPath,
                    outputDir,
                    "Sharpen",
                    () => new SharpenFilterOptions(5, 4.0));
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    // Applies a specific filter to the image, measures duration, and saves the result.
    static void ProcessFilter(string inputPath, string outputDir, string filterName, Func<FilterOptionsBase> optionsFactory)
    {
        // Load the image
        using (Image image = Image.Load(inputPath))
        {
            RasterImage rasterImage = (RasterImage)image;

            // Measure filter application time
            Stopwatch sw = Stopwatch.StartNew();
            rasterImage.Filter(rasterImage.Bounds, optionsFactory());
            sw.Stop();

            // Prepare output path and ensure directory exists
            string outputFileName = $"{Path.GetFileNameWithoutExtension(inputPath)}.{filterName}.png";
            string outputPath = Path.Combine(outputDir, outputFileName);
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Save the filtered image
            rasterImage.Save(outputPath);

            // Log duration
            Console.WriteLine($"{filterName} filter applied to {inputPath} in {sw.ElapsedMilliseconds} ms. Saved to {outputPath}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to benchmark the performance of Median, Gaussian Blur, and Sharpen filters on a set of PNG images before deploying an automated image‑processing pipeline.
 * 2. When an e‑commerce platform wants to log the time taken to apply quality‑enhancing filters to product photos in bulk so they can optimize server resources.
 * 3. When a medical imaging application must verify that applying filters to DICOM‑converted JPEG files meets latency requirements for real‑time diagnostics.
 * 4. When a photo‑editing SaaS service wants to record per‑filter execution times to generate usage reports and SLA metrics for its C# backend.
 * 5. When a game development studio needs to measure and compare filter processing speeds across different image formats (PNG, BMP) to decide which assets to pre‑process during build time.
 */