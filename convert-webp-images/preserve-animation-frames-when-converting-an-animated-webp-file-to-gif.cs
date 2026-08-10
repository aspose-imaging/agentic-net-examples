// HOW-TO: Convert Animated WebP to GIF While Preserving All Frames in C# (Aspose.Imaging for .NET)
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
            string inputPath = @"C:\temp\animation_input.webp";
            string outputPath = @"C:\temp\animation_output.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the animated WebP image (preserves all frames)
            using (Image image = Image.Load(inputPath))
            {
                // Configure GIF options to keep all frames
                var gifOptions = new GifOptions
                {
                    // FullFrame ensures each frame is saved as a full image rather than a delta
                    FullFrame = true
                };

                // Save as animated GIF, preserving animation frames
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
 * 1. When you need to display an animated WebP banner on a website that only supports GIF, you can convert it while keeping the animation intact.
 * 2. When exporting a series of WebP frames from a mobile app to a GIF for inclusion in an email newsletter, preserving each frame ensures the animation looks correct.
 * 3. When migrating legacy assets from a WebP‑based design system to a GIF‑compatible platform, you must retain all frames to avoid losing motion details.
 * 4. When generating GIF previews of user‑uploaded animated WebP files in a C# backend, preserving frames provides an accurate representation of the original animation.
 * 5. When creating cross‑platform game sprites that require GIF format, converting animated WebP while keeping every frame guarantees consistent animation across devices.
 */
