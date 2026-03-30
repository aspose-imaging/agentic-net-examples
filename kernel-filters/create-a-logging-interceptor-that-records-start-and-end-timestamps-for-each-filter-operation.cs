using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPathMedian = "output_median.png";
        string outputPathGaussian = "output_gaussian.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(outputPathMedian));
        Directory.CreateDirectory(Path.GetDirectoryName(outputPathGaussian));

        // Load image and cast to RasterImage
        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;

            // Apply Median filter with logging
            DateTime startMedian = DateTime.Now;
            Console.WriteLine($"Median filter start: {startMedian:O}");
            raster.Filter(raster.Bounds, new MedianFilterOptions(5));
            DateTime endMedian = DateTime.Now;
            Console.WriteLine($"Median filter end: {endMedian:O}");
            raster.Save(outputPathMedian, new PngOptions());

            // Apply Gaussian blur filter with logging
            DateTime startGaussian = DateTime.Now;
            Console.WriteLine($"Gaussian blur filter start: {startGaussian:O}");
            raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));
            DateTime endGaussian = DateTime.Now;
            Console.WriteLine($"Gaussian blur filter end: {endGaussian:O}");
            raster.Save(outputPathGaussian, new PngOptions());
        }
    }
}