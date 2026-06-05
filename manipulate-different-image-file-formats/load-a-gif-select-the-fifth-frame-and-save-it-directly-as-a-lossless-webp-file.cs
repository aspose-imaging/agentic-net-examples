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
        try
        {
            string inputPath = "Input/animation.gif";
            string outputPath = "Output/frame5.webp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (GifImage gif = (GifImage)Image.Load(inputPath))
            {
                if (gif.PageCount <= 4)
                {
                    Console.Error.WriteLine("GIF does not contain a fifth frame.");
                    return;
                }

                gif.ActiveFrame = (GifFrameBlock)gif.Pages[4];

                var options = new WebPOptions
                {
                    Lossless = true
                };

                gif.Save(outputPath, options);
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
 * 1. When a developer needs to extract a specific frame from an animated GIF to use as a high‑quality thumbnail in a web application, they can load the GIF, select the fifth frame, and save it as a lossless WebP file.
 * 2. When converting legacy animated GIF assets to modern web‑friendly formats, a developer may isolate the fifth frame and store it losslessly as WebP to preserve visual fidelity while reducing file size.
 * 3. When generating preview images for a video editing tool that imports GIF animations, a developer can extract the fifth frame and save it as a lossless WebP to provide a crisp preview without compression artifacts.
 * 4. When creating a sprite sheet from an animated GIF for a game, a developer might extract the fifth frame and convert it to lossless WebP to maintain exact colors and transparency for rendering.
 * 5. When building an email marketing platform that supports WebP images, a developer can pull the fifth frame from a GIF banner and save it as a lossless WebP to ensure the image displays correctly across modern email clients.
 */