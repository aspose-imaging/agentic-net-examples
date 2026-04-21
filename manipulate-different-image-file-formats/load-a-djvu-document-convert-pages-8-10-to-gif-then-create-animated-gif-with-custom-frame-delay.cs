using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/sample.djvu";
        string outputPath = "Output/animated.gif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Stream stream = File.OpenRead(inputPath))
        using (DjvuImage djvu = new DjvuImage(stream))
        {
            int[] pageIndices = { 7, 8, 9 };
            GifImage gif = null;
            const int frameDelayMs = 200;

            foreach (int idx in pageIndices)
            {
                DjvuPage djvuPage = (DjvuPage)djvu.Pages[idx];
                RasterImage raster = (RasterImage)djvuPage;

                if (!raster.IsCached)
                    raster.CacheData();

                GifFrameBlock frameBlock = new GifFrameBlock((ushort)raster.Width, (ushort)raster.Height)
                {
                    FrameTime = frameDelayMs
                };

                Graphics graphics = new Graphics(frameBlock);
                graphics.DrawImage(raster, 0, 0);

                if (gif == null)
                {
                    gif = new GifImage(frameBlock);
                }
                else
                {
                    gif.AddPage(frameBlock);
                }
            }

            using (gif)
            {
                GifOptions gifOptions = new GifOptions
                {
                    LoopsCount = 0
                };
                gif.Save(outputPath, gifOptions);
            }
        }
    }
}