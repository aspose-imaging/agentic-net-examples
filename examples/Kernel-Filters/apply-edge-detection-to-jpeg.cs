using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.jpg";
        string outputPath = "output.jpg";

        // Load the JPEG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to apply filters
            RasterImage rasterImage = (RasterImage)image;

            // Apply a sharpen filter (used here for edge detection)
            // Kernel size = 5, sigma = 4.0
            rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(5, 4.0));

            // Save the processed image as JPEG with default options
            JpegOptions jpegOptions = new JpegOptions();
            jpegOptions.Quality = 90; // optional quality setting
            image.Save(outputPath, jpegOptions);
        }
    }
}