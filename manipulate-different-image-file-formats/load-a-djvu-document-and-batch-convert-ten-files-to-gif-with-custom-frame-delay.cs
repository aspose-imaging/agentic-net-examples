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
        string inputPath = "Input\\sample.djvu";
        string outputPath = "Output\\output.gif";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (FileStream stream = File.OpenRead(inputPath))
            {
                using (DjvuImage djvu = new DjvuImage(stream))
                {
                    int pagesToConvert = Math.Min(10, djvu.PageCount);
                    GifImage gif = null;

                    for (int i = 0; i < pagesToConvert; i++)
                    {
                        DjvuPage page = (DjvuPage)djvu.Pages[i];
                        if (!page.IsCached)
                            page.CacheData();

                        GifFrameBlock frame = new GifFrameBlock((ushort)page.Width, (ushort)page.Height);
                        frame.FrameTime = 200; // custom delay (in hundredths of a second)

                        Graphics graphics = new Graphics(frame);
                        graphics.DrawImage(page, 0, 0);

                        if (i == 0)
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
                            GifOptions gifOptions = new GifOptions();
                            gif.Save(outputPath, gifOptions);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}