// HOW-TO: Batch Convert Animated GIFs to WebP While Preserving Frame Order in C# (Aspose.Imaging for .NET)
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

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the GIF (including all animation frames)
                using (Image image = Image.Load(inputPath))
                {
                    // WebPOptions – default settings retain animation frame order
                    var webpOptions = new WebPOptions
                    {
                        // Example settings (can be adjusted as needed)
                        Lossless = false,
                        Quality = 80
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
 * 1. When you need to shrink a library of animated GIF advertisements for faster website loading by converting them to WebP while keeping the original animation sequence.
 * 2. When a mobile app must display user‑generated animated stickers and you want to reduce file size by batch converting GIFs to animated WebP in C#.
 * 3. When an e‑learning platform wants to archive lecture animations and requires converting multiple GIF lectures to WebP without losing frame order using Aspose.Imaging.
 * 4. When a game developer prepares texture atlases that include animated GIFs and needs to batch convert them to WebP for better compression and consistent playback order.
 * 5. When a digital marketing agency automates the preparation of social‑media assets, converting dozens of GIF promos to WebP while preserving animation timing via a C# script.
 */
