// HOW-TO: Convert ODG to PNG and Measure Conversion Time in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Diagnostics;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace OdgToPngConverter
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.odg";
                string outputPath = "output.png";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                Stopwatch sw = Stopwatch.StartNew();

                using (Image image = Image.Load(inputPath))
                {
                    PngOptions options = new PngOptions();
                    image.Save(outputPath, options);
                }

                sw.Stop();
                Console.WriteLine($"Conversion completed in {sw.Elapsed.TotalMilliseconds} ms.");
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
 * 1. When you need to batch‑convert OpenDocument graphics (ODG) files to PNG for web display while tracking performance.
 * 2. When you want to integrate ODG to PNG conversion into a C# service and log the time taken for each conversion to identify bottlenecks.
 * 3. When you are building an automated pipeline that validates ODG assets by converting them to PNG and measuring processing speed.
 * 4. When you need to generate PNG thumbnails from ODG diagrams in a desktop application and record how long each rendering takes.
 * 5. When you are profiling image‑conversion code to compare Aspose.Imaging performance against other libraries for ODG files.
 */
