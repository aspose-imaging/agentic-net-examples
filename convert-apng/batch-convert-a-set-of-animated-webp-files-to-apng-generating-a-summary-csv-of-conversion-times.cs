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
            // Hardcoded input and output directories
            string inputFolder = @"C:\InputWebp";
            string outputFolder = @"C:\OutputApng";
            string csvPath = Path.Combine(outputFolder, "summary.csv");

            // Ensure output directory exists
            Directory.CreateDirectory(outputFolder);

            // Write CSV header (overwrite if exists)
            using (var csvWriter = new StreamWriter(csvPath, false))
            {
                csvWriter.WriteLine("InputFile,OutputFile,ConversionTimeMs");
            }

            // Get all animated WEBP files
            string[] inputFiles = Directory.GetFiles(inputFolder, "*.webp");

            foreach (string inputPath in inputFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output file path (append .png to keep original name)
                string outputPath = Path.Combine(outputFolder, Path.GetFileName(inputPath) + ".png");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Measure conversion time
                Stopwatch sw = Stopwatch.StartNew();

                // Load WEBP and save as APNG
                using (Image image = Image.Load(inputPath))
                {
                    image.Save(outputPath, new ApngOptions());
                }

                sw.Stop();

                // Append result to CSV
                using (var csvWriter = new StreamWriter(csvPath, true))
                {
                    csvWriter.WriteLine($"{inputPath},{outputPath},{sw.ElapsedMilliseconds}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}