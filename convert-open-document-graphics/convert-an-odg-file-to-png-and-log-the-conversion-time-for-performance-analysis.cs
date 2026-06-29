using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "sample.odg";
            string outputPath = "sample.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists (unconditional call as required)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Start timing the conversion
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();

            // Load the ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Set rasterization options for ODG
                var rasterOptions = new OdgRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageSize = image.Size
                };

                // Configure PNG save options with the rasterization settings
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save the image as PNG
                image.Save(outputPath, pngOptions);
            }

            // Stop timing and report duration
            stopwatch.Stop();
            Console.WriteLine($"Conversion completed in {stopwatch.ElapsedMilliseconds} ms.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a .NET application must generate web‑ready thumbnails from OpenDocument graphics (ODG) files and needs to measure the conversion speed for scaling the service.
 * 2. When an automated document‑processing pipeline converts user‑uploaded ODG diagrams to PNG for previewing in browsers while logging elapsed milliseconds to monitor performance bottlenecks.
 * 3. When a reporting tool extracts vector drawings from ODG files, rasterizes them with a white background, saves them as PNG, and records the time taken to ensure SLA compliance.
 * 4. When a batch job processes large collections of ODG assets, uses Aspose.Imaging in C# to convert each to PNG and stores conversion durations for later optimization analysis.
 * 5. When a desktop utility needs to validate that rasterization options (page size, background color) produce correct PNG output and simultaneously capture the conversion time for debugging.
 */