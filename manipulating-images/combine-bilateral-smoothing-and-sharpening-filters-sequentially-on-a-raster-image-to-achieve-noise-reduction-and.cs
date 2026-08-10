// HOW-TO: Apply Bilateral Smoothing Followed by Sharpen Filter to PNG in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output paths
            string inputPath = @"c:\temp\sample.png";
            string outputPath = @"c:\temp\sample.BilateralSharpen.png";

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
 * 1. When you need to reduce noise in a scanned PNG while preserving edges for a document‑processing pipeline.
 * 2. When preparing product photos for an e‑commerce site and want both smooth skin tones and crisp details using Aspose.Imaging in C#.
 * 3. When cleaning up medical imaging scans before analysis, applying bilateral smoothing to remove speckle and then sharpening to highlight structures.
 * 4. When generating thumbnails for a gallery and require a balanced trade‑off between softness and sharpness without using external editors.
 * 5. When automating batch processing of satellite imagery to suppress atmospheric noise and enhance terrain edges in a .NET application.
 */
