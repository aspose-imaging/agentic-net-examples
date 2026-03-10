using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        // Paths to the input and output images
        string inputPath = "input.png";
        string outputPath = "output.png";

        // Load the image as a RasterImage
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Create a mask using Magic Wand at point (120, 100) with a custom threshold
            MagicWandTool
                .Select(image, new MagicWandSettings(120, 100) { Threshold = 150 })
                .Apply(); // Apply the mask to the image

            // Save the resulting image with an alpha channel
            image.Save(outputPath, new PngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha
            });
        }
    }
}