using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

string inputPath = "input.apng";
string outputPath = "output.apng";

using (Image image = Image.Load(inputPath))
{
    // Cast the loaded image to ApngImage to work with animation frames
    ApngImage apngImage = (ApngImage)image;

    // Apply Gaussian blur to each frame of the APNG
    foreach (ApngFrame frame in apngImage.Pages)
    {
        // The frame behaves like a raster image, so we can use the Filter method
        // Apply a Gaussian blur with radius 5 and sigma 4.0 to the whole frame
        frame.Filter(frame.Bounds, new GaussianBlurFilterOptions(5, 4.0));
    }

    // Save the processed APNG back to a file, preserving animation settings
    apngImage.Save(outputPath, new ApngOptions());
}