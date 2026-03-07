using System;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class DeconvolutionExample
{
    static void Main()
    {
        // Path to the source WMZ image
        string inputPath = @"C:\temp\sample.wmz";

        // Path where the filtered image will be saved (PNG format)
        string outputPath = @"C:\temp\sample.Deconvolution.png";

        // Load the WMZ image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access the Filter method
            RasterImage rasterImage = (RasterImage)image;

            // Apply a Gauss-Wiener deconvolution filter to the whole image.
            // Radius = 5, Sigma = 4.0 are typical values; adjust as needed.
            rasterImage.Filter(
                rasterImage.Bounds,
                new GaussWienerFilterOptions(5, 4.0));

            // Save the result as PNG
            rasterImage.Save(outputPath, new PngOptions());
        }
    }
}