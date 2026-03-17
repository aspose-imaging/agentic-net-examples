using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.gif";
        string outputPath = "output.gif";

        using (Image image = Image.Load(inputPath))
        {
            if (image is IMultipageImage)
            {
                GifOptions saveOptions = new GifOptions
                {
                    FullFrame = true
                };
                image.Save(outputPath, saveOptions);
            }
        }
    }
}