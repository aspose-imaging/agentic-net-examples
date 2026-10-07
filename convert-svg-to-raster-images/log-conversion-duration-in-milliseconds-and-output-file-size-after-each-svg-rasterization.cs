// HOW-TO: Measure SVG to PNG Conversion Time and Output Size in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
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

            string[] files = Directory.GetFiles(inputDirectory, "*.svg");

            foreach (var inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".png");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                var stopwatch = System.Diagnostics.Stopwatch.StartNew();

                using (Image image = Image.Load(inputPath))
                using (var options = new PngOptions())
                {
                    image.Save(outputPath, options);
                }

                stopwatch.Stop();
                long durationMs = stopwatch.ElapsedMilliseconds;
                long fileSize = new FileInfo(outputPath).Length;

                Console.WriteLine($"Converted '{inputPath}' to '{outputPath}' in {durationMs} ms, size: {fileSize} bytes.");
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
 * 1. When you need to benchmark how long each SVG file takes to rasterize to PNG in a batch processing pipeline.
 * 2. When you want to log the resulting PNG file size to monitor storage usage after converting vector graphics.
 * 3. When you are building an automated image conversion service that must report performance metrics for each request.
 * 4. When you need to verify that SVG rasterization meets latency requirements for real‑time web applications.
 * 5. When you are troubleshooting slow conversions and need both timing and output size data to pinpoint bottlenecks.
 */
