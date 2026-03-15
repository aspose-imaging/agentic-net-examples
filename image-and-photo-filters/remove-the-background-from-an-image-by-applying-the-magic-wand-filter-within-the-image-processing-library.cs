using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.MagicWand;

class Program
{
    static void Main()
    {
        // Paths to the source and destination images
        string inputPath = "input.png";
        string outputPath = "output.png";

        // Load the image as a RasterImage (required for Magic Wand processing)
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Create a mask using Magic Wand based on the color of pixel (120, 100)
            // The default threshold is used; you can adjust it via MagicWandSettings if needed
            MagicWandTool.Select(image, new MagicWandSettings(120, 100))
                .Apply(); // Apply the mask, making the selected background transparent

            // Save the resulting image with an alpha channel to preserve transparency
            image.Save(outputPath, new PngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha
            });
        }
    }
}