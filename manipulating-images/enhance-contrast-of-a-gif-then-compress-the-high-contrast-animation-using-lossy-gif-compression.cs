// HOW-TO: Increase GIF Frame Contrast and Apply Lossy Compression in C# (Aspose.Imaging for .NET)
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
        string inputPath = "input.gif";
        string outputPath = "output.gif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
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
                    frameRaster.AdjustContrast(0.5f);
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
 * 1. When you need to make a low‑visibility animated GIF more vivid before embedding it in a website, you can boost each frame’s contrast and then compress the animation to keep page load times low.
 * 2. When preparing marketing email newsletters that include animated GIFs, enhancing contrast improves visual impact while lossy compression reduces the attachment size to meet email size limits.
 * 3. When optimizing GIF assets for mobile apps, increasing frame contrast ensures clarity on small screens and the lossy compression minimizes the app bundle size.
 * 4. When archiving a series of GIF screenshots for documentation, adjusting contrast makes details easier to read and the compression saves storage space on the server.
 * 5. When creating GIF memes that need a punchy look, programmatically raising contrast and applying compression lets you generate eye‑catching animations quickly without manual editing tools.
 */
