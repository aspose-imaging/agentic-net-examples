using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output.png";

        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            MagicWandTool
                .Select(image, new MagicWandSettings(120, 100) { Threshold = 150 })
                .Union(new MagicWandSettings(200, 150))
                .Invert()
                .Subtract(new RectangleMask(0, 0, 80, 50))
                .GetFeathered(new FeatheringSettings() { Size = 3 })
                .Apply();

            image.Filter(image.Bounds, new GaussianBlurFilterOptions(5, 1.0));

            image.Save(outputPath, new PngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha
            });
        }
    }
}