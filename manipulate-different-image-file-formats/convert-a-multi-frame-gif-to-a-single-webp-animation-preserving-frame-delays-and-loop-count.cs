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
        string inputPath = "input.gif";
        string outputPath = "Output/output.webp";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var options = new WebPOptions
                {
                    Lossless = false,
                    Quality = 80
                };

                GifImage gif = image as GifImage;
                if (gif != null)
                {
                    options.AnimLoopCount = (ushort)gif.LoopsCount;
                }

                image.Save(outputPath, options);
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
 * 1. When a web developer wants to replace animated GIF banners with smaller WebP animations to improve page load speed while keeping the original frame timing and loop behavior.
 * 2. When a mobile app programmer needs to generate lightweight animated stickers from user‑uploaded GIFs for iOS/Android, using C# and Aspose.Imaging to convert them to WebP with preserved delays.
 * 3. When an e‑commerce platform needs to batch‑process product showcase animations, converting multi‑frame GIFs to lossily compressed WebP files to reduce bandwidth without losing animation loops.
 * 4. When a digital marketing team automates the creation of email campaign assets, converting GIF ads to WebP animations in a .NET service while maintaining the original loop count for consistent display.
 * 5. When a game developer imports animated UI elements stored as GIFs and converts them to WebP sprites in Unity, using Aspose.Imaging to keep frame delays accurate for smooth in‑game animation.
 */