using System;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Path to the folder containing the source DIB image
        string dir = @"c:\temp\";

        // Load the DIB image
        using (Image image = Image.Load(dir + "sample.dib"))
        {
            // Cast to RasterImage to access filtering capabilities
            RasterImage raster = (RasterImage)image;

            // Apply a Gaussian blur filter (radius = 5, sigma = 4.0) to the entire image
            raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Save the processed image as PNG
            raster.Save(dir + "sample.Blur.png", new PngOptions());
        }
    }
}