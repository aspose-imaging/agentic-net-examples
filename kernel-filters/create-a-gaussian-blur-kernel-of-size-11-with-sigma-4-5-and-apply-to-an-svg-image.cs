// HOW-TO: Apply Gaussian Blur to SVG and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.svg";
        string outputPath = "output.png";

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

            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for filtering (SVG will be rasterized on demand)
                RasterImage rasterImage = (RasterImage)image;

                // Apply Gaussian blur with kernel size 11 and sigma 4.5 to the whole image
                rasterImage.Filter(
                    rasterImage.Bounds,
                    new GaussianBlurFilterOptions(11, 4.5));

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
 * 1. When you need to soften the edges of a vector illustration before converting it to a raster PNG for web thumbnails.
 * 2. When you want to programmatically add a custom blur effect with a specific kernel size and sigma to SVG assets in a batch processing pipeline.
 * 3. When you are generating blurred background images from SVG logos for UI overlays in a C# desktop application.
 * 4. When you must ensure consistent blur quality across different SVG files by rasterizing them and applying a Gaussian filter using Aspose.Imaging.
 * 5. When you are automating the creation of low‑resolution preview images with a smooth blur for a digital asset management system.
 */
