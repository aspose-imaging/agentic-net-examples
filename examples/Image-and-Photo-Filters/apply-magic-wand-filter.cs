using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.MagicWand;

class Program
{
    static void Main()
    {
        // Path to the source image (any supported format, e.g., PNG, JPEG, BMP)
        string inputPath = "input.png";

        // Path where the modified image will be saved
        string outputPath = "output.png";

        // Load the image as a RasterImage to enable pixel-level operations
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Create a magic wand mask based on the color of the pixel at (100, 150)
            // Threshold defines how tolerant the selection is to color differences
            MagicWandTool.Select(image, new MagicWandSettings(100, 150) { Threshold = 120 })
                // Invert the mask so that the area *outside* the original selection is affected
                .Invert()
                // Apply the mask to the image – the selected region becomes transparent
                .Apply();

            // Save the resulting image, preserving the alpha channel (transparency)
            image.Save(outputPath, new PngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha
            });
        }
    }
}