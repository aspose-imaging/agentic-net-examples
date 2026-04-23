using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.djvu";
            string outputPath = "Output\\animated.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int[] pageIndexes = new int[] { 7, 8, 9 };
            int frameDelayMs = 200;

            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                using (RasterImage firstFrame = (RasterImage)djvu.Pages[pageIndexes[0]])
                {
                    firstFrame.CacheData();

                    using (GifImage gif = new GifImage(new GifFrameBlock((ushort)firstFrame.Width, (ushort)firstFrame.Height)))
                    {
                        Graphics graphics = new Graphics(gif.ActiveFrame);
                        graphics.DrawImage(firstFrame, new Rectangle(0, 0, firstFrame.Width, firstFrame.Height));
                        gif.ActiveFrame.FrameTime = frameDelayMs;

                        for (int i = 1; i < pageIndexes.Length; i++)
                        {
                            using (RasterImage frame = (RasterImage)djvu.Pages[pageIndexes[i]])
                            {
                                frame.CacheData();
                                gif.AddPage(frame);
                                gif.ActiveFrame.FrameTime = frameDelayMs;
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