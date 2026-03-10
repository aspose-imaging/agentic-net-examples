using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output file paths
        string inputPath = "input.png";
        string outputPath = "output.GaussianBlur.png";

        // Load the image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage for filtering
            RasterImage rasterImage = (RasterImage)image;

            // Apply Gaussian blur with radius 5 and sigma 4.0
            rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Save the filtered image
            rasterImage.Save(outputPath);
        }
    }
}