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
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output path with .webp extension
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".webp";
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the GIF image (may contain multiple frames)
                using (Image image = Image.Load(inputPath))
                {
                    // Configure WebP options (preserve animation frames)
                    var webpOptions = new WebPOptions
                    {
                        // Example settings; adjust as needed
                        Lossless = false,
                        Quality = 80,
                        // Ensure all pages (frames) are exported
                        MultiPageOptions = null
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
 * 1. When a web developer needs to reduce page load time by converting a folder of animated GIF advertisements into smaller animated WebP files while preserving the original frame sequence.
 * 2. When an e‑learning platform wants to batch‑process course illustration GIFs into high‑quality WebP assets for mobile apps using C# and Aspose.Imaging.
 * 3. When a digital marketing agency automates the migration of legacy GIF banners to WebP to improve SEO and support modern browsers without losing animation order.
 * 4. When a game studio prepares sprite animations stored as GIFs for inclusion in a Unity project by converting them to animated WebP with consistent frame timing via .NET code.
 * 5. When a content management system integrates a scheduled job that scans an upload directory, converts every new animated GIF to lossily compressed WebP, and saves the results while keeping the original animation frames intact.
 */