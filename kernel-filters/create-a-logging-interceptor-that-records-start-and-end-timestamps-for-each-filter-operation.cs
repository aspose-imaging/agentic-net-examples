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
            string inputPath = "sample.png";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = "output";
            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Median filter
            string medianOutput = Path.Combine(outputDir, "median.png");
            Directory.CreateDirectory(Path.GetDirectoryName(medianOutput));
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                DateTime start = DateTime.Now;
                Console.WriteLine($"Median filter start: {start}");
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(5));
                DateTime end = DateTime.Now;
                Console.WriteLine($"Median filter end: {end}");
                raster.Save(medianOutput, new PngOptions());
            }

            // Gaussian blur filter
            string gaussianOutput = Path.Combine(outputDir, "gaussian.png");
            Directory.CreateDirectory(Path.GetDirectoryName(gaussianOutput));
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                DateTime start = DateTime.Now;
                Console.WriteLine($"Gaussian blur filter start: {start}");
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));
                DateTime end = DateTime.Now;
                Console.WriteLine($"Gaussian blur filter end: {end}");
                raster.Save(gaussianOutput, new PngOptions());
            }

            // Sharpen filter
            string sharpenOutput = Path.Combine(outputDir, "sharpen.png");
            Directory.CreateDirectory(Path.GetDirectoryName(sharpenOutput));
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                DateTime start = DateTime.Now;
                Console.WriteLine($"Sharpen filter start: {start}");
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));
                DateTime end = DateTime.Now;
                Console.WriteLine($"Sharpen filter end: {end}");
                raster.Save(sharpenOutput, new PngOptions());
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
 * 1. When a C# application needs to benchmark the performance of median and Gaussian blur filters on PNG images during batch image processing, this code logs precise start and end timestamps for each operation.
 * 2. When developers are building an automated testing suite for Aspose.Imaging that validates filter execution times across different image formats such as JPEG and BMP, the timestamp interceptor provides measurable results.
 * 3. When a photo‑editing tool requires real‑time feedback on how long each filter takes to apply so users can be informed about processing delays, the logged timestamps enable accurate UI progress indicators.
 * 4. When a server‑side image‑optimization service must track and log filter durations for compliance or SLA reporting, the code’s start/end time records integrate easily with logging frameworks.
 * 5. When troubleshooting unexpected slowdowns in a C# image‑processing pipeline that uses Aspose.Imaging’s RasterImage filters, the timestamp logs help pinpoint whether the median or Gaussian blur step is the bottleneck.
 */