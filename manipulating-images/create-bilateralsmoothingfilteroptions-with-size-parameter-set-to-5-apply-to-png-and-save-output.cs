// HOW-TO: Apply Bilateral Smoothing Filter to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Images\sample.png";
            string outputPath = @"C:\Images\sample.BilateralSmoothingFilter.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering methods
                RasterImage rasterImage = (RasterImage)image;

                // Apply bilateral smoothing filter with kernel size 5
                rasterImage.Filter(rasterImage.Bounds, new BilateralSmoothingFilterOptions(5));

                // Save the filtered image as PNG
                rasterImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to reduce noise in a PNG photograph while preserving edges before further analysis, you can use Aspose.Imaging’s bilateral smoothing filter in C#.
 * 2. When preparing product screenshots for a web catalog, applying a bilateral smoothing filter helps smooth gradients without blurring text or icons.
 * 3. When converting scanned PNG documents that contain grainy backgrounds, the filter can clean up the image to improve OCR accuracy.
 * 4. When building a C# image‑processing pipeline that must keep the original PNG format, you can apply the filter and save the result directly with Aspose.Imaging.
 * 5. When creating a desktop application that lets users enhance their PNG images with a single click, the bilateral smoothing filter provides a fast, edge‑preserving smoothing operation.
 */
