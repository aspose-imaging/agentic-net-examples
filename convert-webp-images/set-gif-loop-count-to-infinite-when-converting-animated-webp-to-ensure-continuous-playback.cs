// HOW-TO: Convert Animated WebP to GIF with Infinite Loop in C# (Aspose.Imaging for .NET)
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

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the animated WebP image
            using (Image image = Image.Load(inputPath))
            {
                // Configure GIF options with infinite looping (0 means infinite)
                var gifOptions = new GifOptions
                {
                    LoopsCount = 0
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
 * 1. When you need to embed an animated WebP banner on a website that only supports GIFs and must play continuously.
 * 2. When creating a slideshow of product demos where the original animation is in WebP but the target platform requires looping GIFs.
 * 3. When exporting frame‑by‑frame animations from a design tool as WebP and need to generate GIFs that never stop for digital signage.
 * 4. When building a C# utility that converts user‑uploaded animated WebP files to GIFs for email newsletters that require infinite playback.
 * 5. When automating the preparation of animated assets for legacy mobile apps that only understand GIF format and need endless looping.
 */
