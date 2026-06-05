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

            // Process every GIF file in the input directory
            foreach (var inputPath in Directory.GetFiles(inputDir, "*.gif"))
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output file path
                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileName + "_compressed.gif");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the GIF image (preserves animation frames and order)
                using (Image image = Image.Load(inputPath))
                {
                    // Configure lossy compression options
                    var options = new GifOptions
                    {
                        MaxDiff = 80 // recommended value for effective lossy compression
                    };

                    // Save the compressed GIF
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
 * 1. When a developer must shrink a large collection of animated GIFs for faster website delivery, applying lossy compression with Aspose.Imaging while preserving each animation’s frame order.
 * 2. When an e‑commerce platform needs to automatically compress product GIFs stored in a folder to meet email attachment size limits without breaking the animation sequence.
 * 3. When a mobile app backend processes user‑uploaded GIF stickers, using C# file I/O and GifOptions.MaxDiff to reduce bandwidth usage while keeping the original motion intact.
 * 4. When a digital marketing tool batch‑optimizes campaign GIF assets on a scheduled job, ensuring the compressed files retain their original timing and frame hierarchy.
 * 5. When a game development pipeline compresses sprite animation GIFs before publishing, leveraging Aspose.Imaging’s lossy settings to lower file size while maintaining the correct frame playback order.
 */