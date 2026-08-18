// HOW-TO: Extract Fifth Frame from GIF and Save as Lossless WebP in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.gif";
            string outputPath = "output.webp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrWhiteSpace(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            using (GifImage gif = (GifImage)Image.Load(inputPath))
            {
                if (gif.PageCount <= 4)
                {
                    Console.Error.WriteLine("GIF does not contain a fifth frame.");
                    return;
                }

                gif.ActiveFrame = (GifFrameBlock)gif.Pages[4];

                WebPOptions options = new WebPOptions
                {
                    Lossless = true,
                    MultiPageOptions = new MultiPageOptions(new IntRange(4, 1))
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
 * 1. When you need to generate a high‑quality thumbnail from a specific frame of an animated GIF for use on a website.
 * 2. When you want to convert a particular frame of a GIF into a lossless WebP image to reduce file size without sacrificing visual fidelity.
 * 3. When you are building a media‑processing pipeline that extracts a chosen frame from an animation and stores it in a modern web‑friendly format.
 * 4. When you need to isolate the fifth frame of a GIF for further analysis or machine‑learning preprocessing while preserving exact pixel data.
 * 5. When you are creating an asset‑export tool that lets designers select any frame of an animated GIF and export it as a WebP for inclusion in mobile apps.
 */
