// HOW-TO: Batch Convert Animated WebP to APNG with Timing CSV in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
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

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);
            Directory.CreateDirectory(Path.GetDirectoryName(csvPath));

            // Prepare CSV header
            List<string> csvLines = new List<string>();
            csvLines.Add("File,TimeMs");

            // Get all animated WEBP files
            string[] inputFiles = Directory.GetFiles(inputDirectory, "*.webp");

            foreach (string inputPath in inputFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".png");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                Stopwatch sw = Stopwatch.StartNew();

                // Load WEBP and save as APNG
                using (Image image = Image.Load(inputPath))
                {
                    image.Save(outputPath, new ApngOptions());
                }

                sw.Stop();

                // Record conversion time
                csvLines.Add($"{fileNameWithoutExt},{sw.ElapsedMilliseconds}");
                Console.WriteLine($"Converted {inputPath} to {outputPath} in {sw.ElapsedMilliseconds} ms");
            }

            // Write summary CSV
            File.WriteAllLines(csvPath, csvLines);
            Console.WriteLine($"Summary CSV written to {csvPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to convert a large collection of animated WebP advertisements into APNG files for web browsers that only support PNG animation.
 * 2. When you want to automate the migration of animated assets from a mobile app's WebP format to APNG while tracking how long each conversion takes.
 * 3. When you are benchmarking image processing performance in a .NET service that processes animated WebP files and need a CSV log of conversion times.
 * 4. When you must generate APNG sprites from existing animated WebP graphics for inclusion in a game engine that requires PNG sequences.
 * 5. When you are building a CI pipeline that validates that all animated WebP resources are correctly transformed to APNG and records the processing duration for reporting.
 */
