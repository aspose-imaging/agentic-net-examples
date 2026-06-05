using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.svg";
        string outputPath = @"C:\Images\output.png";

        // Ensure the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to enable raster operations
                RasterImage rasterImage = (RasterImage)image;

                // Rotate the image 45 degrees clockwise
                rasterImage.Rotate(45f);

                // Apply Gaussian blur filter (radius 5, sigma 4.0) to the whole image
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Save the processed image as PNG
                rasterImage.Save(outputPath, new PngOptions());
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
 * 1. When generating thumbnail previews of user‑uploaded SVG icons that need to be displayed at a consistent 45° angle with a soft Gaussian blur effect before saving as PNG.
 * 2. When creating rotated watermarks from vector logos and applying a Gaussian blur to blend them seamlessly into PDF reports or documents.
 * 3. When preparing SVG diagrams for presentation slides where a 45° rotation adds visual interest and a Gaussian blur reduces visual clutter for a cleaner look.
 * 4. When processing SVG maps for a mobile app, rotating them to match device orientation and applying a Gaussian blur to smooth edges for better readability on low‑resolution screens.
 * 5. When automating batch conversion of SVG assets to PNG for a web gallery, applying a uniform 45° rotation and Gaussian blur to achieve a stylized, consistent appearance across all images.
 */