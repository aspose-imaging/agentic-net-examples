using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class MagicWandExample
{
    static void Main()
    {
        // Paths to the source and destination images
        string inputPath = "input.png";
        string outputPath = "output.png";

        // Load the image (any supported raster format)
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Create a mask using Magic Wand based on the color of pixel (120, 100)
            // and a custom tolerance (threshold) of 150
            ImageMask mask = MagicWandTool.Select(
                image,
                new MagicWandSettings(120, 100) { Threshold = 150 });

            // Apply the mask to the image – the selected region becomes transparent
            mask.Apply();

            // Save the modified image, preserving the alpha channel
            image.Save(outputPath, new PngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha
            });
        }
    }
}