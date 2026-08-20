// HOW-TO: Log Kernel Type and Processing Time for Gaussian Blur and Sharpen in C# (Aspose.Imaging for .NET)
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
            string outputBaseDir = "output";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputBaseDir);

            // ---------- Gaussian Blur ----------
            using (Image img = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)img;
                var options = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0);
                DateTime start = DateTime.Now;
                raster.Filter(raster.Bounds, options);
                double elapsedMs = (DateTime.Now - start).TotalMilliseconds;
                Console.WriteLine($"Applied {options.GetType().Name}, Kernel Type: {options.Kernel?.GetType().Name}, Time: {elapsedMs} ms");

                string outPath = Path.Combine(outputBaseDir, "GaussianBlur.png");
                Directory.CreateDirectory(Path.GetDirectoryName(outPath));
                raster.Save(outPath, new PngOptions());
            }

            // ---------- Sharpen ----------
            using (Image img = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)img;
                var options = new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0);
                DateTime start = DateTime.Now;
                raster.Filter(raster.Bounds, options);
                double elapsedMs = (DateTime.Now - start).TotalMilliseconds;
                Console.WriteLine($"Applied {options.GetType().Name}, Kernel Type: {options.Kernel?.GetType().Name}, Time: {elapsedMs} ms");

                string outPath = Path.Combine(outputBaseDir, "Sharpen.png");
                Directory.CreateDirectory(Path.GetDirectoryName(outPath));
                raster.Save(outPath, new PngOptions());
            }

            // ---------- Median ----------
            using (Image img = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)img;
                var options = new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(5);
                DateTime start = DateTime.Now;
                raster.Filter(raster.Bounds, options);
                double elapsedMs = (DateTime.Now - start).TotalMilliseconds;
                Console.WriteLine($"Applied {options.GetType().Name}, Kernel Type: N/A, Time: {elapsedMs} ms");

                string outPath = Path.Combine(outputBaseDir, "Median.png");
                Directory.CreateDirectory(Path.GetDirectoryName(outPath));
                raster.Save(outPath, new PngOptions());
            }

            // ---------- Bilateral Smoothing ----------
            using (Image img = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)img;
                var options = new Aspose.Imaging.ImageFilters.FilterOptions.BilateralSmoothingFilterOptions(5);
                DateTime start = DateTime.Now;
                raster.Filter(raster.Bounds, options);
                double elapsedMs = (DateTime.Now - start).TotalMilliseconds;
                Console.WriteLine($"Applied {options.GetType().Name}, Kernel Type: N/A, Time: {elapsedMs} ms");

                string outPath = Path.Combine(outputBaseDir, "BilateralSmoothing.png");
                Directory.CreateDirectory(Path.GetDirectoryName(outPath));
                raster.Save(outPath, new PngOptions());
            }

            // ---------- Gauss Wiener ----------
            using (Image img = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)img;
                var options = new Aspose.Imaging.ImageFilters.FilterOptions.GaussWienerFilterOptions(5, 4.0);
                DateTime start = DateTime.Now;
                raster.Filter(raster.Bounds, options);
                double elapsedMs = (DateTime.Now - start).TotalMilliseconds;
                Console.WriteLine($"Applied {options.GetType().Name}, Kernel Type: {options.Kernel?.GetType().Name}, Time: {elapsedMs} ms");

                string outPath = Path.Combine(outputBaseDir, "GaussWiener.png");
                Directory.CreateDirectory(Path.GetDirectoryName(outPath));
                raster.Save(outPath, new PngOptions());
            }

            // ---------- Motion Wiener ----------
            using (Image img = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)img;
                var options = new Aspose.Imaging.ImageFilters.FilterOptions.MotionWienerFilterOptions(10, 1.0, 90.0);
                DateTime start = DateTime.Now;
                raster.Filter(raster.Bounds, options);
                double elapsedMs = (DateTime.Now - start).TotalMilliseconds;
                Console.WriteLine($"Applied {options.GetType().Name}, Kernel Type: {options.Kernel?.GetType().Name}, Time: {elapsedMs} ms");

                string outPath = Path.Combine(outputBaseDir, "MotionWiener.png");
                Directory.CreateDirectory(Path.GetDirectoryName(outPath));
                raster.Save(outPath, new PngOptions());
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
 * 1. When you need to benchmark how long a Gaussian blur filter takes on PNG images in a .NET application.
 * 2. When you want to record the specific kernel class used by Aspose.Imaging filters for debugging or documentation.
 * 3. When you must apply both blur and sharpen effects to the same source image and compare their performance.
 * 4. When you are building an automated image‑processing pipeline that logs filter details for audit trails.
 * 5. When you need to generate separate output files for each filter while capturing processing metrics for quality control.
 */
