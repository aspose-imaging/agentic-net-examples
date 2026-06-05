using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = Path.Combine("Input", "animation.gif");
            string outputPath = Path.Combine("Output", "animation.webp");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                GifImage gif = image as GifImage;
                WebPOptions options = new WebPOptions();

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
 * 1. When a web developer wants to replace a multi‑frame GIF banner with a smaller WebP animation while keeping the original frame timing and loop settings, they can use this code.
 * 2. When an e‑commerce platform needs to generate product showcase animations in WebP format from existing GIF assets to improve page load speed without losing animation fidelity, this snippet provides the conversion.
 * 3. When a mobile app developer must batch‑process user‑uploaded GIF stickers into WebP animations for reduced storage and bandwidth on iOS/Android devices, the example shows how to preserve delays and loops.
 * 4. When a content management system needs to automatically convert uploaded GIF memes into WebP for SEO‑friendly, high‑quality animated images, the code demonstrates the required C# operations.
 * 5. When a digital marketing analyst wants to create lightweight animated ads by converting GIFs to WebP while maintaining the original animation loop count, this Aspose.Imaging routine handles the task.
 */