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
            string inputDirectory = @"C:\InputWebp";
            string outputDirectory = @"C:\OutputApng";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Get all animated WEBP files in the input directory
            string[] webpFiles = Directory.GetFiles(inputDirectory, "*.webp");

            foreach (string inputPath in webpFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output file path (same name with .png extension)
                string outputPath = Path.Combine(outputDirectory,
                    Path.GetFileNameWithoutExtension(inputPath) + ".png");

                // Ensure the output directory exists (unconditional as required)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the animated WEBP image and save it as APNG preserving frames and timing
                using (Image image = Image.Load(inputPath))
                {
                    // ApngOptions without custom settings preserves original frame order and timing
                    image.Save(outputPath, new ApngOptions());
                }

                Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}