using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.webp";
            string tempGifPath = "temp.gif";
            string outputPath = "output.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image webpImage = Image.Load(inputPath))
            {
                webpImage.Save(tempGifPath, new GifOptions());
            }

            using (GifImage gifImage = (GifImage)Image.Load(tempGifPath))
            {
                // Set frame delay to 100 milliseconds for all frames
                gifImage.SetFrameTime(100);
                gifImage.Save(outputPath, new GifOptions());
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
 * 1. When converting an animated WebP advertisement into a GIF for email newsletters and needing to ensure each frame displays for a consistent 100 ms to match the original timing.
 * 2. When building a C# web application that generates product showcase animations from WebP assets and must adjust the GIF frame delay to synchronize with UI transition speeds.
 * 3. When creating a desktop utility that batch‑processes user‑uploaded WebP stickers into GIFs for social media platforms, requiring explicit frame timing control to avoid overly fast playback.
 * 4. When developing an e‑learning platform that extracts animated WebP tutorials and converts them to GIFs with a uniform frame delay so the instructional steps are easy to follow.
 * 5. When implementing a server‑side image pipeline that transforms animated WebP icons into GIFs for legacy browsers, and the developer needs to set the frame delay to guarantee smooth animation across devices.
 */