using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input\\sample.gif";
        string outputPath = "output\\deskewed.gif";

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

            // Load GIF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to GifImage to access GIF-specific methods
                GifImage gif = (GifImage)image;

                // Deskew the image
                gif.NormalizeAngle();

                // Save the corrected GIF using GifOptions
                gif.Save(outputPath, new GifOptions());
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
 * 1. When a web application receives scanned animated GIF receipts that are slightly rotated and needs to automatically deskew them before displaying to users.
 * 2. When an e‑learning platform processes teacher‑uploaded GIF diagrams captured at an angle and must normalize the image orientation for consistent playback.
 * 3. When a digital archiving system imports legacy GIF animations from scanned documents and requires angle correction to improve OCR accuracy.
 * 4. When a mobile app generates animated GIF memes from user photos and wants to straighten tilted frames using C# and Aspose.Imaging before sharing.
 * 5. When a batch processing script cleans up a folder of animated GIF logos that were scanned crooked, applying NormalizeAngle and saving the corrected files.
 */