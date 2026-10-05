// HOW-TO: Log Processing Time for Gaussian Blur and Emboss Filters in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.jpg";
            string outputPath = "output/output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                if (!image.IsCached) image.CacheData();

                var stopwatch = Stopwatch.StartNew();
                var gaussianOptions = new GaussianBlurFilterOptions(2, 2.0);
                image.Filter(image.Bounds, gaussianOptions);
                stopwatch.Stop();
                Console.WriteLine($"Applied GaussianBlur filter (sigma=2.0) in {stopwatch.ElapsedMilliseconds} ms.");

                stopwatch.Restart();
                double[,] embossKernel = ConvolutionFilter.Emboss3x3;
                var convOptions = new ConvolutionFilterOptions(embossKernel);
                image.Filter(image.Bounds, convOptions);
                stopwatch.Stop();
                Console.WriteLine($"Applied Convolution filter (Emboss3x3) in {stopwatch.ElapsedMilliseconds} ms.");

                var jpegOptions = new JpegOptions();
                image.Save(outputPath, jpegOptions);
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
 * 1. When you need to benchmark how long a Gaussian blur takes on a JPEG image before saving the result.
 * 2. When you want to apply an emboss convolution filter to a raster image and record its execution time for performance analysis.
 * 3. When you must ensure an input image is cached in memory before applying multiple filters using Aspose.Imaging in a C# application.
 * 4. When you are building an automated image processing pipeline that logs detailed filter metrics for quality control reports.
 * 5. When you need to create a processed JPEG output after sequentially applying blur and emboss effects while tracking each step’s duration.
 */
