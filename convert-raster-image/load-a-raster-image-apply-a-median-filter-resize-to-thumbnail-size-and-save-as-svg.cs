// HOW-TO: How to Apply Median Filter, Resize, and Save PNG as SVG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output.svg";

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

            // Load raster image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for filtering and resizing
                RasterImage rasterImage = (RasterImage)image;

                // Apply median filter with size 5
                rasterImage.Filter(rasterImage.Bounds, new MedianFilterOptions(5));

                // Resize to thumbnail size (e.g., 150x150)
                rasterImage.Resize(150, 150);

                // Save the processed image as SVG
                image.Save(outputPath, new SvgOptions());
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
 * 1. When you need to clean up noisy PNG screenshots, shrink them to 150 × 150 thumbnails, and store the result as scalable SVG for web dashboards.
 * 2. When generating lightweight vector icons from raster assets, applying a median filter to reduce artifacts before converting to SVG.
 * 3. When preprocessing user‑uploaded images for a mobile app, removing speckle noise, creating a small preview, and saving it in SVG to maintain resolution independence.
 * 4. When automating batch conversion of scanned documents to vector format, smoothing the raster data and resizing it to a standard thumbnail size.
 * 5. When integrating image processing into a C# reporting tool that requires filtered, resized images saved as SVG for inclusion in PDF or HTML reports.
 */
