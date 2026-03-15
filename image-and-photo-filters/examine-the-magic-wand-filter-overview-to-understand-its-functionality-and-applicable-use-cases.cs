using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

public class Program
{
    public static void Main(string[] args)
    {
        // Input and output image paths
        string inputPath = "input.png";
        string outputPath = "output.png";

        // Load the source image as a RasterImage
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Build a mask using MagicWandTool:
            // - Start from a seed point (120,100) with a custom threshold
            // - Union with another seed point to enlarge the selection
            // - Invert to select the opposite region
            // - Subtract a rectangular area from the mask
            // - Feather the edges for smooth transition
            // - Apply the mask to the image
            MagicWandTool
                .Select(image, new MagicWandSettings(120, 100) { Threshold = 150 })
                .Union(new MagicWandSettings(416, 387))
                .Invert()
                .Subtract(new RectangleMask(0, 0, 800, 150))
                .GetFeathered(new FeatheringSettings() { Size = 3 })
                .Apply();

            // Save the processed image with PNG options preserving alpha channel
            var pngOptions = new PngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha
            };
            image.Save(outputPath, pngOptions);
        }
    }
}