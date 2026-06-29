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
            string inputPath = @"c:\temp\sample.png";
            string outputEmbossPath = @"c:\temp\sample.emboss.png";
            string outputGaussianPath = @"c:\temp\sample.gaussian.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(outputEmbossPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputGaussianPath));

            // Benchmark Emboss3x3 filter
            Stopwatch swEmboss = Stopwatch.StartNew();
            using (Image img = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)img;
                // Apply Emboss3x3 convolution filter
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));
                raster.Save(outputEmbossPath);
            }
            swEmboss.Stop();

            // Benchmark Gaussian blur filter
            Stopwatch swGaussian = Stopwatch.StartNew();
            using (Image img = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)img;
                // Apply Gaussian blur with radius 5 and sigma 4.0
                raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));
                raster.Save(outputGaussianPath);
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
 * 1. When a developer needs to compare the performance of a 3x3 emboss convolution filter versus a Gaussian blur on high‑resolution PNG files in a C# application using Aspose.Imaging.
 * 2. When optimizing an image‑processing pipeline, a programmer can benchmark how long each filter takes to process identical raster images to decide which effect meets real‑time requirements.
 * 3. When building a photo‑editing tool that offers both emboss and blur effects, the code helps determine the most efficient filter to apply on user‑uploaded PNGs to keep UI responsiveness.
 * 4. When evaluating server‑side batch processing of PNG assets, a developer can use the stopwatch measurements to estimate CPU load and processing time for each filter before scaling the service.
 * 5. When documenting performance trade‑offs in a technical blog or API guide, the example provides concrete millisecond timings for Aspose.Imaging’s ConvolutionFilter.
 */