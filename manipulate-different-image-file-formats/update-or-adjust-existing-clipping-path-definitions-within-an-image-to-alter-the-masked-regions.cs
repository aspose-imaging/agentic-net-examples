using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output.png";

        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            MagicWandTool.Select(image, new MagicWandSettings(100, 100))
                .Union(new MagicWandSettings(200, 200))
                .Invert()
                .Subtract(new RectangleMask(0, 0, 50, 50))
                .GetFeathered(new FeatheringSettings() { Size = 5 })
                .Apply();

            image.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
        }
    }
}