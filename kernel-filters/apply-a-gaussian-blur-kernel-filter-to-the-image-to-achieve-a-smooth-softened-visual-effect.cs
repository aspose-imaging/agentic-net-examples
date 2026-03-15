using System;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output file paths
        string inputPath = "input.jpg";
        string outputPath = "output_gaussian_blur.jpg";

        // Load the image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage for filtering
            RasterImage raster = (RasterImage)image;

            // Apply Gaussian blur with kernel size 5 and sigma 4.0
            raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

            // Save the processed image
            raster.Save(outputPath);
        }
    }
}