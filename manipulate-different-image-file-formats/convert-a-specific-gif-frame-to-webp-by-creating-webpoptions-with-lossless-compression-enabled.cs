// HOW-TO: Convert a GIF Frame to Lossless WebP in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input/sample.gif";
            string outputPath = "Output/frame.webp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (GifImage gif = (GifImage)Image.Load(inputPath))
            {
                int frameIndex = 0; // specify the frame index to convert
                if (frameIndex < 0 || frameIndex >= gif.PageCount)
                {
                    Console.Error.WriteLine($"Invalid frame index: {frameIndex}");
                    return;
                }

                gif.ActiveFrame = (Aspose.Imaging.FileFormats.Gif.Blocks.GifFrameBlock)gif.Pages[frameIndex];
                RasterImage frame = gif.ActiveFrame;

                using (WebPOptions options = new WebPOptions())
                {
                    options.Lossless = true;
                    frame.Save(outputPath, options);
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
 * 1. When you need to extract a single animation frame from a GIF and store it as a high‑quality, lossless WebP image for use on modern web pages.
 * 2. When an e‑commerce platform wants to generate thumbnail previews from animated product GIFs without sacrificing visual fidelity, converting each frame to WebP.
 * 3. When a mobile app requires lightweight assets and you must convert specific GIF frames to lossless WebP to reduce file size while preserving transparency.
 * 4. When automating a batch process that extracts key frames from GIF stickers and saves them as WebP for faster loading in chat applications.
 * 5. When integrating Aspose.Imaging in a C# service that needs to serve individual GIF frames as lossless WebP images for SEO‑friendly image indexing.
 */
