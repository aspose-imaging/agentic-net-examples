using System;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class DeconvolutionExample
{
    static void Main()
    {
        // Input WMF file path
        string inputPath = @"C:\Temp\sample.wmf";
        // Output PNG file path
        string outputPath = @"C:\Temp\sample.Deconvolution.png";

        // Load the WMF image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access the Filter method
            RasterImage rasterImage = (RasterImage)image;

            // Create deconvolution filter options (Gauss-Wiener is a deconvolution filter)
            // Parameters: radius = 5, sigma = 4.0 (adjust as needed)
            var deconvOptions = new GaussWienerFilterOptions(5, 4.0);

            // Apply the filter to the entire image
            rasterImage.Filter(rasterImage.Bounds, deconvOptions);

            // Save the processed image as PNG
            rasterImage.Save(outputPath, new PngOptions());
        }
    }
}