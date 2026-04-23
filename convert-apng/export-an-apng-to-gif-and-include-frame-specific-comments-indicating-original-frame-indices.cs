using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\animation.apng";
        string outputPath = "Output\\animation.gif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (ApngImage apng = (ApngImage)Image.Load(inputPath))
            {
                ushort width = (ushort)apng.Width;
                ushort height = (ushort)apng.Height;

                using (GifFrameBlock firstBlock = new GifFrameBlock(width, height))
                {
                    Graphics graphics = new Graphics(firstBlock);
                    using (RasterImage firstFrame = (RasterImage)apng.Pages[0])
                    {
                        graphics.DrawImage(firstFrame, new Point(0, 0));
                    }

                    using (GifImage gif = new GifImage(firstBlock))
                    {
                        for (int i = 1; i < apng.PageCount; i++)
                        {
                            using (RasterImage frame = (RasterImage)apng.Pages[i])
                            {
                                gif.AddPage(frame);
                            }
                        }

                        gif.Save(outputPath);
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