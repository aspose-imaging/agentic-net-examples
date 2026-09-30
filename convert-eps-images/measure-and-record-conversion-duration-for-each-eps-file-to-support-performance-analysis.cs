// HOW-TO: Measure EPS to PNG Conversion Time in C# with Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Diagnostics;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

namespace EpsConversion
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded input EPS files
                string[] inputPaths = { "sample1.eps", "sample2.eps" };
                // Hardcoded output directory
                string outputDir = "output";

                foreach (string inputPath in inputPaths)
                {
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                    string outputPath = Path.Combine(outputDir, fileNameWithoutExt + ".png");

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    Stopwatch stopwatch = Stopwatch.StartNew();

                    using (Image image = Image.Load(inputPath))
                    {
                        PngOptions pngOptions = new PngOptions
                        {
                            ColorType = PngColorType.Grayscale
                        };
                        image.Save(outputPath, pngOptions);
                    }

                    stopwatch.Stop();
                    Console.WriteLine($"Converted {inputPath} to {outputPath} in {stopwatch.ElapsedMilliseconds} ms");
                }
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
 * 1. When you need to benchmark how long it takes to convert multiple EPS vector files to grayscale PNG images in a C# application.
 * 2. When you want to log conversion performance for each file to identify bottlenecks in an automated image processing pipeline.
 * 3. When you are building a batch conversion tool that must ensure consistent processing times across different EPS sources.
 * 4. When you need to verify that the Aspose.Imaging library meets your project's speed requirements for EPS to PNG transformations.
 * 5. When you are generating performance reports for stakeholders that compare the runtime of converting EPS artwork to PNG thumbnails.
 */
