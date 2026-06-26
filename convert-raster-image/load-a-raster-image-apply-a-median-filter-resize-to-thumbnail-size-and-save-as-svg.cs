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
        string inputPath = @"C:\Images\sample.png";
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
                // Cast to RasterImage to access filtering and resizing
                RasterImage rasterImage = (RasterImage)image;

                // Apply median filter with size 5 to the whole image
                rasterImage.Filter(rasterImage.Bounds, new MedianFilterOptions(5));

                // Resize to thumbnail size (e.g., 150x150)
                int thumbWidth = 150;
                int thumbHeight = 150;
                rasterImage.Resize(thumbWidth, thumbHeight);

                // Save as SVG using default SvgOptions
                SvgOptions svgOptions = new SvgOptions();
                rasterImage.Save(outputPath, svgOptions);
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
 * 1. When a web developer needs to generate lightweight SVG thumbnails from user‑uploaded PNG photos while reducing noise with a median filter, they can use this C# Aspose.Imaging code.
 * 2. When an e‑commerce platform wants to display product preview icons as scalable vector graphics and must first clean up the original raster images, the code provides a simple way to filter, resize, and save as SVG.
 * 3. When a desktop application creates a gallery of small, noise‑free previews for high‑resolution scans, the snippet shows how to load the raster image, apply a 5‑pixel median filter, shrink it to 150×150, and export to SVG.
 * 4. When a content‑management system automatically converts uploaded bitmap assets into vector thumbnails for responsive design, developers can employ this routine to perform the median filtering, resizing, and SVG saving in C#.
 * 5. When a data‑visualization tool needs to embed cleaned‑up, size‑optimized SVG icons derived from PNG sources, this example demonstrates the required steps using Aspose.Imaging’s RasterImage, MedianFilterOptions, and SvgOptions.
 */