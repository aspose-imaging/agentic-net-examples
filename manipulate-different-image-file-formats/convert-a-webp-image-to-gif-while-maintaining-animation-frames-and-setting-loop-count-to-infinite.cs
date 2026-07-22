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
            // Hardcoded input and output paths
            string inputPath = "input.webp";
            string outputPath = "output/output.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the animated WebP image
            using (Image image = Image.Load(inputPath))
            {
                // Save as GIF while preserving all frames (FullFrame = true)
                var gifOptions = new GifOptions
                {
                    FullFrame = true
                    // Loop count defaults to infinite when not specified
                };
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
 * 1. When a developer needs to convert animated WebP advertisements into GIFs for email newsletters that only support GIF animation.
 * 2. When a developer wants to preserve all animation frames while changing the file format from WebP to GIF for compatibility with legacy browsers.
 * 3. When a developer must generate infinite‑looping GIFs from user‑uploaded WebP stickers for a chat application.
 * 4. When a developer is building a batch‑processing tool that reads WebP assets and outputs GIFs with full‑frame rendering for use in presentation software.
 * 5. When a developer needs to ensure the output directory exists and handle missing input files while converting animated WebP to GIF in a C# console utility.
 */