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
            // Hardcoded input and output directories
            string inputDir = @"C:\WebpInput";
            string outputDir = @"C:\ApngOutput";
            string csvPath = Path.Combine(outputDir, "summary.csv");

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);
            // Ensure directory for CSV exists
            Directory.CreateDirectory(Path.GetDirectoryName(csvPath));

            // Prepare CSV header
            List<string> csvLines = new List<string>();
            csvLines.Add("FileName,ConversionTimeMs");

            // Process each WEBP file in the input directory
            foreach (string inputPath in Directory.GetFiles(inputDir, "*.webp"))
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileNameWithoutExt + ".png"); // APNG saved as .png

                // Ensure output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                Stopwatch sw = Stopwatch.StartNew();

                // Load WEBP and save as APNG using Aspose.Imaging
                using (Image image = Image.Load(inputPath))
                {
                    image.Save(outputPath, new ApngOptions());
                }

                sw.Stop();

                // Record conversion time
                csvLines.Add($"{fileNameWithoutExt},{sw.ElapsedMilliseconds}");
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