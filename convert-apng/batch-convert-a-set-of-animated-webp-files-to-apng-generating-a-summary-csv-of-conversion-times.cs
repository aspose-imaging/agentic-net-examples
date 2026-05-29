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
            string inputDirectory = @"C:\WebpInput";
            string outputDirectory = @"C:\ApngOutput";
            string csvPath = Path.Combine(outputDirectory, "summary.csv");

            // Ensure output directory exists for CSV and images
            Directory.CreateDirectory(outputDirectory);

            // Prepare CSV writer
            using (var csvWriter = new StreamWriter(csvPath, false))
            {
                csvWriter.WriteLine("FileName,ConversionTimeMs");

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

                    // Determine output file path (same name with .png extension)
                    string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".png";
                    string outputPath = Path.Combine(outputDirectory, outputFileName);

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Measure conversion time
                    Stopwatch sw = Stopwatch.StartNew();

                    // Load the animated WebP image and save as APNG
                    using (Image image = Image.Load(inputPath))
                    {
                        image.Save(outputPath, new ApngOptions());
                    }

                    sw.Stop();

                    // Write result to CSV
                    csvWriter.WriteLine($"{Path.GetFileName(inputPath)},{sw.ElapsedMilliseconds}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}