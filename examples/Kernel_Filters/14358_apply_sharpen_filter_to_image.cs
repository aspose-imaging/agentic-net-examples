using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class SharpenFilterExample
{
    static void Main()
    {
        // Path to the folder containing the source image
        string dir = @"c:\temp\";

        // Load the source image
        using (Image image = Image.Load(dir + "sample.png"))
        {
            // Cast to RasterImage to access filtering functionality
            RasterImage rasterImage = (RasterImage)image;

            // Apply a sharpen filter with kernel size 5 and sigma 4.0 to the whole image
            rasterImage.Filter(
                rasterImage.Bounds,
                new SharpenFilterOptions(5, 4.0));

            // Save the processed image
            rasterImage.Save(dir + "sample.SharpenFilter.png");
        }
    }
}