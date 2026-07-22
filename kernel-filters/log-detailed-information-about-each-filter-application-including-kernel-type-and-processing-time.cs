using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPathGaussian = "output\\gaussian.png";
            string outputPathSharpen = "output\\sharpen.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(outputPathGaussian));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPathSharpen));

            // Apply Gaussian blur filter
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                var start = DateTime.Now;
                var gaussianOptions = new GaussianBlurFilterOptions(5, 4.0);
                raster.Filter(raster.Bounds, gaussianOptions);
                var elapsed = DateTime.Now - start;

                Console.WriteLine($"Applied GaussianBlurFilterOptions: Kernel={gaussianOptions.Kernel.GetType().Name}, Time={elapsed.TotalMilliseconds} ms");

                raster.Save(outputPathGaussian, new PngOptions());
            }

            // Apply Sharpen filter
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                var start = DateTime.Now;
                var sharpenOptions = new SharpenFilterOptions(5, 4.0);
                raster.Filter(raster.Bounds, sharpenOptions);
                var elapsed = DateTime.Now - start;

                Console.WriteLine($"Applied SharpenFilterOptions: Kernel={sharpenOptions.Kernel.GetType().Name}, Time={elapsed.TotalMilliseconds} ms");

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
 * 1. When a web application needs to automatically enhance uploaded PNG photos by applying a Gaussian blur and record the kernel type and processing time for performance monitoring.
 * 2. When a desktop batch‑processing tool must sharpen a series of images and log each filter’s kernel class and execution duration to generate audit reports.
 * 3. When a mobile backend service processes user‑submitted screenshots, applies both blur and sharpen filters, and stores the timing data to optimize server resources.
 * 4. When a digital asset management system integrates Aspose.Imaging to preprocess images and requires detailed console output of filter kernels for debugging image quality issues.
 * 5. When a CI/CD pipeline validates image‑processing code by measuring how long Gaussian and Sharpen filters take on sample PNG files and logs the kernel information for regression testing.
 */