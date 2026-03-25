using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main()
    {
        string inputPath = "input.apng";
        string outputPath = "output.gif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image loadedImage = Image.Load(inputPath))
        using (ApngImage apngImage = (ApngImage)loadedImage)
        {
            using (GifImage gifImage = new GifImage(new GifFrameBlock((ushort)apngImage.Width, (ushort)apngImage.Height)))
            {
                for (int i = 0; i < apngImage.PageCount; i++)
                {
                    gifImage.AddPage((RasterImage)apngImage.Pages[i]);
                }

                gifImage.Save(outputPath, new GifOptions());
            }
        }
    }
}