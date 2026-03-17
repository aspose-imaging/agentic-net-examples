using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output file paths
        string inputPath = "input.png";
        string outputPath = "output.png";

        // Load the image as a raster image
        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;

            // Create bilateral smoothing filter options with a kernel size of 5
            var filterOptions = new BilateralSmoothingFilterOptions(5);
            // Adjust additional properties if needed
            filterOptions.ColorFactor = 1.0;
            filterOptions.SpatialFactor = 1.0;

            // Apply the smoothing filter to the entire image
            raster.Filter(raster.Bounds, filterOptions);

            // Save the processed image as PNG
            var pngOptions = new PngOptions();
            raster.Save(outputPath, pngOptions);
        }
    }
}