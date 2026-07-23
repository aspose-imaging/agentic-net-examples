using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering
                RasterImage rasterImage = (RasterImage)image;

                // Apply bilateral smoothing filter (kernel size 5)
                rasterImage.Filter(rasterImage.Bounds, new BilateralSmoothingFilterOptions(5));

                // Apply sharpen filter (kernel size 5, sigma 4.0)
                rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(5, 4.0));

                // Apply median filter (kernel size 5)
                rasterImage.Filter(rasterImage.Bounds, new MedianFilterOptions(5));

                // Save the processed image
                rasterImage.Save(outputPath);
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
 * 1. When a developer needs to reduce noise in a scanned PNG document while preserving edges before performing OCR, they can use this bilateral smoothing‑sharpen‑median filter pipeline with Aspose.Imaging for .NET.
 * 2. When preparing product photos for an e‑commerce website, a C# application can apply the three‑step filter sequence to smooth color variations, enhance details, and remove speckle artifacts before saving the final PNG.
 * 3. When cleaning up medical imaging slices stored as PNG files, a developer can employ the bilateral smoothing, sharpening, and median filters to improve visual clarity without losing diagnostic information.
 * 4. When building an automated batch‑processing tool that normalizes image quality of user‑uploaded PNGs, the code demonstrates how to chain multiple Aspose.Imaging filter options in a reusable pipeline.
 * 5. When integrating image enhancement into a desktop C# utility that must preserve the original file format, the filter pipeline shows how to load, process, and save a PNG using RasterImage and filter bounds.
 */