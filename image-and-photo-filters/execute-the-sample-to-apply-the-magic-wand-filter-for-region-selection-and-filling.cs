using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class MagicWandExample
{
    static void Main()
    {
        // Input and output file paths
        string inputFilePath = "input.png";
        string outputFilePath = "output.png";

        // Load the raster image
        using (RasterImage image = (RasterImage)Image.Load(inputFilePath))
        {
            // Create a mask using Magic Wand tool.
            // The reference point is (120, 100) and the tolerance threshold is set to 150.
            ImageBitMask mask = MagicWandTool.Select(
                image,
                new MagicWandSettings(120, 100) { Threshold = 150 }
            );

            // Apply the mask to the image (makes the selected region transparent).
            mask.Apply();

            // Save the resulting image with an alpha channel (Truecolor with Alpha).
            image.Save(
                outputFilePath,
                new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha
                }
            );
        }
    }
}