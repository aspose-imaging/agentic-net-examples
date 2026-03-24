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

        using (GifImage gif = (GifImage)Image.Load(inputPath))
        {
            for (int i = 0; i < gif.PageCount; i++)
            {
                gif.ActiveFrame = (GifFrameBlock)gif.Pages[i];
                Graphics graphics = new Graphics(gif.ActiveFrame);
                Pen pen = new Pen(Color.Yellow, 2);
                graphics.DrawRectangle(pen, new RectangleF(10, 10, 50, 30));
            }

            GifOptions gifOptions = new GifOptions();
            gif.Save(outputPath, gifOptions);
        }
    }
}