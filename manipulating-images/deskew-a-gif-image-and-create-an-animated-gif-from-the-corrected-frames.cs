using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.gif";
        string outputPath = "output.gif";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        string outputDir = Path.GetDirectoryName(outputPath);
        if (!string.IsNullOrWhiteSpace(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        try
        {
            // Load the GIF image
            using (GifImage gif = (GifImage)Image.Load(inputPath))
            {
                // Iterate through each frame and deskew it
                for (int i = 0; i < gif.PageCount; i++)
                {
                    // Set the active frame
                    gif.ActiveFrame = (GifFrameBlock)gif.Pages[i];

                    // Deskew the active frame (do not resize canvas, fill background with white)
                    gif.NormalizeAngle(false, Aspose.Imaging.Color.White);
                }

                // Save the corrected animated GIF
                GifOptions saveOptions = new GifOptions();
                gif.Save(outputPath, saveOptions);
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
 * 1. When a web developer needs to correct the tilt of each frame in a user‑uploaded animated GIF before displaying it on a website, they can use this C# code with Aspose.Imaging to deskew the frames and save a clean animated GIF.
 * 2. When an e‑learning platform wants to automatically straighten scanned hand‑drawn animation sequences stored as GIFs so that the playback appears level for students, the code can process each frame and generate a corrected animated GIF.
 * 3. When a mobile app backend receives GIF stickers that were captured at an angle and must be normalized for consistent visual quality across devices, developers can employ this snippet to deskew and re‑encode the GIF using Aspose.Imaging for .NET.
 * 4. When a digital archivist is preserving historical animated GIFs that suffer from skew due to scanning errors, the code provides a way to programmatically straighten each frame and output a restored animated GIF.
 * 5. When a marketing automation script needs to batch‑process promotional animated GIFs to ensure they are perfectly aligned before being sent in email campaigns, this C# example can deskew the frames and produce a ready‑to‑use animated GIF.
 */