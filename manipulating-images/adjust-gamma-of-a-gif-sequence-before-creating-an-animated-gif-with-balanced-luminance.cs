// HOW-TO: Adjust Gamma of Each Frame and Create Animated GIF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
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

            using (GifImage gif = (GifImage)Aspose.Imaging.Image.Load(inputPath))
            {
                for (int i = 0; i < gif.PageCount; i++)
                {
                    gif.ActiveFrame = (GifFrameBlock)gif.Pages[i];
                    Aspose.Imaging.RasterImage frameRaster = (Aspose.Imaging.RasterImage)gif.ActiveFrame;
                    frameRaster.AdjustGamma(1.2f);
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
 * 1. When you need to brighten a series of GIF frames to achieve consistent luminance before publishing an animated banner.
 * 2. When preparing product showcase animations where each frame must have corrected gamma for accurate color representation on web browsers.
 * 3. When converting a low‑contrast GIF slideshow into a high‑visibility animated GIF for mobile app onboarding screens.
 * 4. When automating the preprocessing of GIF assets in a content pipeline to ensure all frames meet a specific gamma level before compression.
 * 5. When fixing washed‑out GIF animations from older cameras by programmatically adjusting gamma on each frame using Aspose.Imaging in C#.
 */
