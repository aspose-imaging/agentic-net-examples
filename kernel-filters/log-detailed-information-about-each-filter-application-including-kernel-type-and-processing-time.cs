using System;
using System.Diagnostics;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\sample.png";
        string outputPath = @"c:\temp\sample.SharpenFilter.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access Filter method
                RasterImage rasterImage = (RasterImage)image;

                // Prepare sharpen filter options
                int kernelSize = 5;
                double sigma = 4.0;
                var sharpenOptions = new SharpenFilterOptions(kernelSize, sigma);

                // Log kernel information
                Console.WriteLine($"Applying Sharpen filter with kernel size {kernelSize} and sigma {sigma}.");
                Console.WriteLine($"Kernel type: {sharpenOptions.Kernel?.GetType().Name ?? "null"}");

                // Measure processing time
                Stopwatch sw = Stopwatch.StartNew();
                rasterImage.Filter(rasterImage.Bounds, sharpenOptions);
                sw.Stop();

                Console.WriteLine($"Filter applied in {sw.ElapsedMilliseconds} ms.");

                // Save the processed image
                rasterImage.Save(outputPath);
                Console.WriteLine($"Saved sharpened image to: {outputPath}");
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
 * 1. When a developer needs to automatically sharpen high‑resolution PNG photos in a batch job and log the kernel parameters and processing time for performance monitoring.
 * 2. When building a C# desktop application that lets users enhance scanned documents by applying a customizable sharpen filter and records the filter details for audit trails.
 * 3. When integrating Aspose.Imaging into a server‑side service that receives uploaded images, applies a 5×5 Gaussian‑based sharpen filter, and logs execution time to optimize resource usage.
 * 4. When creating a diagnostic tool that validates image‑processing pipelines by loading a PNG, applying a SharpenFilterOptions with specific sigma, and outputting kernel type and elapsed milliseconds to the console.
 * 5. When developing an automated quality‑control script that processes product images, saves the sharpened result with a .SharpenFilter.png suffix, and captures detailed filter metadata for reporting.
 */