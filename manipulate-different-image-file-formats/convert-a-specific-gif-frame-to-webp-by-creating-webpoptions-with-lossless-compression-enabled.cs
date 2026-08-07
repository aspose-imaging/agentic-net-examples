using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = @"C:\Images\input.gif";
            string outputPath = @"C:\Images\output_frame.webp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                if (image is GifImage gifImage)
                {
                    int frameIndex = 0; // index of the frame to convert

                    if (frameIndex < 0 || frameIndex >= gifImage.PageCount)
                    {
                        Console.Error.WriteLine($"Invalid frame index: {frameIndex}");
                        return;
                    }

                    // Set the active frame to the desired GIF frame
                    gifImage.ActiveFrame = (GifFrameBlock)gifImage.Pages[frameIndex];

                    // Save the active frame as a lossless WebP image
                    WebPOptions options = new WebPOptions
                    {
                        Lossless = true
                    };

                    gifImage.Save(outputPath, options);
                }
                else
                {
                    Console.Error.WriteLine("The input file is not a GIF image.");
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
 * 1. When a developer needs to extract a single animation frame from a GIF and store it as a high‑quality, lossless WebP file for use on a website that supports WebP.
 * 2. When an e‑commerce platform wants to generate a thumbnail from a specific GIF frame and save it as a compact WebP image to reduce page load time while preserving visual fidelity.
 * 3. When a mobile app needs to convert a chosen GIF frame to a lossless WebP asset to meet platform size limits without sacrificing image quality.
 * 4. When a content management system processes user‑uploaded GIFs and requires conversion of a particular frame to WebP for caching and faster delivery via CDNs.
 * 5. When a developer is building an automated batch job that extracts key frames from animated GIFs and saves them as lossless WebP images for archival or machine‑learning preprocessing.
 */