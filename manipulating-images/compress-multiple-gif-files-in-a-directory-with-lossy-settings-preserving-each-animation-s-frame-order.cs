// HOW-TO: Batch Compress Animated GIFs with Lossy Settings in C# (Aspose.Imaging for .NET)
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
            // Hard‑coded input and output directories
            string inputDir = @"C:\InputGifs";
            string outputDir = @"C:\OutputGifs";

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

                // Build the corresponding output file path
                string fileName = Path.GetFileName(inputPath);
                string outputPath = Path.Combine(outputDir, fileName);

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the GIF image (preserves animation frames and order)
                using (Image image = Image.Load(inputPath))
                {
                    // Configure lossy compression options
                    var saveOptions = new GifOptions
                    {
                        MaxDiff = 80 // recommended value for effective lossy compression
                    };

                    // Save the compressed GIF to the output path
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
 * 1. When you need to reduce the file size of a large collection of animated GIFs for faster web page loading while keeping the original frame sequence intact.
 * 2. When an e‑commerce platform must automatically optimize product demo GIFs stored in a folder before uploading them to a CDN.
 * 3. When a social‑media scheduling tool has to batch‑process user‑submitted GIFs to meet size limits without breaking the animation.
 * 4. When a desktop application generates daily GIF reports and you want to compress them on the fly to save disk space.
 * 5. When a game developer wants to shrink animated UI icons in bulk while preserving their animation timing using C# and Aspose.Imaging.
 */
