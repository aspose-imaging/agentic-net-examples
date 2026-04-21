using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;

class Program
{
    static void Main()
    {
        string inputPath = "Input/sample.djvu";
        string outputPath = "Output/animated.gif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
        {
            if (djvu.PageCount < 9)
            {
                Console.Error.WriteLine("DjVu document does not contain pages 7-9.");
                return;
            }

            DjvuPage page7 = (DjvuPage)djvu.Pages[6];
            DjvuPage page8 = (DjvuPage)djvu.Pages[7];
            DjvuPage page9 = (DjvuPage)djvu.Pages[8];

            using (GifFrameBlock firstBlock = new GifFrameBlock((ushort)page7.Width, (ushort)page7.Height))
            {
                Graphics graphics = new Graphics(firstBlock);
                graphics.DrawImage(page7, new Rectangle(0, 0, firstBlock.Width, firstBlock.Height));

                using (GifImage gif = new GifImage(firstBlock))
                {
                    using (GifFrameBlock block8 = new GifFrameBlock((ushort)page8.Width, (ushort)page8.Height))
                    {
                        Graphics g8 = new Graphics(block8);
                        g8.DrawImage(page8, new Rectangle(0, 0, block8.Width, block8.Height));
                        gif.AddPage(block8);
                    }

                    using (GifFrameBlock block9 = new GifFrameBlock((ushort)page9.Width, (ushort)page9.Height))
                    {
                        Graphics g9 = new Graphics(block9);
                        g9.DrawImage(page9, new Rectangle(0, 0, block9.Width, block9.Height));
                        gif.AddPage(block9);
                    }

                    gif.Save(outputPath, new GifOptions());
                }
            }
        }
    }
}