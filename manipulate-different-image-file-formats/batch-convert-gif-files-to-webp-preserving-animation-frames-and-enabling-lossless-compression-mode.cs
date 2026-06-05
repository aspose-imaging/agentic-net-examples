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

                // Build the output file path with .webp extension
                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".webp");

                // Ensure the output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the GIF image (preserves animation frames)
                using (Image image = Image.Load(inputPath))
                {
                    // Configure WebP options for lossless compression
                    var webpOptions = new WebPOptions
                    {
                        Lossless = true,
                        Quality = 100 // Maximum quality for lossless mode
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
 * 1. When a web developer wants to reduce page load time by converting a folder of animated GIFs to lossless WebP while keeping all animation frames intact.
 * 2. When a mobile app team needs to prepare high‑quality animated assets for Android devices by batch processing GIFs into lossless WebP using C# and Aspose.Imaging.
 * 3. When an e‑commerce platform must optimize product demo animations for SEO‑friendly image formats, converting multiple GIF files to animated WebP without quality loss.
 * 4. When a digital marketing agency automates the migration of legacy GIF banners to modern WebP format to improve compression efficiency while preserving animation.
 * 5. When a game developer scripts a build pipeline that transforms all GIF sprites in a resource folder into lossless animated WebP files for faster runtime loading.
 */