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
            string outputDir = @"C:\OutputGifs";

            // Ensure the output base directory exists
            Directory.CreateDirectory(outputDir);

            // Get all GIF files in the input directory
            string[] gifFiles = Directory.GetFiles(inputDir, "*.gif");

            foreach (string inputPath in gifFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output path, preserving the original file name
                string outputPath = Path.Combine(outputDir, Path.GetFileName(inputPath));

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the GIF image
                using (Image image = Image.Load(inputPath))
                {
                    // Set lossy compression options
                    var saveOptions = new GifOptions
                    {
                        MaxDiff = 80 // recommended lossy level
                    };

                    // Save the image with lossy compression, preserving animation frames
                    image.Save(outputPath, saveOptions);
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
 * 1. When a web developer needs to batch‑optimize animated GIF advertisements for faster page loads, they can use this C# code with Aspose.Imaging to apply lossy compression while keeping each frame’s order intact.
 * 2. When an e‑mail marketing system must shrink a folder of promotional GIFs to stay under attachment size limits, the program compresses all files in one pass without breaking the animation sequence.
 * 3. When a mobile app prepares user‑generated GIF stickers for upload, the code reduces file size with a configurable MaxDiff value, ensuring the animated stickers remain smooth on low‑bandwidth connections.
 * 4. When a digital asset manager wants to archive legacy animated GIFs on a server while preserving their original playback order, this script processes the entire directory and saves the compressed versions to a separate folder.
 * 5. When a CDN operator needs to pre‑compress a batch of animated GIFs before distribution to improve cache efficiency, the C# solution applies lossy settings across the directory and retains the correct frame ordering for end users.
 */