using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class SharpenBmpExample
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = @"C:\Images\sample.bmp";
        string outputPath = @"C:\Images\sample_sharpened.bmp";

        // Load the BMP image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access raster-specific methods
            RasterImage rasterImage = (RasterImage)image;

            // Apply a sharpen filter to the entire image.
            // Kernel size = 5, sigma = 4.0 (adjust as needed)
            rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(5, 4.0));

            // Save the processed image to a new BMP file
            rasterImage.Save(outputPath);
        }
    }
}