using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input AVIF image path
        string inputPath = "input.avif";
        // Output JPEG image path (AVIF saving not supported, fallback to JPEG)
        string outputPath = "output.jpg";

        // Load the AVIF image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access filtering methods
            RasterImage raster = (RasterImage)image;

            // Apply Gaussian blur with radius 5 and sigma 4.0 to the whole image
            raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Prepare JPEG save options
            JpegOptions jpegOptions = new JpegOptions
            {
                Quality = 90
            };

            // Save the processed image as JPEG
            raster.Save(outputPath, jpegOptions);
        }
    }
}