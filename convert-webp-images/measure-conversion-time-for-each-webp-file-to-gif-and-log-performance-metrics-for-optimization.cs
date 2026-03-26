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
        // Hardcoded input WebP files
        string[] inputPaths = new string[]
        {
            @"c:\temp\image1.webp",
            @"c:\temp\image2.webp"
        };

        // Hardcoded output directory
        string outputDir = @"c:\temp\output";

        // Ensure the output directory exists (unconditional)
        Directory.CreateDirectory(outputDir);

        foreach (string inputPath in inputPaths)
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Build output path with .gif extension
            string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".gif";
            string outputPath = Path.Combine(outputDir, outputFileName);

            // Ensure the directory for the output file exists (unconditional)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Measure conversion time
            Stopwatch sw = Stopwatch.StartNew();

            // Load WebP image and save as GIF
            using (WebPImage webpImage = new WebPImage(inputPath))
            {
                // Save using GIF options
                webpImage.Save(outputPath, new GifOptions());
            }

            sw.Stop();

            // Log performance metrics
            Console.WriteLine($"Converted '{inputPath}' to '{outputPath}' in {sw.ElapsedMilliseconds} ms.");
        }
    }
}