using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.gif";
        string outputPath = "output.webp";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Aspose.Imaging.Image gif = Aspose.Imaging.Image.Load(inputPath))
        {
            var webpOptions = new WebPOptions();

            var gifImg = gif as GifImage;
            if (gifImg != null)
            {
                webpOptions.AnimLoopCount = (ushort)gifImg.LoopsCount;
            }

            var multipage = gif as Aspose.Imaging.IMultipageImage;
            if (multipage != null)
            {
                webpOptions.MultiPageOptions = new MultiPageOptions(new Aspose.Imaging.IntRange(0, multipage.PageCount));
            }

            gif.Save(outputPath, webpOptions);
        }
    }
}