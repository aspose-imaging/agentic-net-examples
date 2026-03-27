using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output directories (relative paths)
        string inputDirectory = "Input";
        string outputDirectory = "Output";

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

            // Prepare the output path with .webp extension
            string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".webp";
            string outputPath = Path.Combine(outputDirectory, outputFileName);

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the GIF image (including animation frames)
            using (Image image = Image.Load(inputPath))
            {
                // Configure WebP options for lossless compression and animation preservation
                var webpOptions = new WebPOptions
                {
                    Lossless = true,
                    MultiPageOptions = null // Preserve all frames as animation
                };

                // Save as animated WebP
                image.Save(outputPath, webpOptions);
            }
        }
    }
}