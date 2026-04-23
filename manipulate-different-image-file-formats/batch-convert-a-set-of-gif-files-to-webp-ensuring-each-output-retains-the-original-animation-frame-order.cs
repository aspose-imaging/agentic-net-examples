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

            // Ensure the output directory exists (creates parent if needed)
            Directory.CreateDirectory(outputDirectory);

            // Get all GIF files in the input directory
            string[] gifFiles = Directory.GetFiles(inputDirectory, "*.gif");

            foreach (string inputPath in gifFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the corresponding output WebP file path
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".webp";
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                // Ensure the output directory exists (unconditional as required)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the GIF (which may contain multiple frames)
                using (Image image = Image.Load(inputPath))
                {
                    // Configure WebP options – keep all frames, default quality
                    var webpOptions = new WebPOptions
                    {
                        // Example settings; adjust as needed
                        Lossless = false,
                        Quality = 80
                    };

                    // Save as animated WebP preserving frame order
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