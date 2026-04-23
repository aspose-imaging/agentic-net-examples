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
            string inputDirectory = @"C:\Images\Input";
            string outputDirectory = @"C:\Images\Output";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Get all BMP files in the input directory
            string[] bmpFiles = Directory.GetFiles(inputDirectory, "*.bmp", SearchOption.TopDirectoryOnly);

            foreach (string inputPath in bmpFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine the output file path with .webp extension
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".webp");

                // Ensure the output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the BMP image
                using (Image image = Image.Load(inputPath))
                {
                    // Set up lossless WebP options
                    var webpOptions = new WebPOptions
                    {
                        Lossless = true
                    };

                    // Save as WebP
                    image.Save(outputPath, webpOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}