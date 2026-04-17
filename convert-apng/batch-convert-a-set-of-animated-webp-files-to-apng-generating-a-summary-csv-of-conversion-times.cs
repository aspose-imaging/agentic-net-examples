using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output directories
        string baseDir = Directory.GetCurrentDirectory();
        string inputDirectory = Path.Combine(baseDir, "Input");
        string outputDirectory = Path.Combine(baseDir, "Output");

        // Ensure directories exist
        if (!Directory.Exists(inputDirectory))
        {
            Directory.CreateDirectory(inputDirectory);
            Console.WriteLine($"Input directory created at: {inputDirectory}. Add .webp files and rerun.");
            return;
        }

        if (!Directory.Exists(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }

        // Get all WebP files in the input directory
        string[] files = Directory.GetFiles(inputDirectory, "*.webp");

        // Prepare CSV lines
        List<string> csvLines = new List<string>();
        csvLines.Add("InputFile,OutputFile,DurationMs");

        foreach (string inputPath in files)
        {
            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".png";
            string outputPath = Path.Combine(outputDirectory, outputFileName);

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Measure conversion time
            DateTime startTime = DateTime.Now;

            using (Image image = Image.Load(inputPath))
            {
                image.Save(outputPath, new ApngOptions());
            }

            double durationMs = (DateTime.Now - startTime).TotalMilliseconds;

            // Add entry to CSV
            csvLines.Add($"{Path.GetFileName(inputPath)},{outputFileName},{durationMs:F2}");
        }

        // Write summary CSV
        string csvPath = Path.Combine(outputDirectory, "summary.csv");
        Directory.CreateDirectory(Path.GetDirectoryName(csvPath));
        File.WriteAllLines(csvPath, csvLines);
    }
}