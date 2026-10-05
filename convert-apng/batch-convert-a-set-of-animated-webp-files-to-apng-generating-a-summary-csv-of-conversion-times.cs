// HOW-TO: Batch Convert Animated WebP to APNG with Timing CSV in C# (Aspose.Imaging for .NET)
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.ImageOptions;

namespace BatchWebpToApng
{
    class Program
    {
        static void Main()
        {
            // Hardcoded paths
            string inputDirectory = "input";
            string outputDirectory = "output";
            string csvPath = Path.Combine(outputDirectory, "summary.csv");

            try
            {
                // Ensure output directories exist
                Directory.CreateDirectory(outputDirectory);
                Directory.CreateDirectory(Path.GetDirectoryName(csvPath));

                // Get all WebP files in the input directory
                string[] webpFiles = Directory.GetFiles(inputDirectory, "*.webp");

                var csvLines = new List<string>();
                csvLines.Add("FileName,ConversionTimeMs");

                foreach (string inputPath in webpFiles)
                {
                    // Input file existence check (exact pattern required)
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                    string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".png");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    var stopwatch = Stopwatch.StartNew();

                    // Load the animated WebP image
                    using (WebPImage webpImage = (WebPImage)Image.Load(inputPath))
                    {
                        // Save as APNG using ApngOptions
                        var apngOptions = new ApngOptions();
                        webpImage.Save(outputPath, apngOptions);
                    }

                    stopwatch.Stop();
                    csvLines.Add($"{fileNameWithoutExt},{stopwatch.ElapsedMilliseconds}");
                }

                // Write summary CSV
                File.WriteAllLines(csvPath, csvLines);
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
 * 1. When you need to migrate a library of animated WebP stickers to APNG for better browser compatibility while tracking conversion performance.
 * 2. When an e‑commerce platform wants to generate APNG product animations from existing WebP assets and log processing times for monitoring.
 * 3. When a game developer batch‑converts animated WebP sprites to APNG for use in Unity and needs a CSV report to benchmark the conversion speed.
 * 4. When a content management system automates the conversion of user‑uploaded animated WebP files to APNG and records each file’s conversion duration for analytics.
 * 5. When a digital marketing team processes large sets of animated WebP ads into APNG format and requires a summary file to audit processing efficiency.
 */
