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
            // Hardcoded input and output directories
            string inputDir = @"C:\Images\Input\";
            string outputDir = @"C:\Images\Output\";

            // List of WebP files to process (hardcoded)
            string[] webpFiles = new string[]
            {
                "sample1.webp",
                "sample2.webp",
                "sample3.webp"
            };

            foreach (string fileName in webpFiles)
            {
                // Build full paths
                string inputPath = Path.Combine(inputDir, fileName);
                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(fileName) + ".png");

                // Log start timestamp
                Console.WriteLine($"Processing started: {fileName} at {DateTime.Now:O}");

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load WebP image and save as PNG
                using (WebPImage webPImage = new WebPImage(inputPath))
                {
                    webPImage.Save(outputPath, new PngOptions());
                }

                // Log end timestamp
                Console.WriteLine($"Processing completed: {fileName} at {DateTime.Now:O}");
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
 * 1. When a developer needs to batch‑convert a set of WebP images to PNG format while recording start and end times for each file to troubleshoot performance issues.
 * 2. When an automated image‑processing pipeline must verify the existence of source WebP files, create missing output folders, and log timestamps for audit trails.
 * 3. When integrating Aspose.Imaging for .NET into a C# console application to monitor and debug the conversion of web‑optimized images to lossless PNGs in a production environment.
 * 4. When building a scheduled task that processes a predefined list of WebP assets and requires precise timing logs to detect stalls or failures.
 * 5. When a QA engineer wants to capture detailed processing timestamps for each WebP‑to‑PNG conversion to compare against expected processing windows during regression testing.
 */