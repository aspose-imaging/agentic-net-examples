using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = args.Length > 0 ? args[0] : "input.png";
        string outputPath = args.Length > 1 ? args[1] : "output.apng";

        // Load the source image
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Create and apply a custom mask using MagicWand
            MagicWandTool
                .Select(image, new MagicWandSettings(100, 100))
                .Union(new MagicWandSettings(200, 200))
                .Invert()
                .Subtract(new MagicWandSettings(150, 150) { Threshold = 50 })
                .Subtract(new RectangleMask(0, 0, 800, 150))
                .Subtract(new RectangleMask(0, 380, 600, 220))
                .Subtract(new RectangleMask(930, 520, 110, 40))
                .Subtract(new RectangleMask(1370, 400, 120, 200))
                .GetFeathered(new FeatheringSettings() { Size = 3 })
                .Apply();

            // Save the masked image as an animated PNG (APNG) preserving transparency
            image.Save(outputPath, new ApngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha,
                DefaultFrameTime = 200,
                NumPlays = 0 // infinite loop
            });
        }
    }
}