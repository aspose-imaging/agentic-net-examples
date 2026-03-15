using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class MagicWandDemo
{
    static void Main()
    {
        // Paths to the source and result images
        string inputPath = "input.png";
        string outputPath = "output.png";

        // Load the raster image (using the provided load rule)
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Create a mask with the Magic Wand tool based on the pixel at (120, 100)
            // and a custom tolerance (threshold) of 150
            MagicWandTool
                .Select(image, new MagicWandSettings(120, 100) { Threshold = 150 })
                .Apply(); // Apply the mask to the image

            // Save the resulting image (using the provided save rule)
            // PNG format with truecolor + alpha to preserve transparency introduced by the mask
            image.Save(outputPath, new PngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha
            });
        }
    }
}