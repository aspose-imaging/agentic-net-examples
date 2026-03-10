using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class SharpenDibExample
{
    static void Main()
    {
        // Path to the folder containing the DIB image
        string dir = @"c:\temp\";

        // Load the DIB image
        using (Image image = Image.Load(dir + "sample.dib"))
        {
            // Cast to RasterImage to access filtering functionality
            RasterImage rasterImage = (RasterImage)image;

            // Apply a sharpen filter to the entire image.
            // Kernel size = 5, sigma = 4.0 (adjust as needed)
            rasterImage.Filter(
                rasterImage.Bounds,
                new SharpenFilterOptions(5, 4.0));

            // Save the processed image
            rasterImage.Save(dir + "sample.Sharpened.dib");
        }
    }
}