using System;
using System.Drawing; // For Rectangle
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Avif;

class Program
{
    static void Main()
    {
        // Path to the source AVIF image
        string inputPath = @"c:\temp\sample.avif";
        // Path where the sharpened image will be saved
        string outputPath = @"c:\temp\sample_sharpened.avif";

        // Load the AVIF image using Aspose.Imaging
        using (Image image = Image.Load(inputPath))
        {
            // Cast the loaded image to RasterImage to access filtering functionality
            RasterImage rasterImage = (RasterImage)image;

            // Apply a sharpen filter to the entire image.
            // Kernel size = 5, sigma = 4.0 (adjust as needed)
            rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(5, 4.0));

            // Save the processed image back to AVIF format
            rasterImage.Save(outputPath);
        }
    }
}