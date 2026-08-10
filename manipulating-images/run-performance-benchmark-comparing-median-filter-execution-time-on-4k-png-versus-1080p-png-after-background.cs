// HOW-TO: Benchmark Median Filter Speed on 4K vs 1080p PNG Images in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Diagnostics;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath4K = @"C:\Images\input_4k.png";
        string inputPath1080p = @"C:\Images\input_1080p.png";
        string outputPath4K = @"C:\Images\output_4k_median.png";
        string outputPath1080p = @"C:\Images\output_1080p_median.png";

        try
        {
            // ---------- 4K image processing ----------
            if (!File.Exists(inputPath4K))
            {
                Console.Error.WriteLine($"File not found: {inputPath4K}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath4K));

            using (Image image = Image.Load(inputPath4K))
            {
                // Cast to RasterImage to access Filter method
                RasterImage raster = (RasterImage)image;

                // Measure median filter execution time
                Stopwatch sw = Stopwatch.StartNew();
                raster.Filter(raster.Bounds, new MedianFilterOptions(5));
                sw.Stop();

                Console.WriteLine($"4K median filter time: {sw.ElapsedMilliseconds} ms");

                // Save the filtered image
                raster.Save(outputPath4K);
            }

            // ---------- 1080p image processing ----------
            if (!File.Exists(inputPath1080p))
            {
                Console.Error.WriteLine($"File not found: {inputPath1080p}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath1080p));

            using (Image image = Image.Load(inputPath1080p))
            {
                RasterImage raster = (RasterImage)image;

                Stopwatch sw = Stopwatch.StartNew();
                raster.Filter(raster.Bounds, new MedianFilterOptions(5));
                sw.Stop();

                Console.WriteLine($"1080p median filter time: {sw.ElapsedMilliseconds} ms");

                raster.Save(outputPath1080p);
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
 * 1. When you need to compare processing time of a median filter on high‑resolution (4K) versus HD (1080p) PNG files to decide if your application can handle large images efficiently.
 * 2. When you want to measure and log the execution speed of Aspose.Imaging’s MedianFilterOptions on different image sizes for performance tuning.
 * 3. When you are building an automated image‑processing pipeline and must ensure that applying a median filter to 4K PNGs stays within acceptable latency limits.
 * 4. When you are evaluating hardware or server configurations by benchmarking how long a median filter takes on 4K and 1080p PNG images in a C# environment.
 * 5. When you need to generate filtered output files and record the median filter runtime to compare against other image‑processing algorithms or libraries.
 */
