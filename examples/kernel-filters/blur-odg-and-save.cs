using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.OpenDocument;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging;

// Load the ODG image from file
string inputPath = "input.odg";
string outputPath = "output.odg";

using (Image image = Image.Load(inputPath))
{
    // Cast the loaded image to OdgImage to access ODG-specific features
    OdgImage odgImage = (OdgImage)image;

    // Iterate through each page (vector page is rasterized internally) and apply a Gaussian blur filter
    foreach (Image page in odgImage.Pages)
    {
        // Each page can be treated as a RasterImage for pixel-level operations
        RasterImage rasterPage = (RasterImage)page;

        // Apply Gaussian blur with radius 5 and sigma 4.0 to the whole page
        rasterPage.Filter(rasterPage.Bounds, new GaussianBlurFilterOptions(5, 4.0));
    }

    // Save the modified ODG image back to disk
    odgImage.Save(outputPath);
}