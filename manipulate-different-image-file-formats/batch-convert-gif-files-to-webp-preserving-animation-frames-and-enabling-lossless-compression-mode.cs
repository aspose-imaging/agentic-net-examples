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
            string inputDirectory = @"C:\InputGifs";
            string outputDirectory = @"C:\OutputWebp";

            // Get all GIF files in the input directory
            string[] gifFiles = Directory.GetFiles(inputDirectory, "*.gif");

            foreach (string inputPath in gifFiles)
            {
                // Verify that the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output file path with .webp extension
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".webp";
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the GIF (including animation frames) and save as lossless WebP
                using (Image image = Image.Load(inputPath))
                {
                    var webpOptions = new WebPOptions
                    {
                        Lossless = true,
                        Quality = 100 // Maximum quality for lossless compression
                    };

                    image.Save(outputPath, webpOptions);
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