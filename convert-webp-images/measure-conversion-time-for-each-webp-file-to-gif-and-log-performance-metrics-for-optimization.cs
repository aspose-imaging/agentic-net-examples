// HOW-TO: Measure WebP to GIF Conversion Time with Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.Diagnostics;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace WebPToGifConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Hardcoded input and output directories
                string inputDirectory = "input";
                string outputDirectory = "output";

                // Ensure output directory exists
                Directory.CreateDirectory(outputDirectory);

                // Get all WebP files in the input directory
                string[] webpFiles = Directory.GetFiles(inputDirectory, "*.webp");

                if (webpFiles.Length == 0)
                {
                    Console.WriteLine("No WebP files found to process.");
                    return;
                }

                long totalMilliseconds = 0;
                int processedCount = 0;

                foreach (string inputPath in webpFiles)
                {
                    // Verify input file exists
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".gif");

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    Stopwatch sw = Stopwatch.StartNew();

                    using (Image image = Image.Load(inputPath))
                    {
                        image.Save(outputPath, new GifOptions());
                    }

                    sw.Stop();
                    long elapsedMs = sw.ElapsedMilliseconds;
                    totalMilliseconds += elapsedMs;
                    processedCount++;

                    Console.WriteLine($"Converted '{inputPath}' to '{outputPath}' in {elapsedMs} ms");
                }

                Console.WriteLine($"Processed {processedCount} file(s). Total time: {totalMilliseconds} ms. Average time: {(processedCount > 0 ? totalMilliseconds / processedCount : 0)} ms per file.");
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
 * 1. When you need to benchmark how long each WebP image takes to convert to GIF for performance tuning.
 * 2. When you want to log total conversion time across a batch of WebP files to identify bottlenecks.
 * 3. When you are building an automated pipeline that processes large numbers of WebP assets and need per‑file timing metrics.
 * 4. When you must ensure that the output GIFs are generated within a specific time budget for real‑time applications.
 * 5. When you are comparing Aspose.Imaging conversion speed against other libraries by measuring elapsed milliseconds per file.
 */
