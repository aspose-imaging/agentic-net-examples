using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;

class Program
{
    static void Main()
    {
        string[] inputPaths = { "frame1.psd", "frame2.psd", "frame3.psd" };
        string outputPath = "Output\\compressed.gif";

        foreach (var path in inputPaths)
        {
            if (!File.Exists(path))
            {
                Console.Error.WriteLine($"File not found: {path}");
                return;
            }
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (RasterImage firstFrame = (RasterImage)Image.Load(inputPaths[0]))
        {
            using (GifFrameBlock firstBlock = new GifFrameBlock((ushort)firstFrame.Width, (ushort)firstFrame.Height))
            {
                using (GifImage gif = new GifImage(firstBlock))
                {
                    Graphics graphics = new Graphics(gif.ActiveFrame);
                    graphics.DrawImage(firstFrame, new Rectangle(0, 0, firstFrame.Width, firstFrame.Height));

                    for (int i = 1; i < inputPaths.Length; i++)
                    {
                        using (RasterImage frame = (RasterImage)Image.Load(inputPaths[i]))
                        {
                            gif.AddPage(frame);
                        }
                    }

                    GifOptions options = new GifOptions
                    {
                        MaxDiff = 80
                    };

                    gif.Save(outputPath, options);
                }
            }
        }
    }
}