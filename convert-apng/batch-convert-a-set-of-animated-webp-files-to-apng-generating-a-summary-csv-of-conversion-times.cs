using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input WebP files
        string[] inputFiles = {
            "input/animation1.webp",
            "input/animation2.webp",
            "input/animation3.webp"
        };

        // Output directory for APNG files
        string outputDir = "output";

        // Ensure the output directory exists
        Directory.CreateDirectory(outputDir);

        // Prepare CSV summary
        string csvPath = Path.Combine(outputDir, "conversion_summary.csv");
        Directory.CreateDirectory(Path.GetDirectoryName(csvPath));
        List<string> csvLines = new List<string>();
        csvLines.Add("InputFile,OutputFile,ConversionTimeMs");

        foreach (string inputPath in inputFiles)
        {
            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Determine output file path
            string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".png";
            string outputPath = Path.Combine(outputDir, outputFileName);

            // Ensure the output directory exists (redundant but follows rule)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Measure conversion time
            Stopwatch sw = Stopwatch.StartNew();

            using (Image image = Image.Load(inputPath))
            {
                // Convert animated WebP to APNG
                image.Save(outputPath, new ApngOptions());
            }

            sw.Stop();

            // Record result in CSV
            csvLines.Add($"{inputPath},{outputPath},{sw.ElapsedMilliseconds}");
        }

        // Write CSV summary
        File.WriteAllLines(csvPath, csvLines);
    }
}