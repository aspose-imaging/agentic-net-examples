using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input BMP file path
        string inputPath = "input.bmp";
        // Output BMP file path
        string outputPath = "output.bmp";

        // Load the BMP image as a raster image
        using (Image image = Image.Load(inputPath))
        {
            RasterImage rasterImage = (RasterImage)image;

            // Apply Gaussian blur with radius 5 and sigma 4.0 to the entire image
            rasterImage.Filter(rasterImage.Bounds,
                new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

            // Save the result as BMP
            BmpOptions bmpOptions = new BmpOptions();
            rasterImage.Save(outputPath, bmpOptions);
        }
    }
}