using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

string inputPath = "input.apng";
string outputPath = "output_blur.apng";

using (Image image = Image.Load(inputPath))
{
    // Cast the loaded image to ApngImage to access APNG‑specific members
    ApngImage apngImage = (ApngImage)image;

    // Apply a Gaussian blur filter to the whole image (radius 5, sigma 4.0)
    apngImage.Filter(apngImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

    // Save the blurred image using APNG options (default settings)
    apngImage.Save(outputPath, new ApngOptions());
}