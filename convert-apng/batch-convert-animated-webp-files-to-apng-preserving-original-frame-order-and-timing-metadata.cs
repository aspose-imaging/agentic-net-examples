using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDir = @"C:\InputWebp";
            string outputDir = @"C:\OutputApng";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            // Get all animated WEBP files in the input directory
            string[] inputFiles = Directory.GetFiles(inputDir, "*.webp");

            foreach (string inputPath in inputFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Build the output file path with .png extension (APNG)
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileNameWithoutExt + ".png");

                // Ensure the output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the animated WEBP and save it as APNG, preserving frames and timing
                using (Image image = Image.Load(inputPath))
                {
                    image.Save(outputPath, new ApngOptions());
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}