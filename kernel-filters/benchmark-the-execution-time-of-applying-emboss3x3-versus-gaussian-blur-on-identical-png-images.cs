using System;
using System.Diagnostics;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.png";
            string embossOutputPath = @"C:\Images\sample.emboss.png";
            string gaussianOutputPath = @"C:\Images\sample.gaussian.png";

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
            Stopwatch swEmboss = new Stopwatch();
            using (Image image = Image.Load(inputPath))
            {
                RasterImage rasterImage = (RasterImage)image;
                swEmboss.Start();
                // Apply Emboss3x3 convolution kernel
                rasterImage.Filter(rasterImage.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));
                swEmboss.Stop();
                rasterImage.Save(embossOutputPath);
            }
            Console.WriteLine($"Emboss3x3 filter time: {swEmboss.ElapsedMilliseconds} ms");

            // Benchmark Gaussian blur filter
            Stopwatch swGaussian = new Stopwatch();
            using (Image image = Image.Load(inputPath))
            {
                RasterImage rasterImage = (RasterImage)image;
                swGaussian.Start();
                // Apply Gaussian blur with radius 5 and sigma 4.0
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));
                swGaussian.Stop();
                rasterImage.Save(gaussianOutputPath);
            }
            Console.WriteLine($"Gaussian blur filter time: {swGaussian.ElapsedMilliseconds} ms");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to compare the performance of the Aspose.Imaging Emboss3x3 convolution filter against a Gaussian blur on high‑resolution PNG files for real‑time photo‑editing applications.
 * 2. When a QA engineer wants to benchmark C# image‑processing code to ensure that applying a Gaussian blur with radius 5 and sigma 4.0 meets the latency requirements of a web‑based image‑enhancement service.
 * 3. When a performance analyst is measuring the execution time of different raster image filters in Aspose.Imaging to decide which filter to use in a batch‑processing pipeline that generates embossed thumbnails from PNG assets.
 * 4. When an optimization specialist needs to profile the Stopwatch timing of Emboss3x3 versus Gaussian blur to identify bottlenecks before deploying a C# microservice that applies artistic effects to user‑uploaded PNG images.
 * 5. When a developer is validating that the file I/O and filter operations in Aspose.Imaging produce consistent results while benchmarking the speed of embossing versus blurring for a desktop photo‑filter application.
 */