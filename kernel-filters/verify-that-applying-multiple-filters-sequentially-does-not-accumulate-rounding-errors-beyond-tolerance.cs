using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "sample.png";
            string outputPath = "output/output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load image and cast to RasterImage
            using (Image img = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)img;

                // Cache image data for performance
                if (!raster.IsCached) raster.CacheData();

                // Capture original pixel data
                var originalPixels = raster.GetDefaultArgb32Pixels(raster.Bounds);

                // Apply multiple filters sequentially
                raster.Filter(raster.Bounds, new MedianFilterOptions(5));
                raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));
                raster.Filter(raster.Bounds, new SharpenFilterOptions(5, 4.0));

                // Save the processed image
                raster.Save(outputPath);

                // Capture processed pixel data
                var processedPixels = raster.GetDefaultArgb32Pixels(raster.Bounds);

                // Compute maximum absolute difference between original and processed pixels
                int maxDiff = originalPixels
                    .Select((orig, idx) => Math.Abs(orig - processedPixels[idx]))
                    .Max();

                const int tolerance = 1;
                if (maxDiff <= tolerance)
                {
                    Console.WriteLine("Verification passed: rounding errors within tolerance.");
                }
                else
                {
                    Console.WriteLine($"Verification failed: max difference {maxDiff} exceeds tolerance {tolerance}.");
                }
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
 * 1. When a developer needs to ensure that applying a series of image filters (median, Gaussian blur, sharpen) to a PNG file does not introduce cumulative rounding errors beyond a pixel‑value tolerance, they can use this code to compare original and processed ARGB32 pixels.
 * 2. When building an automated image‑processing pipeline in C# that must preserve visual fidelity across multiple filter stages, the example shows how to cache raster data, run sequential filters, and verify the maximum absolute pixel difference stays within a defined tolerance.
 * 3. When validating the correctness of custom filter implementations or third‑party filter libraries for Aspose.Imaging, a developer can employ this snippet to load a raster image, apply standard filters, and programmatically assert that rounding errors remain below a threshold.
 * 4. When creating a batch‑processing tool that reads PNG images, applies noise reduction, blur, and sharpening, and needs to guarantee that the output image is not unintentionally altered beyond one unit per channel, this code provides a reproducible verification step.
 * 5. When troubleshooting image quality issues in a .NET application that chains multiple Aspose.Imaging filters, the sample demonstrates how to capture original pixel data, execute the filters, and compute the maximum pixel deviation to detect excessive rounding errors.
 */