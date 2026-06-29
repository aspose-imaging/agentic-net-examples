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
            string outputPath = "output\\animation.png";

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
                // Save as APNG preserving original timing
                image.Save(outputPath, new ApngOptions());
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
 * 1. When a developer needs to convert animated WebP graphics from a mobile app into APNG for cross‑browser compatibility while preserving the original frame timing.
 * 2. When a C# backend service must transform user‑uploaded animated WebP stickers into APNG files for use in a web‑based chat application that only supports PNG animation.
 * 3. When an image‑processing pipeline requires batch conversion of animated WebP advertisements to APNG to ensure consistent playback speed on legacy browsers.
 * 4. When a game developer wants to replace WebP sprite animations with APNG assets in Unity while keeping the exact animation delays for smooth motion.
 * 5. When a content management system needs to generate APNG previews from animated WebP uploads so that the preview animation matches the source timing.
 */