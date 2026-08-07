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

            // List of image file names to process
            string[] files = new string[]
            {
                "sample1.png",
                "sample2.png"
            };

            // Define filters to apply
            var filters = new (string Name, FilterOptionsBase Options)[]
            {
                ("Median", new MedianFilterOptions(5)),
                ("Bilateral", new BilateralSmoothingFilterOptions(5)),
                ("GaussianBlur", new GaussianBlurFilterOptions(5, 4.0)),
                ("Sharpen", new SharpenFilterOptions(5, 4.0))
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

                        // Measure filter application time
                        Stopwatch sw = Stopwatch.StartNew();
                        rasterImage.Filter(rasterImage.Bounds, filter.Options);
                        sw.Stop();

                        // Prepare output path
                        string outputFileName = Path.GetFileNameWithoutExtension(fileName) + "." + filter.Name + ".png";
                        string outputPath = Path.Combine(outputDir, outputFileName);

                        // Ensure output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save filtered image
                        rasterImage.Save(outputPath);

                        // Log duration
                        Console.WriteLine($"{fileName} - {filter.Name} filter applied in {sw.ElapsedMilliseconds} ms, saved to {outputPath}");
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
 * 1. When a developer needs to benchmark the performance of different Aspose.Imaging filters (e.g., Median, Bilateral, GaussianBlur, Sharpen) on a set of PNG files to choose the fastest option for a high‑throughput image‑processing service.
 * 2. When an e‑commerce platform wants to log the time taken to apply each filter to product photos so it can estimate processing costs and ensure that image‑optimization jobs stay within budgeted CPU time.
 * 3. When a medical‑imaging application must verify that applying smoothing and sharpening filters to DICOM‑converted PNG scans meets strict latency requirements for real‑time diagnostics.
 * 4. When a cloud‑based API that serves filtered images needs to record per‑filter execution times to enforce service‑level agreements (SLAs) and trigger alerts if any filter exceeds the allowed threshold.
 * 5. When a print‑shop automation system processes batches of artwork and needs detailed timing reports for each filter to fine‑tune parameters and reduce overall turnaround time for large‑format printing.
 */