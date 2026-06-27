using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.gif";
            string outputPath = "output.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (GifImage gif = (GifImage)Image.Load(inputPath))
            {
                // Flip horizontally
                gif.RotateFlip(RotateFlipType.RotateNoneFlipX);
                // Rotate 15 degrees with transparent background
                gif.Rotate(15f, true, Color.Transparent);

                using (MemoryStream ms = new MemoryStream())
                {
                    gif.Save(ms, new GifOptions());
                    byte[] result = ms.ToArray();
                    Console.WriteLine($"Result byte array length: {result.Length}");
                }
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
 * 1. When creating a web service that generates animated GIF thumbnails with a mirrored effect and a slight rotation for a social media preview, a developer can use this code to flip, rotate, and return the image as a byte array.
 * 2. When building an email marketing platform that needs to embed custom‑styled GIF banners with a horizontal flip and a 15‑degree tilt to match a campaign’s visual theme, this snippet processes the GIF and provides the result in memory for attachment.
 * 3. When developing a mobile app that applies playful transformations to user‑uploaded GIF stickers—flipping them horizontally and rotating them before sending them to a server—the code performs the transformation and supplies the byte array for network transmission.
 * 4. When implementing a server‑side image‑processing pipeline that converts uploaded GIF avatars into a consistent orientation by flipping and rotating them, the byte array output can be stored directly in a database or cache.
 * 5. When creating an automated testing tool that validates GIF rendering after applying geometric transformations, the developer can use this example to flip, rotate, and capture the resulting image data as a byte array for comparison.
 */