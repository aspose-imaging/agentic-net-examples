// HOW-TO: Increase Contrast of Each Frame in an Animated GIF using C# (Aspose.Imaging for .NET)
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
            string outputPath = "output\\animated.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (GifImage gif = (GifImage)Image.Load(inputPath))
            {
                float contrastIncrease = 0.5f; // increase contrast

                for (int i = 0; i < gif.PageCount; i++)
                {
                    gif.ActiveFrame = (GifFrameBlock)gif.Pages[i];
                    RasterImage frame = (RasterImage)gif.ActiveFrame;

                    if (!frame.IsCached)
                    {
                        frame.CacheData();
                    }

                    frame.AdjustContrast(contrastIncrease);
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
 * 1. When you need to enhance the visual depth of a low‑contrast GIF before embedding it in a web banner.
 * 2. When preparing a series of GIF frames for a marketing email and want richer tones without losing animation.
 * 3. When converting a screen‑capture GIF into a higher‑contrast version for better visibility on mobile devices.
 * 4. When processing user‑uploaded GIFs in a .NET application to improve readability for accessibility compliance.
 * 5. When automating a batch job that adjusts contrast of each frame in animated GIFs for a digital signage system.
 */
