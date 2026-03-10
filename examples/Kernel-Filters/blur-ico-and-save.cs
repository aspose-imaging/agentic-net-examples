using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Input ICO file path
        string inputPath = "input.ico";
        // Output PNG file path
        string outputPath = "output.png";

        // Load the ICO image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to apply filters
            RasterImage raster = (RasterImage)image;

            // Apply Gaussian blur filter to the entire image
            raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

            // Save the processed image as PNG
            raster.Save(outputPath, new PngOptions());
        }
    }
}