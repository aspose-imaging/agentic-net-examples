using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        // Paths for input DIB image and output result
        string inputPath = "input.dib";
        string outputPath = "output.dib";

        // Load the DIB image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access filtering capabilities
            RasterImage rasterImage = (RasterImage)image;

            // Apply an edge detection effect using Sharpen filter (kernel size 5, sigma 4.0)
            rasterImage.Filter(rasterImage.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));

            // Save the processed image in DIB (BMP) format
            rasterImage.Save(outputPath, new BmpOptions());
        }
    }
}