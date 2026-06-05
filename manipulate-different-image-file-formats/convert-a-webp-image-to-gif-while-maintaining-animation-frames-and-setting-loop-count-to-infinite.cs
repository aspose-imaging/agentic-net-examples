using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // All runtime errors are caught and reported
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Images\input.webp";
            string outputPath = @"C:\Images\output.gif";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the animated WebP image (frames are preserved)
            using (Image image = Image.Load(inputPath))
            {
                // Configure GIF saving options
                var gifOptions = new GifOptions
                {
                    // Export each frame as a full image to keep animation intact
                    FullFrame = true
                };

                // Save as an animated GIF; loop count defaults to infinite
                image.Save(outputPath, gifOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any unexpected errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web developer needs to display an animated WebP banner on older browsers that only support GIF, they can use this C# code with Aspose.Imaging to convert the WebP to an animated GIF while preserving all frames and setting an infinite loop.
 * 2. When a mobile app generates user‑created stickers in WebP format but the messaging platform requires GIFs, the code allows conversion of the animated WebP to a looping GIF using Image.Load and GifOptions.FullFrame.
 * 3. When a digital marketing team wants to reuse animated product demos originally saved as WebP in email newsletters that only accept GIF files, this snippet converts the animation to a GIF with infinite looping for consistent playback.
 * 4. When an e‑learning platform stores course animations as WebP to save bandwidth but needs to export them as GIFs for offline PowerPoint presentations, the provided C# example handles the format conversion while keeping each animation frame intact.
 * 5. When a game developer exports character motion clips as animated WebP and must provide a GIF preview for documentation or asset catalogs, this code quickly transforms the WebP into a full‑frame animated GIF that loops forever.
 */