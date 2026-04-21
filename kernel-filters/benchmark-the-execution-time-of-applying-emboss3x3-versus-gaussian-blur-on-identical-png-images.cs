using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string inputPath = "input.png";
            string outputEmbossPath = "output/output_emboss.png";
            string outputGaussianPath = "output/output_gaussian.png";

            // Input validation
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(outputEmbossPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputGaussianPath));

            // Benchmark Emboss3x3
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                DateTime startEmboss = DateTime.Now;
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));
                DateTime endEmboss = DateTime.Now;
                double embossMs = (endEmboss - startEmboss).TotalMilliseconds;

                PngOptions embossOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputEmbossPath, false)
                };
                raster.Save(outputEmbossPath, embossOptions);

                Console.WriteLine($"Emboss3x3 filter time: {embossMs} ms");
            }

            // Benchmark Gaussian Blur
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                DateTime startGaussian = DateTime.Now;
                raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));
                DateTime endGaussian = DateTime.Now;
                double gaussianMs = (endGaussian - startGaussian).TotalMilliseconds;

                PngOptions gaussianOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputGaussianPath, false)
                };
                raster.Save(outputGaussianPath, gaussianOptions);

                Console.WriteLine($"Gaussian blur filter time: {gaussianMs} ms");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}