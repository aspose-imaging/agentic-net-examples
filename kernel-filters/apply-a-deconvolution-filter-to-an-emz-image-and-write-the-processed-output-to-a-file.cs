using System;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf; // EMZ is handled as EMF image format

class DeconvolutionExample
{
    static void Main()
    {
        // Path to the source EMZ image
        string inputPath = @"C:\Images\sample.emz";

        // Path for the processed output image
        string outputPath = @"C:\Images\sample_deconvolved.png";

        // Load the EMZ image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access the Filter method
            RasterImage rasterImage = (RasterImage)image;

            // Apply a Gauss-Wiener deconvolution filter to the entire image
            // Parameters: radius = 5, sigma = 4.0 (adjust as needed)
            rasterImage.Filter(
                rasterImage.Bounds,
                new GaussWienerFilterOptions(5, 4.0));

            // Save the processed image as PNG
            rasterImage.Save(outputPath, new PngOptions());
        }
    }
}