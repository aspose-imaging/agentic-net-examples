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
            string inputDir = "Input";
            string outputDir = "Output";

            string[] epsFiles = Directory.GetFiles(inputDir, "*.eps");
            var logLines = new List<string>();

            foreach (var inputPath in epsFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileName + ".png");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                DateTime start = DateTime.Now;
                using (Image image = Image.Load(inputPath))
                {
                    image.Save(outputPath, new PngOptions());
                }
                TimeSpan duration = DateTime.Now - start;

                Console.WriteLine($"{inputPath} conversion took {duration.TotalMilliseconds} ms");
                logLines.Add($"{inputPath},{duration.TotalMilliseconds}");
            }

            string logPath = Path.Combine(outputDir, "conversion_times.csv");
            Directory.CreateDirectory(Path.GetDirectoryName(logPath));
            File.WriteAllLines(logPath, logLines);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a print shop needs to batch‑convert customer EPS artwork to PNG thumbnails and track how long each conversion takes to ensure the rendering pipeline meets service‑level agreements.
 * 2. When a web‑application processes uploaded EPS logos into PNGs for display and records conversion times in a CSV to identify performance bottlenecks on the server.
 * 3. When a CI/CD pipeline validates that a new version of Aspose.Imaging does not degrade EPS‑to‑PNG conversion speed by logging the duration of each file conversion.
 * 4. When a digital asset management system migrates legacy EPS files to PNG format and stores per‑file conversion durations for audit and capacity‑planning reports.
 * 5. When a developer builds a monitoring tool that watches an input folder, converts incoming EPS files to PNG, and writes the elapsed milliseconds to a log for real‑time performance analytics.
 */