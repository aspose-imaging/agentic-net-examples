// HOW-TO: Convert Animated WebP to GIF While Preserving Frames in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.webp";
            string outputPath = "output.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (WebPImage webpImage = (WebPImage)Image.Load(inputPath))
            {
                GifOptions gifOptions = new GifOptions();
                webpImage.Save(outputPath, gifOptions);
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
 * 1. When you need to display an animated WebP advertisement on a website that only supports GIF, you can convert it while keeping the animation intact.
 * 2. When a mobile app receives user‑generated animated WebP stickers but the platform only renders GIFs, this code transforms the stickers without losing frames.
 * 3. When archiving animated WebP assets for legacy systems that require GIF format, the conversion preserves the original motion for accurate playback.
 * 4. When generating email newsletters that embed animated images, converting WebP to GIF ensures compatibility with email clients while retaining the animation.
 * 5. When processing batch image pipelines that ingest WebP animations and output GIFs for social media APIs, this snippet handles the format change without dropping frames.
 */
