using System;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "sample.png";
        string gaussianOutputPath = "sample.GaussianBlur.png";
        string sharpenOutputPath = "sample.Sharpen.png";

        // Apply Gaussian blur filter
        using (Image image = Image.Load(inputPath))
        {
            Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;
            // Radius = 5, Sigma = 4.0
            raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));
            raster.Save(gaussianOutputPath);
        }

        // Apply Sharpen filter
        using (Image image = Image.Load(inputPath))
        {
            Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;
            // Kernel size = 5, Sigma = 4.0
            raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));
            raster.Save(sharpenOutputPath);
        }
    }
}