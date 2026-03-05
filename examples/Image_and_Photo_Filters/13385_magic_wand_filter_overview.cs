using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Paths for input and output images
        string inputPath = "input.png";
        string outputSimplePath = "output_simple.png";
        string outputComplexPath = "output_complex.png";

        // Simple Magic Wand selection: select area around point (120,100) with custom threshold
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            MagicWandTool
                .Select(image, new MagicWandSettings(120, 100) { Threshold = 150 })
                .Apply();

            // Save result with alpha channel support
            image.Save(outputSimplePath, new PngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha,
                Source = new FileCreateSource(outputSimplePath, false)
            });
        }

        // Complex Magic Wand workflow: union, invert, subtract, rectangle subtraction, feathering, then apply
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            MagicWandTool
                .Select(image, new MagicWandSettings(845, 128))
                .Union(new MagicWandSettings(416, 387))
                .Invert()
                .Subtract(new MagicWandSettings(1482, 346) { Threshold = 69 })
                .Subtract(new RectangleMask(0, 0, 800, 150))
                .Subtract(new RectangleMask(0, 380, 600, 220))
                .Subtract(new RectangleMask(930, 520, 110, 40))
                .Subtract(new RectangleMask(1370, 400, 120, 200))
                .GetFeathered(new FeatheringSettings { Size = 3 })
                .Apply();

            // Save the complex result
            image.Save(outputComplexPath, new PngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha,
                Source = new FileCreateSource(outputComplexPath, false)
            });
        }
    }
}