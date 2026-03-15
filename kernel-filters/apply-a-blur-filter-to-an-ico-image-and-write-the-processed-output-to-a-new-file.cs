using System;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.ico";
        string outputPath = "output.ico";

        // Load the ICO image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to apply filters
            RasterImage raster = (RasterImage)image;

            // Apply Gaussian blur with radius 5 and sigma 4.0 to the whole image
            raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

            // Save the processed image as ICO
            raster.Save(outputPath);
        }
    }
}