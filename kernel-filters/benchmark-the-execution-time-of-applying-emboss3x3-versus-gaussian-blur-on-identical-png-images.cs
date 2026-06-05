using System;
using System.IO;
using System.Diagnostics;
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
            string inputPath = @"C:\temp\sample.png";
            string embossOutputPath = @"C:\temp\sample.emboss.png";
            string gaussianOutputPath = @"C:\temp\sample.gaussian.png";

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
            Stopwatch swEmboss = Stopwatch.StartNew();
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                // Apply Emboss3x3 convolution filter
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));
                raster.Save(embossOutputPath);
            }
            swEmboss.Stop();

            // Benchmark Gaussian blur filter (radius 5, sigma 4.0)
            Stopwatch swGaussian = Stopwatch.StartNew();
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                // Apply Gaussian blur filter
                raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));
                raster.Save(gaussianOutputPath);
            }
            swGaussian.Stop();

            // Output benchmark results
            Console.WriteLine($"Emboss3x3 filter time: {swEmboss.ElapsedMilliseconds} ms");
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
 * 1. When optimizing a photo‑editing application, a developer can use this code to compare the processing speed of the Aspose.Imaging Emboss3x3 filter versus a Gaussian blur on PNG files.
 * 2. When evaluating hardware performance for batch image transformations, the benchmark helps determine whether the convolution‑based emboss effect or the Gaussian blur kernel is more suitable for real‑time processing.
 * 3. When building a server‑side image‑processing service that must meet latency SLAs, the developer can run this test to decide which filter to expose via an API for PNG uploads.
 * 4. When creating automated CI/CD tests for image‑filter quality, the timing results from this snippet allow the team to detect regressions in the Emboss3x3 or Gaussian blur implementations.
 * 5. When teaching image‑processing concepts, an instructor can demonstrate how different convolution filters impact execution time on identical PNG images using the provided C# benchmark.
 */