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

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Process each GIF file in the input directory
            foreach (string inputPath in Directory.GetFiles(inputDirectory, "*.gif"))
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Build the output WebP file path
                string outputPath = Path.Combine(outputDirectory,
                    Path.GetFileNameWithoutExtension(inputPath) + ".webp");

                // Ensure the output directory exists (unconditional as required)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the GIF image (preserves animation frames)
                using (Image image = Image.Load(inputPath))
                {
                    // Configure WebP options for lossless compression
                    var webpOptions = new WebPOptions
                    {
                        Lossless = true,
                        Quality = 100 // Quality is ignored for lossless but set for completeness
                    };

                    // Save as animated WebP
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

/*
 * Real-World Use Cases:
 * 1. When a developer needs to reduce page load times by converting a folder of animated GIF advertisements into lossless WebP files for faster web delivery.
 * 2. When an e‑commerce platform wants to preserve product animation frames while migrating legacy GIF assets to WebP to improve SEO image performance.
 * 3. When a mobile app team automates the batch conversion of user‑generated GIF stickers into lossless WebP to save storage space without losing animation quality.
 * 4. When a digital marketing agency prepares a large collection of animated GIF banners for email campaigns and requires lossless WebP conversion using C# and Aspose.Imaging.
 * 5. When a game developer needs to convert animated GIF UI elements into lossless WebP sprites in bulk to maintain visual fidelity while optimizing asset size.
 */