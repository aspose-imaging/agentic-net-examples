// HOW-TO: Measure Execution Time of Emboss vs Gaussian Blur on PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Diagnostics;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputDir = "Output";
            string embossOutput = Path.Combine(outputDir, "emboss_output.png");
            string blurOutput = Path.Combine(outputDir, "blur_output.png");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(embossOutput));
            Directory.CreateDirectory(Path.GetDirectoryName(blurOutput));

            Stopwatch sw = new Stopwatch();

            // Emboss3x3 filter
            sw.Start();
            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));
                raster.Save(embossOutput, new PngOptions());
            }
            sw.Stop();
            double embossTime = sw.Elapsed.TotalMilliseconds;
            Console.WriteLine($"Emboss filter time: {embossTime} ms");

            // Gaussian blur filter
            sw.Restart();
            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.GetGaussian(5, 1.0)));
                raster.Save(blurOutput, new PngOptions());
            }
            sw.Stop();
            double blurTime = sw.Elapsed.TotalMilliseconds;
            Console.WriteLine($"Gaussian blur filter time: {blurTime} ms");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to compare the performance of different convolution filters, such as emboss and Gaussian blur, on PNG files in a C# application.
 * 2. When optimizing an image‑processing pipeline and you want to measure how long each filter adds to the overall processing time.
 * 3. When generating performance reports for a graphics library and you must record the execution time of specific filters on identical images.
 * 4. When deciding which filter to use in a real‑time photo editing tool and need to ensure the chosen filter meets latency requirements.
 * 5. When troubleshooting slow image transformations and want to isolate whether the emboss or blur operation is the bottleneck.
 */
