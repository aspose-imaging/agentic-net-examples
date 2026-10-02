// HOW-TO: Convert PNG to GIF in C# with Automatic Image Disposal (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace ImageConversion
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.png";
                string outputPath = "output.gif";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

                using (Image image = Image.Load(inputPath))
                {
                    var options = new GifOptions();
                    image.Save(outputPath, options);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web application needs to generate animated or smaller GIF thumbnails from user‑uploaded PNG files while ensuring the Image object is released promptly.
 * 2. When a desktop utility batch‑processes PNG assets into GIF format for compatibility with legacy systems and wants to avoid memory leaks by using a using block.
 * 3. When an e‑learning platform converts high‑resolution PNG diagrams to GIF for faster loading in browsers and requires deterministic disposal of the image resource.
 * 4. When a server‑side service creates GIF previews of PNG product images for email newsletters and must guarantee the image is disposed after saving.
 * 5. When a mobile backend transforms PNG icons to GIF sprites for cross‑platform UI and needs automatic cleanup of the Aspose.Imaging Image instance.
 */
