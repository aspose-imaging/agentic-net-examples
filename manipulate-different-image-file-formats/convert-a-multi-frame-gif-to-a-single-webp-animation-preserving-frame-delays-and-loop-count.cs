using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.gif";
        string outputPath = "output/output.webp";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (GifImage gif = (GifImage)Image.Load(inputPath))
            {
                int loopCount = 0;
                try { loopCount = gif.LoopsCount; } catch { }

                WebPOptions webpOptions = new WebPOptions
                {
                    AnimLoopCount = (ushort)loopCount,
                    Lossless = false,
                    Quality = 80f
                };

                using (WebPImage webp = new WebPImage(gif.Width, gif.Height, webpOptions))
                {
                    foreach (var block in gif.Blocks)
                    {
                        if (block is GifFrameBlock frameBlock)
                        {
                            gif.ActiveFrame = frameBlock;

                            using (MemoryStream ms = new MemoryStream())
                            {
                                gif.Save(ms, new PngOptions());
                                ms.Position = 0;

                                using (RasterImage raster = (RasterImage)Image.Load(ms))
                                {
                                    WebPFrameBlock webpBlock = new WebPFrameBlock(raster);
                                    webp.AddBlock(webpBlock);
                                }
                            }
                        }
                    }

                    webp.Save(outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}