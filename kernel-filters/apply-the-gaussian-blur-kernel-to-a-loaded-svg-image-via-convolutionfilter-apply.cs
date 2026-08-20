// HOW-TO: Apply Gaussian Blur to SVG and Save as PNG in C# (Aspose.Imaging for .NET)
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
            string inputPath = @"C:\Images\sample.svg";
            string outputPath = @"C:\Images\sample_blur.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to enable filtering
                RasterImage rasterImage = (RasterImage)image;

                // Apply Gaussian blur filter (size = 5, sigma = 4.0) to the whole image
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

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
 * 1. When you need to soften vector graphics for web thumbnails by applying a Gaussian blur and exporting them as PNG files using C#.
 * 2. When generating blurred background images from SVG logos for UI overlays in a .NET application.
 * 3. When preprocessing SVG assets for machine‑learning pipelines that require raster images with reduced detail.
 * 4. When creating stylized product catalogs where SVG illustrations must be blurred before being embedded in PDF reports.
 * 5. When automating a batch job that converts SVG icons to blurred PNGs for responsive design breakpoints.
 */
