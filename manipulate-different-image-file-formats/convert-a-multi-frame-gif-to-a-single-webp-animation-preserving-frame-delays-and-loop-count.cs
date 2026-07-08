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
            string inputPath = "Input\\animation.gif";
            string outputPath = "Output\\animation.webp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image gifImage = Image.Load(inputPath))
            {
                GifImage gif = gifImage as GifImage;
                if (gif == null)
                {
                    Console.Error.WriteLine("The input file is not a valid GIF image.");
                    return;
                }

                WebPOptions webpOptions = new WebPOptions
                {
                    AnimLoopCount = (ushort)gif.LoopsCount
                };

                gif.Save(outputPath, webpOptions);
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
 * 1. When a developer needs to reduce the file size of an animated GIF for faster web page loading while keeping the original animation timing, they can use this code to convert the multi‑frame GIF into a WebP animation with preserved frame delays and loop count.
 * 2. When building a mobile app that only supports WebP animations, a developer can employ this C# snippet to transform user‑uploaded GIF stickers into a single WebP file without losing the animation loop settings.
 * 3. When creating an automated image‑processing pipeline that archives social‑media GIFs as WebP for long‑term storage, this code enables conversion of each multi‑frame GIF while maintaining its original playback speed and repeat behavior.
 * 4. When optimizing email newsletters that embed animated graphics, a developer can use the example to replace bulky GIFs with compact WebP animations, ensuring the same frame timing and loop count for consistent visual experience.
 * 5. When developing a content‑management system that generates thumbnails and preview animations, this code allows conversion of uploaded GIFs to a single WebP animation, preserving the original animation’s frame delays and loop count for accurate previews.
 */