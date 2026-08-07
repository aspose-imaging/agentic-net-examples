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
            string outputPathMedian = "output_median.png";
            string outputPathSharpen = "output_sharpen.png";

            // Input file existence check
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(outputPathMedian));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPathSharpen));

            // Load the image as RasterImage
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Median filter with logging
                DateTime medianStart = DateTime.Now;
                Console.WriteLine($"Median filter start: {medianStart:O}");
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(5));
                DateTime medianEnd = DateTime.Now;
                Console.WriteLine($"Median filter end: {medianEnd:O}");

                // Save result of median filter
                raster.Save(outputPathMedian, new PngOptions());

                // Sharpen filter with logging
                DateTime sharpenStart = DateTime.Now;
                Console.WriteLine($"Sharpen filter start: {sharpenStart:O}");
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));
                DateTime sharpenEnd = DateTime.Now;
                Console.WriteLine($"Sharpen filter end: {sharpenEnd:O}");

                // Save result of sharpen filter
                raster.Save(outputPathSharpen, new PngOptions());
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
 * 1. When a developer needs to benchmark the execution time of median and sharpen filters on PNG files in a .NET application, this code logs start and end timestamps for each filter operation.
 * 2. When building an automated image‑processing pipeline that must audit processing durations for compliance or SLA reporting, the timestamp interceptor provides a clear audit trail for each filter applied.
 * 3. When troubleshooting performance regressions after updating Aspose.Imaging or changing filter parameters, the logged timestamps help pinpoint which filter (median or sharpen) is causing delays.
 * 4. When creating a batch‑processing tool that processes large numbers of images and requires per‑image timing data to optimize resource allocation, the code records precise start and end times for each filter step.
 * 5. When integrating image enhancement features into a C# desktop application and needing to display real‑time processing metrics to end users, the timestamp logs can be used to show how long each filter takes to complete.
 */