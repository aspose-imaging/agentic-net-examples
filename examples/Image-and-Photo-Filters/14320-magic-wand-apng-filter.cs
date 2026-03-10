using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.MagicWand;

// Load the APNG image
string inputPath = "input.apng";
string outputPath = "output.png";

using (ApngImage apng = (ApngImage)Image.Load(inputPath))
{
    // Create a magic‑wand mask based on the pixel at (50,30) with a custom threshold
    var mask = MagicWandTool.Select(apng, new MagicWandSettings(50, 30) { Threshold = 120 });

    // Apply the mask to the image (selected area becomes transparent)
    mask.Apply();

    // Apply a median filter to the entire image (or you could use apng.Bounds for the whole image)
    apng.Filter(apng.Bounds, new MedianFilterOptions(5));

    // Save the processed image as PNG
    apng.Save(outputPath, new Aspose.Imaging.ImageOptions.PngOptions());
}