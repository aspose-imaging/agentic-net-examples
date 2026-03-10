using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class SharpenJpegExample
{
    static void Main()
    {
        // Path to the source JPEG image
        string inputPath = "input.jpg";

        // Path where the sharpened JPEG will be saved
        string outputPath = "output_sharpened.jpg";

        // Load the JPEG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access filtering capabilities
            RasterImage raster = (RasterImage)image;

            // Apply a sharpen filter to the entire image.
            // Kernel size = 5, sigma = 4.0 (adjust as needed)
            raster.Filter(raster.Bounds, new SharpenFilterOptions(5, 4.0));

            // Save the processed image as JPEG (extension determines format)
            raster.Save(outputPath);
        }
    }
}