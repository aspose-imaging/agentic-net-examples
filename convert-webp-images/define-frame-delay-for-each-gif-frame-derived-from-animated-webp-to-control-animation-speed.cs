// HOW-TO: Set Custom Frame Delays When Converting Animated WebP to GIF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputWebPPath = "input.webp";
            string outputGifPath = "output.gif";

            if (!File.Exists(inputWebPPath))
            {
                Console.Error.WriteLine($"File not found: {inputWebPPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputGifPath));

            using (WebPImage webp = (WebPImage)Image.Load(inputWebPPath))
            {
                if (webp.Pages.Length == 0)
                {
                    Console.Error.WriteLine("No pages found in the WebP image.");
                    return;
                }

                RasterImage firstRaster = (RasterImage)webp.Pages[0];
                int width = firstRaster.Width;
                int height = firstRaster.Height;

                using (GifImage gif = (GifImage)Image.Create(new GifOptions(), width, height))
                {
                    int[] frameDelays = { 100, 200, 150 };

                    for (int i = 0; i < webp.Pages.Length; i++)
                    {
                        RasterImage raster = (RasterImage)webp.Pages[i];
                        gif.AddPage(raster);
                        int delay = i < frameDelays.Length ? frameDelays[i] : 100;
                        gif.ActiveFrame.FrameTime = delay;
                    }

                    gif.LoopsCount = 0; // infinite loop
                    GifOptions gifOptions = new GifOptions();
                    gif.Save(outputGifPath, gifOptions);
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
 * 1. When you need to preserve the timing of each frame while converting an animated WebP advertisement into a looping GIF for web banners.
 * 2. When creating a GIF slideshow from a WebP animation where specific frames must display longer to emphasize key moments.
 * 3. When generating GIFs for social media that require custom frame speeds to match a soundtrack or voice‑over.
 * 4. When building a desktop tool that batch‑converts animated WebP files to GIFs and lets users define per‑frame delays for smoother playback.
 * 5. When developing a game asset pipeline that transforms animated WebP sprites into GIFs with precise frame timing for consistent animation across platforms.
 */
