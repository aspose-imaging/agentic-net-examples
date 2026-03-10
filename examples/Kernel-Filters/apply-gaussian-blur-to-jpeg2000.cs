using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Path to the folder containing the JPEG2000 image
        string dir = @"c:\temp\";

        // Load the JPEG2000 image
        using (Image image = Image.Load(dir + "sample.jp2"))
        {
            // Cast to RasterImage to access filtering functionality
            RasterImage rasterImage = (RasterImage)image;

            // Apply Gaussian blur with kernel size 5 and sigma 4.0 to the whole image
            rasterImage.Filter(
                rasterImage.Bounds,
                new GaussianBlurFilterOptions(5, 4.0));

            // Save the processed image back as JPEG2000
            rasterImage.Save(dir + "sample.GaussianBlur.jp2");
        }
    }
}