using System;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Input JPEG2000 file path
        string inputPath = "input.jp2";

        // Output file path for the blurred image
        string outputPath = "output_blurred.jp2";

        // Load the JPEG2000 image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access filtering capabilities
            RasterImage raster = (RasterImage)image;

            // Apply Gaussian blur to the entire image (radius = 5, sigma = 4.0)
            raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Save the processed image to a new file (format inferred from extension)
            raster.Save(outputPath);
        }
    }
}