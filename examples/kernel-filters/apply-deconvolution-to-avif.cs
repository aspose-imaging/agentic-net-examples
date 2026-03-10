using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        // Paths for input AVIF image and output JPEG image
        string inputPath = "input.avif";
        string outputPath = "output.jpg";

        // Load the AVIF image; Image.Load returns a generic Image instance
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access raster operations
            RasterImage raster = (RasterImage)image;

            // Create a Gauss-Wiener deconvolution filter (derived from DeconvolutionFilterOptions)
            // Parameters: radius = 5, sigma = 4.0
            var deconvOptions = new GaussWienerFilterOptions(5, 4.0);

            // Apply the deconvolution filter to the entire image
            raster.Filter(raster.Bounds, deconvOptions);

            // Save the processed image as JPEG (AVIF saving options are not available)
            var jpegOptions = new JpegOptions
            {
                Quality = 90
            };
            raster.Save(outputPath, jpegOptions);
        }
    }
}