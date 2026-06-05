using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // README example:
        // 1. Load an SVG file.
        // 2. Rasterize it to a raster image.
        // 3. Apply a Gaussian blur filter.
        // 4. Save the result as PNG.

        string inputPath = "C:\\temp\\input.svg";
        string outputPath = "C:\\temp\\output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the SVG image.
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for filtering.
                RasterImage rasterImage = (RasterImage)image;

                // Apply Gaussian blur with radius 5 and sigma 4.0.
                var blurOptions = new GaussianBlurFilterOptions(5, 4.0);
                rasterImage.Filter(rasterImage.Bounds, blurOptions);

                // Save the blurred image.
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
 * 1. When a web application needs to convert user‑uploaded SVG icons into blurred PNG thumbnails for faster loading and visual emphasis.
 * 2. When an automated reporting tool must rasterize vector diagrams and apply a soft‑focus effect before embedding them in PDF dashboards.
 * 3. When a desktop utility processes a batch of SVG logos, adds a Gaussian blur to create background watermarks, and saves them as PNG files for branding assets.
 * 4. When a mobile backend service generates preview images of SVG artwork with a blur filter to protect intellectual property while still showing a visual cue.
 * 5. When a CI/CD pipeline validates SVG assets by rasterizing them, applying a blur filter, and comparing the resulting PNG against a baseline for visual regression testing.
 */