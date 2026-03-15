using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input JPEG file path (first argument) or default.
        string inputPath = args.Length > 0 ? args[0] : "input.jpg";

        // Output JPEG file path (second argument) or default.
        string outputPath = args.Length > 1 ? args[1] : "output_sharpened.jpg";

        // Load the JPEG image.
        using (Image image = Image.Load(inputPath))
        {
            // Cast the loaded image to RasterImage to access filtering.
            RasterImage rasterImage = (RasterImage)image;

            // Apply a sharpen filter.
            // Kernel size = 5, sigma = 4.0 (adjust as needed).
            rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(5, 4.0));

            // Save the processed image.
            rasterImage.Save(outputPath);
        }
    }
}