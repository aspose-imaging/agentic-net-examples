using System;
using System.IO;
using System.Diagnostics;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDir = "C:\\temp\\webp\\";
            string outputDir = "C:\\temp\\gif\\";

            // Get all WebP files in the input directory
            string[] webpFiles = Directory.GetFiles(inputDir, "*.webp");

            foreach (string inputPath in webpFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output path (same filename with .gif extension)
                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + ".gif");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load WebP image and convert to GIF while measuring time
                using (WebPImage webPImage = new WebPImage(inputPath))
                {
                    Stopwatch sw = Stopwatch.StartNew();

                    // Save as GIF
                    webPImage.Save(outputPath, new GifOptions());

                    sw.Stop();

                    Console.WriteLine($"Converted {Path.GetFileName(inputPath)} to GIF in {sw.ElapsedMilliseconds} ms.");
                }
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
 * 1. When a developer needs to batch‑convert a folder of WebP images to GIF for compatibility with legacy browsers, they can use this code to process each file and log the conversion time.
 * 2. When optimizing an image‑processing pipeline, a developer can measure the milliseconds each WebP‑to‑GIF conversion takes to identify performance bottlenecks.
 * 3. When preparing assets for email newsletters that only support GIF, a developer can automatically convert WebP files and record how long each conversion runs.
 * 4. When building a server‑side service that receives WebP uploads and must deliver GIF previews, this code provides a simple way to generate the previews while tracking execution time.
 * 5. When conducting a benchmark of Aspose.Imaging’s WebPImage class versus other libraries, a developer can run this script to log per‑file conversion durations for accurate comparison.
 */