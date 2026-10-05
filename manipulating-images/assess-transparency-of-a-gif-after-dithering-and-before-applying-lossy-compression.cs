// HOW-TO: Count Transparent Pixels In A Dithered GIF Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
        string outputPath = "output/transparent_pixels.txt";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (GifImage gif = (GifImage)Image.Load(inputPath))
            {
                if (gif.PageCount == 0)
                {
                    Console.Error.WriteLine("No frames in GIF.");
                    return;
                }

                gif.ActiveFrame = (GifFrameBlock)gif.Pages[0];
                RasterImage raster = (RasterImage)gif.ActiveFrame;

                if (!raster.IsCached)
                {
                    raster.CacheData();
                }

                raster.Dither(DitheringMethod.FloydSteinbergDithering, 1);

                int[] pixels = raster.LoadArgb32Pixels(new Rectangle(0, 0, raster.Width, raster.Height));
                long transparentCount = 0;
                foreach (int argb in pixels)
                {
                    if ((argb >> 24) == 0)
                    {
                        transparentCount++;
                    }
                }

                File.WriteAllText(outputPath, $"Transparent pixels: {transparentCount}");
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
 * 1. When you need to verify how many fully transparent pixels remain after applying Floyd‑Steinberg dithering to a GIF before compressing it.
 * 2. When you want to generate a report of transparency loss for quality‑control of animated GIF assets in a C# application.
 * 3. When you are building an image‑processing pipeline that must ensure a minimum number of transparent pixels are preserved after dithering.
 * 4. When you need to debug or audit the effect of dithering on GIF frames by counting transparent pixels programmatically.
 * 5. When you are preparing GIFs for lossy compression and want to log transparency statistics to decide if further processing is required.
 */
