using System;
using System.IO;
using System.Diagnostics;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath4K = @"C:\Images\image_4k.png";
            string inputPath1080p = @"C:\Images\image_1080p.png";
            string outputPath4K = @"C:\Images\output_4k_median.png";
            string outputPath1080p = @"C:\Images\output_1080p_median.png";

            // Verify input files exist
            if (!File.Exists(inputPath4K))
            {
                Console.Error.WriteLine($"File not found: {inputPath4K}");
                return;
            }
            if (!File.Exists(inputPath1080p))
            {
                Console.Error.WriteLine($"File not found: {inputPath1080p}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath4K));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath1080p));

            // Benchmark for 4K image
            long elapsed4K = ApplyMedianFilterAndMeasure(inputPath4K, outputPath4K);
            Console.WriteLine($"4K median filter time: {elapsed4K} ms");

            // Benchmark for 1080p image
            long elapsed1080p = ApplyMedianFilterAndMeasure(inputPath1080p, outputPath1080p);
            Console.WriteLine($"1080p median filter time: {elapsed1080p} ms");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    // Loads an image, applies a median filter, saves the result, and returns elapsed milliseconds
    static long ApplyMedianFilterAndMeasure(string inputPath, string outputPath)
    {
        Stopwatch sw = new Stopwatch();
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access Filter method
            RasterImage rasterImage = (RasterImage)image;

            // Start timing
            sw.Start();

            // Apply median filter with a rectangle size of 5 to the entire image
            rasterImage.Filter(rasterImage.Bounds, new MedianFilterOptions(5));

            // Stop timing after filter is applied
            sw.Stop();

            // Save the processed image
            rasterImage.Save(outputPath);
        }
        return sw.ElapsedMilliseconds;
    }
}