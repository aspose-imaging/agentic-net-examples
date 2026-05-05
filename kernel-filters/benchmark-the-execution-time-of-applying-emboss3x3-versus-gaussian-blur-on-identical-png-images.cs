using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputEmbossPath = "Output\\emboss.png";
            string outputGaussianPath = "Output\\gaussian.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(outputEmbossPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputGaussianPath));

            // Apply Emboss3x3 filter and benchmark
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                DateTime start = DateTime.Now;
                raster.Filter(raster.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                        Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3));
                raster.Save(outputEmbossPath);
                TimeSpan elapsed = DateTime.Now - start;
                Console.WriteLine($"Emboss3x3 filter time: {elapsed.TotalMilliseconds} ms");
            }

            // Apply Gaussian blur filter and benchmark
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                DateTime start = DateTime.Now;
                raster.Filter(raster.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));
                raster.Save(outputGaussianPath);
                TimeSpan elapsed = DateTime.Now - start;
                Console.WriteLine($"Gaussian blur filter time: {elapsed.TotalMilliseconds} ms");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}