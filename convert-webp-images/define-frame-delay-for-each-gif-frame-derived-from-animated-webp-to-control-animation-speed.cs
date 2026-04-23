using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main()
    {
        string inputPath = "input.webp";
        string outputPath = "Output/output.gif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (WebPImage webpImage = (WebPImage)Image.Load(inputPath))
        {
            int frameCount = webpImage.PageCount;
            ushort[] frameDelays = new ushort[frameCount];
            for (int i = 0; i < frameCount; i++)
            {
                frameDelays[i] = 100;
            }

            using (GifImage gifImage = new GifImage(new GifFrameBlock((ushort)webpImage.Width, (ushort)webpImage.Height)))
            {
                for (int i = 0; i < frameCount; i++)
                {
                    using (RasterImage raster = (RasterImage)webpImage.Pages[i])
                    {
                        gifImage.AddPage(raster);
                        gifImage.ActiveFrame.FrameTime = frameDelays[i];
                    }
                }

                gifImage.Save(outputPath);
            }
        }
    }
}