// HOW-TO: Measure Emboss3x3 Vs Gaussian Blur Performance On PNG In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Diagnostics;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputDir = "output";
            string embossOutputPath = Path.Combine(outputDir, "emboss.png");
            string gaussianOutputPath = Path.Combine(outputDir, "gaussian.png");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(embossOutputPath));
            Directory.CreateDirectory(Path.GetDirectoryName(gaussianOutputPath));

            Stopwatch sw = new Stopwatch();

            // Emboss3x3 filter benchmark
            using (Image img = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)img;
                sw.Start();
                raster.Filter(raster.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                        Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3));
                sw.Stop();
                long embossTime = sw.ElapsedMilliseconds;
                sw.Reset();

                raster.Save(embossOutputPath);
                Console.WriteLine($"Emboss3x3 filter time: {embossTime} ms");
            }

            // Gaussian blur filter benchmark
            using (Image img = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)img;
                sw.Start();
                raster.Filter(raster.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));
                sw.Stop();
                long gaussianTime = sw.ElapsedMilliseconds;

                raster.Save(gaussianOutputPath);
                Console.WriteLine($"Gaussian blur filter time: {gaussianTime} ms");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to compare the speed of different image filters to choose the most efficient one for real‑time PNG processing.
 * 2. When optimizing a photo‑editing application and wants to measure how long an emboss effect takes versus a Gaussian blur on the same image.
 * 3. When creating automated performance tests for Aspose.Imaging filters to ensure they meet latency requirements in a C# service.
 * 4. When profiling image‑processing pipelines to decide which filter to apply for batch conversion of PNG files without exceeding time budgets.
 * 5. When documenting or demonstrating the impact of filter complexity on CPU usage for developers evaluating Aspose.Imaging’s convolution and blur options.
 */
