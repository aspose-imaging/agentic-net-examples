using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Expect input image path as first argument and output directory as second argument.
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: <program> <inputImagePath> <outputDirectory>");
            return;
        }

        string inputPath = args[0];
        string outputDir = args[1];

        // Ensure output directory ends with a path separator.
        if (!outputDir.EndsWith(System.IO.Path.DirectorySeparatorChar.ToString()))
            outputDir += System.IO.Path.DirectorySeparatorChar;

        // Load the image.
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage for filtering.
            RasterImage raster = (RasterImage)image;

            // Apply Sharpen filter.
            raster.Filter(raster.Bounds,
                new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));
            raster.Save($"{outputDir}Sharpened.png");

            // Apply Gaussian Blur filter.
            raster.Filter(raster.Bounds,
                new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));
            raster.Save($"{outputDir}GaussianBlur.png");

            // Apply Bilateral Smoothing filter.
            raster.Filter(raster.Bounds,
                new Aspose.Imaging.ImageFilters.FilterOptions.BilateralSmoothingFilterOptions(5));
            raster.Save($"{outputDir}BilateralSmoothing.png");

            // Apply Gauss-Wiener filter.
            raster.Filter(raster.Bounds,
                new Aspose.Imaging.ImageFilters.FilterOptions.GaussWienerFilterOptions(5, 4.0));
            raster.Save($"{outputDir}GaussWiener.png");
        }
    }
}