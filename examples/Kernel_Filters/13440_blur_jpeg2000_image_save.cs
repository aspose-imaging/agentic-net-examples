using System;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Path to the folder containing the JPEG2000 image
        string dir = @"c:\temp\";

        // Load the JPEG2000 image
        using (Image image = Image.Load(dir + "sample.jp2"))
        {
            // Cast to RasterImage to access the Filter method
            RasterImage rasterImage = (RasterImage)image;

            // Apply a Gaussian blur filter to the entire image
            // Radius = 5, Sigma = 4.0
            rasterImage.Filter(
                rasterImage.Bounds,
                new GaussianBlurFilterOptions(5, 4.0));

            // Save the processed image as JPEG2000
            rasterImage.Save(
                dir + "sample_blur.jp2",
                new Jpeg2000Options());
        }
    }
}