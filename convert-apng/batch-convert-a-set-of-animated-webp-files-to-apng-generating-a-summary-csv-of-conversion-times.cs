using System;
using System.IO;
using System.Diagnostics;
using System.Text;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded paths
            string inputDirectory = @"C:\InputWebp";
            string outputDirectory = @"C:\OutputApng";
            string csvPath = Path.Combine(outputDirectory, "summary.csv");

            // Ensure output directory exists for CSV
            Directory.CreateDirectory(Path.GetDirectoryName(csvPath));

            // Prepare CSV content
            var csvBuilder = new StringBuilder();
            csvBuilder.AppendLine("File,TimeMs");

            // Get all .webp files in the input directory
            string[] webpFiles = Directory.GetFiles(inputDirectory, "*.webp");

            foreach (string inputPath in webpFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output path (APNG saved as .png)
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".png";
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the animated WebP image
                using (Image image = Image.Load(inputPath))
                {
                    // Measure conversion time
                    var stopwatch = Stopwatch.StartNew();

                    // Save as APNG using default options
                    image.Save(outputPath, new ApngOptions());

                    stopwatch.Stop();
                    long elapsedMs = stopwatch.ElapsedMilliseconds;

                    // Record result in CSV
                    csvBuilder.AppendLine($"{Path.GetFileName(inputPath)},{elapsedMs}");
                }
            }

            // Write CSV summary
            File.WriteAllText(csvPath, csvBuilder.ToString());
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to migrate a library of animated WEBP assets to APNG for broader browser compatibility while tracking conversion performance.
 * 2. When an e‑learning platform wants to replace animated WEBP tutorials with APNG files and generate a CSV report of processing times for each lesson.
 * 3. When a game studio automates the conversion of sprite animations stored as WEBP into APNG spritesheets and logs the elapsed milliseconds for quality assurance.
 * 4. When a marketing team requires a C# script to batch convert promotional animated WEBP banners to APNG and produce a summary CSV for SLA monitoring.
 * 5. When a content management system needs to process user‑uploaded animated WEBP images into APNG format on the server and record conversion durations for analytics.
 */