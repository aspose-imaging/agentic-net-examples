using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.MagicWand;

class MagicWandIsolation
{
    static void Main()
    {
        // Paths to the source and destination images
        string inputPath = "input.jpg";
        string outputPath = "output.png";

        // Load the raster image
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Settings for the magic wand:
            // - Reference point (150, 200) – the pixel whose color we want to isolate
            // - Threshold defines how tolerant the selection is (higher = more colors)
            // - ContiguousMode = true selects only connected pixels
            // - ColorCompareMode = RgbDefault uses standard RGB distance
            var wandSettings = new MagicWandSettings(150, 200)
            {
                Threshold = 100,
                ContiguousMode = true,
                ColorCompareMode = ColorComparisonMode.RgbDefault
            };

            // Create a mask based on the reference color and apply it to the image
            MagicWandTool
                .Select(image, wandSettings)
                .Apply();

            // Save the resulting image with an alpha channel so the isolated region stays visible
            image.Save(outputPath, new PngOptions()
            {
                ColorType = PngColorType.TruecolorWithAlpha
            });
        }
    }
}