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
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image and apply a complex Magic Wand mask
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
                .GetFeathered(new FeatheringSettings() { Size = 3 })
                .Apply();

            // Save the result with transparency support
            image.Save(outputPath, new PngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha
            });
        }
    }
}