using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Ico;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string inputPath = @"c:\temp\sample.ico";
        string outputPath = @"c:\temp\sample_blur.ico";

        // Load the ICO image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access filtering capabilities
            RasterImage raster = (RasterImage)image;

            // Apply Gaussian blur with radius 5 and sigma 4.0 to the whole image
            raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Save the processed image back as ICO
            raster.Save(outputPath);
        }
    }
}