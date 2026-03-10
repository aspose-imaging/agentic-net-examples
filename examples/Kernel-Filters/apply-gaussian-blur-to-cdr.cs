using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Input CDR file and output PNG file paths
        string inputPath = @"c:\temp\sample.cdr";
        string outputPath = @"c:\temp\sample.GaussianBlur.png";

        // Load the CDR image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to enable raster filters
            RasterImage rasterImage = (RasterImage)image;

            // Apply Gaussian blur (kernel size = 5, sigma = 4.0) to the entire image
            rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Save the result as PNG
            rasterImage.Save(outputPath, new PngOptions());
        }
    }
}