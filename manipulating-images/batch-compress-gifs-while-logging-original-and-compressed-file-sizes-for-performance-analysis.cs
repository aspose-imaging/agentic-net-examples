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
            string inputFolder = @"C:\Images\Input";
            string outputFolder = @"C:\Images\Output";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputFolder);

            // Get all GIF files in the input folder
            string[] gifFiles = Directory.GetFiles(inputFolder, "*.gif");

            foreach (string inputPath in gifFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the GIF image
                using (Image image = Image.Load(inputPath))
                {
                    // Prepare lossy GIF save options
                    GifOptions saveOptions = new GifOptions
                    {
                        // Recommended value for optimal lossy compression
                        MaxDiff = 80,
                        // Optional: enable palette correction for better quality
                        DoPaletteCorrection = true
                    };

                    // Determine the output file path
                    string outputPath = Path.Combine(outputFolder, Path.GetFileName(inputPath));

                    // Ensure the output directory exists (unconditional as required)
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the compressed GIF
                    image.Save(outputPath, saveOptions);
                }

                // Log original and compressed file sizes
                long originalSize = new FileInfo(inputPath).Length;
                long compressedSize = new FileInfo(Path.Combine(outputFolder, Path.GetFileName(inputPath))).Length;
                Console.WriteLine($"File: {Path.GetFileName(inputPath)} | Original: {originalSize} bytes | Compressed: {compressedSize} bytes");
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
 * 1. When a web developer needs to reduce the bandwidth of animated GIF banners for a marketing campaign, they can batch compress the files and log size reductions to verify performance gains.
 * 2. When a mobile app team wants to optimize GIF assets for faster loading on low‑end devices, they can use this code to compress the images and compare original versus compressed file sizes.
 * 3. When an e‑learning platform must shrink large GIF tutorials before uploading to a content delivery network, the batch process provides automated compression and size tracking for quality control.
 * 4. When a digital archivist is preparing a collection of GIF memes for public download, they can compress the set in bulk and record size metrics to ensure the archive stays within storage limits.
 * 5. When a SaaS provider offers image‑optimization services, they can employ this routine to process client‑submitted GIFs, log the before‑and‑after sizes, and generate reports on compression efficiency.
 */