// HOW-TO: Measure EPS to PNG Conversion Time with Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.*");
            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                if (!inputPath.EndsWith(".eps", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".png";
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                DateTime start = DateTime.Now;

                using (Image image = Image.Load(inputPath))
                {
                    using (var options = new PngOptions())
                    {
                        options.VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            BackgroundColor = Color.White,
                            PageWidth = image.Width,
                            PageHeight = image.Height
                        };

                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                        image.Save(outputPath, options);
                    }
                }

                TimeSpan elapsed = DateTime.Now - start;
                Console.WriteLine($"{Path.GetFileName(inputPath)} conversion took {elapsed.TotalMilliseconds} ms");
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
 * 1. When you need to benchmark how long batch converting EPS artwork to PNG takes in a C# application.
 * 2. When you want to log conversion performance for each EPS file to identify slow‑processing documents.
 * 3. When you are optimizing a server‑side image pipeline and need precise timing for EPS‑to‑PNG rasterization.
 * 4. When you must compare different rasterization settings and need per‑file duration metrics for EPS conversions.
 * 5. When you are generating a performance report for a graphics workflow that processes many EPS files into PNG format.
 */
