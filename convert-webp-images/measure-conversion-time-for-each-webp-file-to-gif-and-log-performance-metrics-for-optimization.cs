// HOW-TO: Measure WebP to GIF Conversion Time and Log Performance in C# (Aspose.Imaging for .NET)
using System;
using System.Diagnostics;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDir = @"C:\temp\webp";
            string outputDir = @"C:\temp\gif";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            // Get all WebP files in the input directory
            string[] webpFiles = Directory.GetFiles(inputDir, "*.webp");

            foreach (string inputPath in webpFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine the output GIF path
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".gif";
                string outputPath = Path.Combine(outputDir, outputFileName);

                // Ensure the output directory exists (covers cases where outputDir may be nested)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Measure conversion time
                Stopwatch sw = Stopwatch.StartNew();

                // Load the WebP image
                using (Image image = Image.Load(inputPath))
                {
                    // Save as GIF
                    image.Save(outputPath, new GifOptions());
                }

                sw.Stop();

                // Log performance metric
                Console.WriteLine($"Converted '{inputPath}' to '{outputPath}' in {sw.ElapsedMilliseconds} ms");
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
 * 1. When you need to batch‑convert a folder of WebP images to GIFs while tracking how long each conversion takes to identify bottlenecks.
 * 2. When optimizing an image‑processing service and you want concrete milliseconds for each WebP‑to‑GIF operation to compare different libraries or settings.
 * 3. When generating animated GIF previews from WebP assets and you must log conversion times for monitoring SLA compliance.
 * 4. When profiling the impact of hardware or parallel processing on WebP to GIF conversion speed in a C# application.
 * 5. When building a CI pipeline that validates that WebP to GIF conversions stay within acceptable performance thresholds.
 */
