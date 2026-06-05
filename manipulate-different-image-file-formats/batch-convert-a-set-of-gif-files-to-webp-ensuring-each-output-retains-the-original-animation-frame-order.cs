using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.*");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".webp");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    var options = new WebPOptions();
                    image.Save(outputPath, options);
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
 * 1. When a web developer needs to shrink page load times by batch converting animated GIF banners to WebP while preserving the original frame order.
 * 2. When an e‑commerce site wants to optimize product showcase animations by turning many user‑uploaded GIFs into smaller WebP files without changing the animation sequence.
 * 3. When a digital‑marketing agency automates the preparation of social‑media ad assets, converting multiple GIF animations to WebP to meet size limits while keeping frame order intact.
 * 4. When a game studio replaces legacy GIF UI animations with WebP equivalents to improve rendering performance and retain the exact animation timing.
 * 5. When a content‑management system migrates archived animated GIFs to WebP to save storage space and ensure the animations play in the same sequence for viewers.
 */