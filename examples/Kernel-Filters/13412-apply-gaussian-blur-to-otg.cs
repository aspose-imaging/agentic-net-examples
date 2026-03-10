using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Path to the folder containing the OTG image
        string dir = @"c:\temp\";

        // Load the OTG image
        using (Image image = Image.Load(dir + "sample.otg"))
        {
            // Cast to RasterImage to access the Filter method
            RasterImage rasterImage = (RasterImage)image;

            // Apply Gaussian blur with kernel size 5 and sigma 4.0 to the whole image
            rasterImage.Filter(
                rasterImage.Bounds,
                new GaussianBlurFilterOptions(5, 4.0));

            // Save the processed image (same format, OTG)
            rasterImage.Save(dir + "sample.GaussianBlur.otg");
        }
    }
}