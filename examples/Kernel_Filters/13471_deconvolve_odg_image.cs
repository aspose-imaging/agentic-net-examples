using System;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats;

class DeconvolutionExample
{
    static void Main()
    {
        // Path to the folder containing the ODG image
        string dir = @"C:\temp\";

        // Load the ODG image. Aspose.Imaging automatically detects the format.
        using (Image image = Image.Load(dir + "sample.odg"))
        {
            // Cast to RasterImage to gain access to the Filter method
            RasterImage rasterImage = (RasterImage)image;

            // Create a Gaussian Wiener deconvolution filter.
            // Parameters: radius = 5, sigma = 4.0 (adjust as needed)
            var deconvOptions = new GaussWienerFilterOptions(5, 4.0);

            // Apply the filter to the whole image area
            rasterImage.Filter(rasterImage.Bounds, deconvOptions);

            // Save the processed image as PNG
            rasterImage.Save(dir + "sample_deconvolution.png", new PngOptions());
        }
    }
}