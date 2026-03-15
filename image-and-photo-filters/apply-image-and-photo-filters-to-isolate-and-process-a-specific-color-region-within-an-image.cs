using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.png";
        string outputPath = "output.png";

        // Coordinates of the reference pixel and tolerance for the magic wand selection
        int referenceX = 120;
        int referenceY = 100;
        int tolerance = 150;

        // Load the image as a raster image
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Create a mask based on the color of the reference pixel, feather it, and apply it
            MagicWandTool
                .Select(image, new MagicWandSettings(referenceX, referenceY) { Threshold = tolerance })
                .GetFeathered(new FeatheringSettings() { Size = 2 })
                .Apply();

            // Adjust brightness and contrast of the isolated region
            image.AdjustBrightness(40);          // Increase brightness
            image.AdjustContrast(0.25f);        // Increase contrast

            // Save the processed image with alpha channel support
            image.Save(outputPath, new PngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha
            });
        }
    }
}