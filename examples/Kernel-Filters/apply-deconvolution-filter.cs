using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class DeconvolutionFilterExample
{
    static void Main()
    {
        // Path to the folder containing the source image.
        string dataDir = @"c:\temp\";

        // Load the image.
        using (Image image = Image.Load(dataDir + "sample.png"))
        {
            // Cast to RasterImage to access the Filter method.
            RasterImage rasterImage = (RasterImage)image;

            // Apply a Gauss‑Wiener deconvolution filter.
            // Radius = 5, Sigma = 4.0 (these values can be adjusted as needed).
            rasterImage.Filter(
                rasterImage.Bounds,
                new GaussWienerFilterOptions(5, 4.0));

            // Save the filtered image.
            rasterImage.Save(dataDir + "sample.GaussWienerFilter.png", new PngOptions());
        }
    }
}