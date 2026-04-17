using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = Path.Combine("Input", "animation.apng");
        string outputPath = Path.Combine("Output", "converted.gif");

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (ApngImage apng = (ApngImage)Image.Load(inputPath))
        {
            int frameCount = apng.PageCount;
            if (frameCount == 0)
            {
                Console.Error.WriteLine("APNG contains no frames.");
                return;
            }

            ApngFrame firstApngFrame = (ApngFrame)apng.Pages[0];
            var firstBlock = new GifFrameBlock((ushort)firstApngFrame.Width, (ushort)firstApngFrame.Height);
            Graphics gFirst = new Graphics(firstBlock);
            gFirst.DrawImage(firstApngFrame, new Point(0, 0));

            using (GifImage gif = new GifImage(firstBlock))
            {
                for (int i = 1; i < frameCount; i++)
                {
                    ApngFrame apngFrame = (ApngFrame)apng.Pages[i];
                    var block = new GifFrameBlock((ushort)apngFrame.Width, (ushort)apngFrame.Height);
                    Graphics g = new Graphics(block);
                    g.DrawImage(apngFrame, new Point(0, 0));
                    gif.AddPage(block);
                }

                gif.Save(outputPath);
            }
        }
    }
}