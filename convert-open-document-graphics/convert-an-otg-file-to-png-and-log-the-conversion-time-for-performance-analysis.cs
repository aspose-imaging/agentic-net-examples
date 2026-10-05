// HOW-TO: Convert OTG to PNG and Measure Conversion Time in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Diagnostics;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace OTGToPngConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "input.otg";
                string outputPath = "output/output.png";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                Stopwatch stopwatch = Stopwatch.StartNew();

                using (Image image = Image.Load(inputPath))
                {
                    var pngOptions = new PngOptions();
                    image.Save(outputPath, pngOptions);
                }

                stopwatch.Stop();
                Console.WriteLine($"Conversion completed in {stopwatch.ElapsedMilliseconds} ms.");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to convert legacy OTG design files to web‑friendly PNG images while tracking how long each conversion takes.
 * 2. When building an automated pipeline that processes incoming OTG assets and logs conversion performance for scalability analysis.
 * 3. When integrating Aspose.Imaging into a C# application to replace OTG graphics with PNGs for UI rendering and you want to benchmark the operation.
 * 4. When troubleshooting slow image conversions by measuring elapsed milliseconds for each OTG‑to‑PNG transformation.
 * 5. When generating PNG thumbnails from OTG files on a server and recording conversion times to optimize resource usage.
 */
