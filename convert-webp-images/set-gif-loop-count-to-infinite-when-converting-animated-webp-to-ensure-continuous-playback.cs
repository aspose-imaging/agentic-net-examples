using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.webp";
        string outputPath = @"C:\temp\output.gif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the animated WebP image
            using (Image image = Image.Load(inputPath))
            {
                // Configure GIF options with infinite loop count (0)
                var gifOptions = new GifOptions
                {
                    LoopsCount = 0 // 0 indicates infinite looping
                };

                // Save as GIF with the specified options
                image.Save(outputPath, gifOptions);
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
 * 1. When creating an animated GIF banner for a website that must loop forever after converting from an animated WebP file using C# and Aspose.Imaging.
 * 2. When developing a desktop application that generates continuous‑play GIF stickers from user‑uploaded animated WebP images, requiring an infinite LoopsCount.
 * 3. When building an automated batch conversion tool that processes a folder of animated WebP assets into GIFs for digital signage, ensuring each GIF repeats without end.
 * 4. When implementing a C# service that converts animated WebP advertisements to GIF format for email newsletters, and the GIF must loop infinitely to meet marketing guidelines.
 * 5. When migrating legacy animation assets from WebP to GIF for a mobile game, and the game engine expects GIFs with an infinite loop count for seamless background animations.
 */