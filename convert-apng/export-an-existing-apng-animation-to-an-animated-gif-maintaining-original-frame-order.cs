// HOW-TO: Export APNG to Animated GIF Preserving Frame Order in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.apng";
        string outputPath = "output\\output.gif";

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

            // Load the APNG animation
            using (Image apngImage = Image.Load(inputPath))
            {
                // Save as animated GIF, preserving frame order
                var gifOptions = new GifOptions
                {
                    // FullFrame ensures each frame is saved as a full image (optional, but keeps animation correct)
                    FullFrame = true
                };
                apngImage.Save(outputPath, gifOptions);
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
 * 1. When you need to convert a web‑optimized APNG sprite animation into a widely supported animated GIF for email newsletters.
 * 2. When an application must generate GIF previews of user‑uploaded APNG files while keeping the original sequence of frames.
 * 3. When a game asset pipeline requires transforming APNG character animations into GIFs for legacy platforms that only read GIF.
 * 4. When a reporting tool needs to embed animated graphics and must convert APNG charts to GIF without losing frame order.
 * 5. When a batch‑processing script has to archive APNG animations as GIFs for long‑term storage while preserving the animation timing.
 */
