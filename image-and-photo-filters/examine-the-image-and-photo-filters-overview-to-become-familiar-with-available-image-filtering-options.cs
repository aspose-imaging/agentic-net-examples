using System;
using System.Drawing;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Directory containing the source image and where output images will be saved
        string dir = @"c:\temp\";
        string inputPath = Path.Combine(dir, "sample.png");

        // Apply a Median filter
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access the Filter method
            RasterImage raster = (RasterImage)image;

            // Apply a median filter with a kernel size of 5 to the entire image
            raster.Filter(raster.Bounds, new MedianFilterOptions(5));

            // Save the filtered image as PNG
            raster.Save(Path.Combine(dir, "sample.MedianFilter.png"), new PngOptions());
        }

        // Apply a Bilateral Smoothing filter
        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;

            // Apply a bilateral smoothing filter with a kernel size of 5
            raster.Filter(raster.Bounds, new BilateralSmoothingFilterOptions(5));

            raster.Save(Path.Combine(dir, "sample.BilateralSmoothingFilter.png"), new PngOptions());
        }

        // Apply a Gaussian Blur filter
        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;

            // Apply a Gaussian blur filter with radius 5 and sigma 4.0
            raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            raster.Save(Path.Combine(dir, "sample.GaussianBlurFilter.png"), new PngOptions());
        }

        // Apply a Sharpen filter
        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;

            // Apply a sharpen filter with kernel size 5 and sigma 4.0
            raster.Filter(raster.Bounds, new SharpenFilterOptions(5, 4.0));

            raster.Save(Path.Combine(dir, "sample.SharpenFilter.png"), new PngOptions());
        }
    }
}