using System;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class DeconvolutionExample
{
    static void Main()
    {
        // Path to the folder containing the DIB image
        string dir = @"c:\temp\";

        // Load the DIB image (it will be loaded as a RasterImage)
        using (Image image = Image.Load(dir + "sample.dib"))
        {
            // Cast to RasterImage to access the Filter method
            RasterImage rasterImage = (RasterImage)image;

            // Create a Gaussian deconvolution filter (Gauss-Wiener) with radius 5 and sigma 4.0
            var deconvOptions = new GaussWienerFilterOptions(5, 4.0);

            // Optional: set the filter to work in grayscale mode
            deconvOptions.Grayscale = true;

            // Apply the filter to the entire image
            rasterImage.Filter(rasterImage.Bounds, deconvOptions);

            // Save the processed image
            rasterImage.Save(dir + "sample.Deconvolution.png");
        }
    }
}