using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.ImageFilters.FilterOptions;

string dir = @"c:\temp\";

// Load the APNG image
using (Image image = Image.Load(dir + "sample.apng"))
{
    // Cast to ApngImage to access APNG‑specific members
    ApngImage apngImage = (ApngImage)image;

    // Apply a Gaussian blur filter to the whole image
    // Rectangle covering the entire image is obtained via apngImage.Bounds
    // Radius = 5, Sigma = 4.0
    apngImage.Filter(apngImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

    // Save the filtered APNG back to disk
    apngImage.Save(dir + "sample.GaussianBlur.apng");
}