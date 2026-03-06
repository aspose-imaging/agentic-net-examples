using System;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class DeconvolutionExample
{
    static void Main()
    {
        // Path to the folder containing the EMZ image.
        string dataDir = @"c:\temp\";

        // Load the EMZ image.
        using (Image image = Image.Load(dataDir + "sample.emz"))
        {
            // Cast to RasterImage to gain access to the Filter method.
            RasterImage rasterImage = (RasterImage)image;

            // Create a Gaussian Wiener deconvolution filter.
            // Parameters: radius = 5, sigma = 4.0 (you can adjust as needed).
            var deconvOptions = new GaussWienerFilterOptions(5, 4.0)
            {
                // Apply the filter in grayscale mode (optional).
                Grayscale = true
            };

            // Apply the filter to the whole image.
            rasterImage.Filter(rasterImage.Bounds, deconvOptions);

            // Save the processed image. Here we save as PNG, but you can choose another format.
            rasterImage.Save(dataDir + "sample_deconvolved.png", new PngOptions());
        }
    }
}