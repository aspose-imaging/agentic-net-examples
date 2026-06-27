using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputDirectory = @"C:\InputGifs";
        string outputDirectory = @"C:\OutputWebp";

        try
        {
            // Get all GIF files in the input directory
            string[] gifFiles = Directory.GetFiles(inputDirectory, "*.gif");

            foreach (string inputPath in gifFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build output path with .webp extension
                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".webp");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the GIF image (may contain multiple frames)
                using (Image image = Image.Load(inputPath))
                {
                    // Configure WebP options to preserve animation frames
                    var webpOptions = new WebPOptions
                    {
                        // Include all pages/frames; null means no page range restriction
                        MultiPageOptions = null,
                        // Example settings – adjust as needed
                        Lossless = false,
                        Quality = 80
                    };

                    // Save as animated WebP
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

/*
 * Real-World Use Cases:
 * 1. When a developer needs to migrate a legacy collection of animated GIF advertisements to modern, smaller WebP files for faster web page load times while preserving the original animation sequence.
 * 2. When a mobile app team wants to batch convert user‑uploaded GIF stickers into animated WebP to reduce bandwidth usage without losing frame order.
 * 3. When an e‑learning platform must transform a library of animated tutorial GIFs into WebP for compatibility with browsers that support animated WebP, ensuring each step appears in the correct order.
 * 4. When a digital marketing system automatically processes daily GIF email campaign assets and stores them as WebP to improve email size limits while keeping the animation intact.
 * 5. When a game developer prepares sprite animations stored as GIFs for use in a WebGL game, converting them to animated WebP to maintain frame timing and order while optimizing file size.
 */