using System;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class SharpenAvifExample
{
    static void Main()
    {
        // Path to the source AVIF image
        string inputPath = @"C:\Images\input.avif";

        // Path where the sharpened image will be saved
        string outputPath = @"C:\Images\output_sharpened.avif";

        // Load the AVIF image using Aspose.Imaging's load rule
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access filtering functionality
            RasterImage rasterImage = (RasterImage)image;

            // Apply a sharpen filter to the entire image bounds
            // Kernel size = 5, sigma = 4.0 (as per example documentation)
            rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(5, 4.0));

            // Save the processed image using Aspose.Imaging's save rule
            rasterImage.Save(outputPath);
        }
    }
}