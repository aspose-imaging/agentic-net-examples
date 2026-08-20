// HOW-TO: Convert ODG to PNG and Measure Conversion Time in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.odg";
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
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();

            // Load ODG image
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

                // Save as PNG
                image.Save(outputPath, pngOptions);
            }

            stopwatch.Stop();
            Console.WriteLine($"Conversion time: {stopwatch.ElapsedMilliseconds} ms");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to generate web‑ready PNG thumbnails from LibreOffice ODG drawings while tracking how long each conversion takes.
 * 2. When a batch process must convert multiple ODG files to PNG for a reporting system and you want to log the elapsed milliseconds for performance tuning.
 * 3. When integrating Aspose.Imaging into a C# application to rasterize vector ODG pages into PNG images with a white background and measure the conversion speed.
 * 4. When optimizing a document‑conversion pipeline and require precise timing data to compare different rasterization settings for ODG to PNG output.
 * 5. When building a server‑side service that receives ODG uploads, converts them to PNG for preview, and records the processing time for monitoring and SLA compliance.
 */
