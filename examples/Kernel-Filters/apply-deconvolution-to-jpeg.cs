using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;
using System.Drawing;

class DeconvolutionExample
{
    static void Main()
    {
        // Path to the source JPEG image
        string inputPath = @"C:\Images\input.jpg";

        // Path where the processed image will be saved
        string outputPath = @"C:\Images\output_deconvolved.jpg";

        // Load the JPEG image using Aspose.Imaging's load method
        using (Image image = Image.Load(inputPath))
        {
            // Cast the loaded image to RasterImage to access the Filter method
            RasterImage rasterImage = (RasterImage)image;

            // Create a deconvolution filter option.
            // Here we use GaussWienerFilterOptions (derived from DeconvolutionFilterOptions)
            // Radius = 5, Sigma = 4.0 are example values; adjust as needed.
            var deconvOptions = new GaussWienerFilterOptions(5, 4.0);

            // Apply the filter to the entire image rectangle
            rasterImage.Filter(rasterImage.Bounds, deconvOptions);

            // Save the result as a JPEG using Aspose.Imaging's save method
            rasterImage.Save(outputPath, new JpegOptions());
        }
    }
}