// HOW-TO: Apply Bilateral Smoothing Sharpening and Median Filter to JPEG in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.jpg";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                if (!raster.IsCached)
                {
                    raster.CacheData();
                }

                raster.Filter(raster.Bounds, new BilateralSmoothingFilterOptions());
                raster.Filter(raster.Bounds, new SharpenFilterOptions());
                raster.Filter(raster.Bounds, new MedianFilterOptions(3));

                raster.Save(outputPath, new JpegOptions());
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
 * 1. When you need to reduce noise in a JPEG photo while preserving edges before uploading to a web gallery.
 * 2. When you want to enhance the sharpness of scanned documents and then smooth remaining artifacts for OCR preprocessing.
 * 3. When you are preparing product images for an e‑commerce site and require a quick pipeline that denoises, sharpens, and smooths color transitions.
 * 4. When you must improve low‑light smartphone pictures by applying bilateral smoothing followed by sharpening and a median filter to balance detail and smoothness.
 * 5. When you are building an automated batch processor that cleans up batch‑converted images from RAW to JPEG using a reusable filter sequence in C#.
 */
