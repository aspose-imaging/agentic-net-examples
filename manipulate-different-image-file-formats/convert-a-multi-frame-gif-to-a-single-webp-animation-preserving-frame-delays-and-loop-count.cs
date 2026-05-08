using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\animation.gif";
        string outputPath = "Output\\animation.webp";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Aspose.Imaging.Image gifImage = Aspose.Imaging.Image.Load(inputPath))
            {
                var gif = (GifImage)gifImage;
                int frameCount = gif.PageCount;

                var webpOptions = new WebPOptions();
                // Preserve loop count if available; default is 1.
                // webpOptions.AnimLoopCount = gif.LoopsCount; // Uncomment if GifImage exposes LoopsCount

                using (WebPImage webp = new WebPImage(gif.Width, gif.Height, webpOptions))
                {
                    for (int i = 0; i < frameCount; i++)
                    {
                        gif.ActiveFrame = (GifFrameBlock)gif.Pages[i];
                        var block = new WebPFrameBlock((Aspose.Imaging.RasterImage)gif.ActiveFrame);
                        // Frame delay preservation would be set here if WebPFrameBlock exposes a duration property.
                        webp.AddBlock(block);
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