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
            string inputPath = @"C:\Images\input.svg";
            string outputPath = @"C:\Images\output.png";

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
                // Rasterize the SVG by converting it to a RasterImage
                using (RasterImage rasterImage = (RasterImage)image)
                {
                    // Apply Gaussian blur with kernel size 11 and sigma 4.5
                    var blurOptions = new GaussianBlurFilterOptions(11, 4.5);
                    rasterImage.Filter(rasterImage.Bounds, blurOptions);

                    // Save the processed image
                    rasterImage.Save(outputPath);
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
 * 1. When a web application needs to generate a blurred thumbnail PNG from an uploaded SVG logo for UI previews.
 * 2. When an e‑commerce platform wants to apply a soft Gaussian blur to product vector illustrations before converting them to raster images for faster page loads.
 * 3. When a reporting tool automatically rasterizes SVG charts and adds a blur effect to hide sensitive data before exporting to PNG.
 * 4. When a desktop publishing software creates stylized background images by blurring SVG graphics and saving them as PNG assets for print layouts.
 * 5. When a mobile app preprocesses user‑provided SVG icons with a Gaussian blur to achieve a consistent visual style across different screen resolutions.
 */