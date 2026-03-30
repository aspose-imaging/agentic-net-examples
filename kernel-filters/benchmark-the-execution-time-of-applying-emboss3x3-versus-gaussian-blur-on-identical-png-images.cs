using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string embossOutputPath = "emboss_output.png";
        string gaussianOutputPath = "gaussian_output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(embossOutputPath));
        Directory.CreateDirectory(Path.GetDirectoryName(gaussianOutputPath));

        // Benchmark Emboss3x3 filter
        long embossTime;
        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;
            var sw = System.Diagnostics.Stopwatch.StartNew();

            // Apply Emboss3x3 using ConvolutionFilterOptions
            raster.Filter(
                raster.Bounds,
                new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                    Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3));

            sw.Stop();
            embossTime = sw.ElapsedMilliseconds;

            // Save result
            raster.Save(embossOutputPath);
        }

        // Benchmark Gaussian blur filter
        long gaussianTime;
        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;
            var sw = System.Diagnostics.Stopwatch.StartNew();

            // Apply Gaussian blur with radius 5 and sigma 4.0
            raster.Filter(
                raster.Bounds,
                new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

            sw.Stop();
            gaussianTime = sw.ElapsedMilliseconds;

            // Save result
            raster.Save(gaussianOutputPath);
        }

        // Output benchmark results
        Console.WriteLine($"Emboss3x3 filter time: {embossTime} ms");
        Console.WriteLine($"Gaussian blur filter time: {gaussianTime} ms");
    }
}