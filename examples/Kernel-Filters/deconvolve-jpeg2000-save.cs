using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Jpeg2000; // Namespace for JPEG2000 support (if needed)

class DeconvolutionExample
{
    static void Main()
    {
        // Define input and output file paths
        string inputPath = @"C:\temp\sample.jp2";
        string outputPath = @"C:\temp\sample_deconvolved.jp2";

        // Load the JPEG2000 image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access the Filter method
            RasterImage rasterImage = (RasterImage)image;

            // Apply a Gauss‑Wiener deconvolution filter to the whole image.
            // Radius = 5, Sigma = 4.0 (these values can be adjusted as needed)
            rasterImage.Filter(
                rasterImage.Bounds,
                new GaussWienerFilterOptions(5, 4.0));

            // Save the processed image back to JPEG2000 format
            rasterImage.Save(outputPath);
        }
    }
}