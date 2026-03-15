using System;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output.png";

        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
        {
            PngOptions pngOptions = new PngOptions
            {
                BitDepth = 8,
                ColorType = PngColorType.TruecolorWithAlpha
            };
            image.Save(outputPath, pngOptions);
        }
    }
}