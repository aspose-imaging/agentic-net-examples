using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.ImageFilters.FilterOptions;

string inputPath = "input.apng";
string outputPath = "output.apng";

using (Image image = Image.Load(inputPath))
{
    // Cast the loaded image to ApngImage to access APNG‑specific functionality
    ApngImage apngImage = (ApngImage)image;

    // Apply a motion blur (motion Wiener) filter to the whole image.
    // Parameters: length (kernel size), sigma (smoothness), angle (degrees)
    apngImage.Filter(apngImage.Bounds, new MotionWienerFilterOptions(10, 1.0, 90.0));

    // Save the modified APNG image
    apngImage.Save(outputPath);
}