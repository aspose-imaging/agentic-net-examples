using System;
using System.IO;
using System.Diagnostics;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\input\sample.otg";
        string outputPath = @"C:\output\sample.png";

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

            // Start timing the conversion
            Stopwatch stopwatch = Stopwatch.StartNew();

            // Load the OTG image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PNG save options with OTG rasterization settings
                PngOptions pngOptions = new PngOptions();
                OtgRasterizationOptions otgRasterization = new OtgRasterizationOptions
                {
                    // Preserve original page size
                    PageSize = image.Size
                };
                pngOptions.VectorRasterizationOptions = otgRasterization;

                // Save as PNG
                image.Save(outputPath, pngOptions);
            }

            // Stop timing and report
            stopwatch.Stop();
            Console.WriteLine($"Conversion completed in {stopwatch.ElapsedMilliseconds} ms.");
        }
        catch (Exception ex)
        {
            // Log any unexpected errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a GIS application needs to generate web‑ready raster thumbnails from vector OTG maps and measure how long each conversion takes for scaling the service.
 * 2. When an automated batch job processes engineering drawings stored as OTG files, converts them to PNG for inclusion in PDF reports, and records the elapsed milliseconds to identify performance bottlenecks.
 * 3. When a desktop utility built with C# and Aspose.Imaging converts user‑selected OTG schematics to PNG for preview in a Windows Forms UI while logging conversion time to display progress feedback.
 * 4. When a cloud‑based image processing pipeline receives OTG assets, rasterizes them to PNG using OtgRasterizationOptions and stores the timing data in logs to monitor SLA compliance.
 * 5. When a QA test suite validates that the OtgRasterizationOptions preserve the original page size during OTG‑to‑PNG conversion and captures the stopwatch measurement to compare against expected performance thresholds.
 */