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

        using (FileStream stream = File.OpenRead(inputPath))
        using (DjvuImage djvu = new DjvuImage(stream))
        {
            int pagesToConvert = Math.Min(10, djvu.PageCount);
            GifImage gif = null;

            for (int i = 0; i < pagesToConvert; i++)
            {
                var djvuPage = (DjvuPage)djvu.Pages[i];
                if (!djvuPage.IsCached)
                {
                    djvuPage.CacheData();
                }

                int width = djvuPage.Width;
                int height = djvuPage.Height;

                var frame = new GifFrameBlock((ushort)width, (ushort)height);
                frame.FrameTime = 200; // custom delay in milliseconds

                Graphics graphics = new Graphics(frame);
                graphics.DrawImage(djvuPage, new Rectangle(0, 0, width, height));

                if (gif == null)
                {
                    gif = new GifImage(frame);
                }
                else
                {
                    gif.AddPage(frame);
                }
            }

            if (gif != null)
            {
                using (gif)
                {
                    gif.Save(outputPath, new GifOptions());
                }
            }
        }
    }
}