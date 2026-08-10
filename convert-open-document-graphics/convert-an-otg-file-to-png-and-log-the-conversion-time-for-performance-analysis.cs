// HOW-TO: Convert OTG to PNG and Measure Conversion Time in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Diagnostics;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.otg";
            string outputPath = "output\\converted.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Measure conversion time
            Stopwatch sw = Stopwatch.StartNew();

            // Load OTG image and save as PNG
            using (Image image = Image.Load(inputPath))
            {
                var pngOptions = new PngOptions();
                var otgRaster = new OtgRasterizationOptions
                {
                    PageSize = image.Size
                };
                pngOptions.VectorRasterizationOptions = otgRaster;

                image.Save(outputPath, pngOptions);
            }

            sw.Stop();
            Console.WriteLine($"Conversion time: {sw.ElapsedMilliseconds} ms");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to generate PNG thumbnails from OTG vector drawings while tracking how long each conversion takes.
 * 2. When you are benchmarking Aspose.Imaging’s rasterization performance for OTG files in a C# application.
 * 3. When an automated workflow must validate that OTG assets are correctly exported to PNG before publishing.
 * 4. When you integrate image conversion into a server‑side service and need to log conversion latency for monitoring.
 * 5. When you are troubleshooting slow image processing and want to compare OTG‑to‑PNG conversion times across different hardware.
 */
