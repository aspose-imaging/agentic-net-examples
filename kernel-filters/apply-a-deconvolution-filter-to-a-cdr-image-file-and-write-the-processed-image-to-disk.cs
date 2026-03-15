using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class DeconvolutionExample
{
    static void Main()
    {
        // Path to the source CDR file
        string inputPath = "input.cdr";

        // Path where the processed image will be saved
        string outputPath = "output.png";

        // Load the CDR image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to gain access to the Filter method
            RasterImage rasterImage = (RasterImage)image;

            // Create deconvolution filter options (Gauss‑Wiener filter)
            // Parameters: radius = 5, sigma = 4.0
            var deconvOptions = new GaussWienerFilterOptions(5, 4.0);

            // Apply the filter to the whole image
            rasterImage.Filter(rasterImage.Bounds, deconvOptions);

            // Save the processed image as PNG
            rasterImage.Save(outputPath, new PngOptions());
        }
    }
}