using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input image path (modify as needed)
        string inputPath = "input.png";

        // Output directory (modify as needed)
        string outputDir = "output";

        // Ensure output directory exists
        System.IO.Directory.CreateDirectory(outputDir);

        // Sharpen filter
        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;
            raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));
            raster.Save(System.IO.Path.Combine(outputDir, "sharpen.png"), new PngOptions());
        }

        // Gauss-Wiener filter
        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;
            raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussWienerFilterOptions(5, 4.0));
            raster.Save(System.IO.Path.Combine(outputDir, "gausswiener.png"), new PngOptions());
        }

        // Median filter
        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;
            raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(5));
            raster.Save(System.IO.Path.Combine(outputDir, "median.png"), new PngOptions());
        }

        // Bilateral smoothing filter
        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;
            raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.BilateralSmoothingFilterOptions(5));
            raster.Save(System.IO.Path.Combine(outputDir, "bilateral.png"), new PngOptions());
        }

        // Gaussian blur filter
        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;
            raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));
            raster.Save(System.IO.Path.Combine(outputDir, "gaussianblur.png"), new PngOptions());
        }

        // Motion Wiener filter
        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;
            raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MotionWienerFilterOptions(10, 1.0, 90.0));
            raster.Save(System.IO.Path.Combine(outputDir, "motionwiener.png"), new PngOptions());
        }
    }
}