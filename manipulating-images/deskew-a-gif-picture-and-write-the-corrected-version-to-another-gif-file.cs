using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input\\skewed.gif";
            string outputPath = "output\\deskewed.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the GIF image
            using (GifImage image = (GifImage)Image.Load(inputPath))
            {
                // Deskew the image: normalize angle without resizing, using white background
                image.NormalizeAngle(false, Color.White);

                // Save the corrected image as GIF
                image.Save(outputPath, new GifOptions());
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
 * 1. When a web application receives user‑uploaded animated GIFs that were scanned or captured at an angle, a developer can use this code to deskew the GIF and store a corrected version for display.
 * 2. When an e‑commerce platform needs to automatically straighten product animation GIFs before adding them to the catalog, the code can normalize the angle without resizing the frames.
 * 3. When a digital marketing tool generates GIF banners from scanned artwork and must ensure the graphics are level, a developer can apply the NormalizeAngle method in C# to produce a clean output GIF.
 * 4. When a mobile game server processes player‑submitted GIF avatars that may be tilted, this snippet can deskew the image and save it with Aspose.Imaging GifOptions for consistent rendering.
 * 5. When an archival system digitizes old animated GIFs from paper copies and wants to correct skew while preserving the original palette, the code provides a simple C# solution to load, deskew, and re‑save the GIF.
 */