// HOW-TO: How to Deskew Each Frame of an Animated GIF in C# (Aspose.Imaging for .NET)
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
            string outputPath = "output.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (GifImage gif = (GifImage)Image.Load(inputPath))
            {
                for (int i = 0; i < gif.PageCount; i++)
                {
                    gif.ActiveFrame = (GifFrameBlock)gif.Pages[i];
                    RasterImage frameRaster = (RasterImage)gif.ActiveFrame;
                    if (!frameRaster.IsCached)
                    {
                        frameRaster.CacheData();
                    }
                    frameRaster.NormalizeAngle(false, Aspose.Imaging.Color.White);
                }

                GifOptions options = new GifOptions();
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
 * 1. When you need to correct the tilt of scanned animated GIFs before publishing them on a website.
 * 2. When an e‑commerce platform wants to automatically straighten product animation frames uploaded by sellers.
 * 3. When a digital archivist must normalize the orientation of legacy animated GIFs for consistent viewing.
 * 4. When a mobile app generates animated GIFs from camera captures and requires deskewed frames for better user experience.
 * 5. When a marketing tool creates animated GIF ads and needs to ensure each frame is level to avoid visual distortion.
 */
