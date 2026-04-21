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
            string inputDir = @"C:\InputGifs";
            string outputDir = @"C:\OutputWebp";

            // Ensure the base output directory exists
            Directory.CreateDirectory(outputDir);

            // Process each GIF file in the input directory
            foreach (string inputPath in Directory.GetFiles(inputDir, "*.gif"))
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the corresponding output WebP file path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileNameWithoutExt + ".webp");

                // Ensure the output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the GIF (including all animation frames)
                using (Image image = Image.Load(inputPath))
                {
                    // Configure WebP options – keep all frames, set desired quality
                    var webpOptions = new WebPOptions
                    {
                        // MultiPageOptions left null to include all frames
                        Lossless = false,
                        Quality = 80
                    };

                    // Save as animated WebP, preserving frame order
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