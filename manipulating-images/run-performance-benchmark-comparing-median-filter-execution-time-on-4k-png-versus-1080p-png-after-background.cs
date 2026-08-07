using System;
using System.Diagnostics;
using System.IO;
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
            // Benchmark for 1080p image
            long elapsed1080p = ApplyMedianFilterAndMeasure(inputPath1080p, outputPath1080p);

            Console.WriteLine($"Median filter on 4K image took {elapsed4K} ms");
            Console.WriteLine($"Median filter on 1080p image took {elapsed1080p} ms");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    // Loads the image, applies a median filter, saves the result, and returns elapsed milliseconds
    static long ApplyMedianFilterAndMeasure(string inputPath, string outputPath)
    {
        Stopwatch sw = new Stopwatch();
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access Filter method
            RasterImage rasterImage = (RasterImage)image;

            // Optional: background removal step could be placed here if needed

            // Measure filter execution time
            sw.Start();
            rasterImage.Filter(rasterImage.Bounds, new MedianFilterOptions(5));
            sw.Stop();

            // Save the processed image
            rasterImage.Save(outputPath);
        }
        return sw.ElapsedMilliseconds;
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to measure how long a median filter takes on high‑resolution 4K PNG versus 1080p PNG after background removal to decide if the processing fits within a real‑time UI.
 * 2. When a C# application must compare performance of Aspose.Imaging’s median filter on different image sizes to optimize batch background‑removal workflows for large photo libraries.
 * 3. When a performance engineer wants to benchmark the execution time of the median filter on raster PNG files using Stopwatch to identify potential bottlenecks before scaling to 4K video frames.
 * 4. When a software team is evaluating whether to pre‑process 4K PNG assets with a median filter on the server or client side by measuring the milliseconds required for each resolution.
 * 5. When a developer is building an automated image‑processing pipeline that applies background removal followed by a median filter and needs concrete timing data for 4K and 1080p PNG outputs.
 */