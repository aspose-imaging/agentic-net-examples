using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input PNG file path
        string inputPath = @"C:\Images\input.png";

        // Output directory
        string outputDir = @"C:\Images\Processed\";

        // Ensure the output directory exists
        System.IO.Directory.CreateDirectory(outputDir);

        // Apply Median filter
        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;
            raster.Filter(raster.Bounds, new MedianFilterOptions(5));

            PngOptions saveOptions = new PngOptions();
            raster.Save(System.IO.Path.Combine(outputDir, "median_filtered.png"), saveOptions);
        }

        // Apply Gaussian Blur filter
        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;
            raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            PngOptions saveOptions = new PngOptions();
            raster.Save(System.IO.Path.Combine(outputDir, "gaussian_blur.png"), saveOptions);
        }

        // Apply Sharpen filter
        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;
            raster.Filter(raster.Bounds, new SharpenFilterOptions(5, 4.0));

            PngOptions saveOptions = new PngOptions();
            raster.Save(System.IO.Path.Combine(outputDir, "sharpened.png"), saveOptions);
        }
    }
}