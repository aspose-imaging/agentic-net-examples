using System;
using System.IO;
using System.Diagnostics;
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

            // Get all animated WEBP files
            string[] inputFiles = Directory.GetFiles(inputDirectory, "*.webp");

            // Open CSV writer
            using (var csvWriter = new StreamWriter(csvPath))
            {
                // Write CSV header
                csvWriter.WriteLine("InputFile,OutputFile,ConversionTimeMs");

                foreach (string inputPath in inputFiles)
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

                    // Measure conversion time
                    var stopwatch = Stopwatch.StartNew();

                    // Load WEBP and save as APNG
                    using (Image image = Image.Load(inputPath))
                    {
                        image.Save(outputPath, new ApngOptions());
                    }

                    stopwatch.Stop();

                    // Write result to CSV
                    csvWriter.WriteLine($"{inputPath},{outputPath},{stopwatch.ElapsedMilliseconds}");
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
 * 1. When a developer needs to batch‑convert animated WEBP files to APNG for web animation compatibility while logging each file’s conversion time in a CSV for performance analysis.
 * 2. When a game studio wants to automate the migration of sprite animations from WEBP to APNG across multiple folders using C# and Aspose.Imaging, generating a CSV summary of processing durations.
 * 3. When an e‑learning platform must replace legacy animated WEBP illustrations with APNG for broader browser support and keep a CSV record of each conversion’s speed for QA auditing.
 * 4. When a CI/CD pipeline includes a step that validates image assets by converting all animated WEBP assets to APNG and outputs a CSV of conversion times to detect regressions.
 * 5. When a digital marketing team needs to bulk‑process promotional animated WEBP assets into APNG for email campaigns, using C# code that also produces a CSV log of how long each conversion took.
 */