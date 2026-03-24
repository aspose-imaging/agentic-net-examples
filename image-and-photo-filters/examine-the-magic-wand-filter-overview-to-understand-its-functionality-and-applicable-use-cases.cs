using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Simple magic wand usage: select region based on pixel (120,100) with custom threshold.
        string simpleInput = "input_simple.png";
        string simpleOutput = "output_simple.png";

        if (!File.Exists(simpleInput))
        {
            Console.Error.WriteLine($"File not found: {simpleInput}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(simpleOutput));

        using (RasterImage image = (RasterImage)Image.Load(simpleInput))
        {
            // Create mask and apply it directly to the image.
            MagicWandTool
                .Select(image, new MagicWandSettings(120, 100) { Threshold = 150 })
                .Apply();

            // Save result with alpha channel support.
            image.Save(simpleOutput, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
        }

        // Advanced magic wand usage: combine selections, invert, subtract rectangles, feather edges.
        string advancedInput = "input_advanced.png";
        string advancedOutput = "output_advanced.png";

        if (!File.Exists(advancedInput))
        {
            Console.Error.WriteLine($"File not found: {advancedInput}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(advancedOutput));

        using (RasterImage image = (RasterImage)Image.Load(advancedInput))
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

            // Save the processed image.
            image.Save(advancedOutput, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
        }
    }
}