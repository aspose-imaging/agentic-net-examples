using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

// Load the raster image
string inputPath = "input.png";
using (RasterImage image = (RasterImage)Image.Load(inputPath))
{
    // Define the reference point for the magic wand selection (example: pixel at (150, 80))
    int referenceX = 150;
    int referenceY = 80;

    // Configure magic wand settings:
    // - Threshold determines color similarity tolerance.
    // - ContiguousMode = true ensures only connected pixels are selected.
    var settings = new MagicWandSettings(referenceX, referenceY)
    {
        Threshold = 120,
        ContiguousMode = true
    };

    // Create a mask based on the settings and apply it to the image.
    MagicWandTool
        .Select(image, settings)   // generate mask
        .Apply();                  // apply mask (makes selected area transparent)

    // Save the resulting image with alpha channel preserved.
    string outputPath = "output.png";
    image.Save(outputPath, new PngOptions
    {
        ColorType = PngColorType.TruecolorWithAlpha
    });
}