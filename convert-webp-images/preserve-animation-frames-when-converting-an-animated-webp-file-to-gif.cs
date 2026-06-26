using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "C:\\temp\\animation.webp";
        string outputPath = "C:\\temp\\animation_converted.gif";

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

            // Load the animated WebP image (multi‑page)
            using (Image image = Image.Load(inputPath))
            {
                // Prepare GIF options to preserve all frames
                var gifOptions = new GifOptions
                {
                    // FullFrame ensures each frame is saved as a full image
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
 * 1. When a web developer needs to display animated WebP content on browsers that only support GIF, they can use this code to convert and preserve all animation frames.
 * 2. When a mobile app needs to generate shareable GIFs from user‑created animated WebP stickers while keeping the original timing, the code provides a reliable C# solution.
 * 3. When an e‑learning platform wants to batch‑process animated WebP tutorials into GIFs for compatibility with older LMS viewers, this snippet ensures each frame is retained.
 * 4. When a digital marketer prepares animated email assets and must convert WebP ads to GIF without losing motion, the code handles the conversion with full‑frame preservation.
 * 5. When a game developer exports character animations as WebP and needs to create GIF previews for documentation or social media, this code keeps the animation intact during conversion.
 */