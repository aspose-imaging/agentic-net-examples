// HOW-TO: Log Timestamps While Converting Multiple WebP Files to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string[] inputPaths = {
                @"c:\temp\test1.webp",
                @"c:\temp\test2.webp"
            };

            string[] outputPaths = {
                @"c:\temp\test1.output.png",
                @"c:\temp\test2.output.png"
            };

            for (int i = 0; i < inputPaths.Length; i++)
            {
                string inputPath = inputPaths[i];
                string outputPath = outputPaths[i];

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Log start timestamp
                Console.WriteLine($"Processing started: {inputPath} at {DateTime.Now:O}");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load WebP image and save as PNG
                using (WebPImage webPImage = new WebPImage(inputPath))
                {
                    webPImage.Save(outputPath, new PngOptions());
                }

                // Log end timestamp
                Console.WriteLine($"Processing completed: {outputPath} at {DateTime.Now:O}");
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
 * 1. When you need to batch‑convert WebP images to PNG and keep a start‑and‑end log for each file to troubleshoot performance issues.
 * 2. When your application must verify that source WebP files exist before processing to avoid runtime errors.
 * 3. When you want to automatically create missing output directories while converting images in a C# service.
 * 4. When you require detailed timestamps in the console to monitor how long each WebP‑to‑PNG conversion takes.
 * 5. When you are using Aspose.Imaging for .NET to handle WebP files and need simple error handling that reports conversion failures.
 */
