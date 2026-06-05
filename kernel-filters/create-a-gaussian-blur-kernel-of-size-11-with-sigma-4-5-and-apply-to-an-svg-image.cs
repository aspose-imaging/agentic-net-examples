using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.svg";
        string outputPath = @"C:\Images\output_gaussian_blur.png";

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
                // Cast to RasterImage to apply raster filters
                RasterImage rasterImage = (RasterImage)image;

                // Apply Gaussian blur with kernel size 11 and sigma 4.5 to the whole image
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(11, 4.5));

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
 * 1. When a developer needs to soften the details of an SVG logo before converting it to a PNG thumbnail for a web gallery.
 * 2. When an application must reduce visual noise in vector‑based diagrams by applying a Gaussian blur with a kernel size of 11 and sigma 4.5 during batch processing.
 * 3. When a reporting tool generates SVG charts and wants to create a blurred background effect for PDF export by rendering the image as a PNG.
 * 4. When a UI component requires a smooth, out‑of‑focus preview of an SVG icon, using C# and Aspose.Imaging to apply a Gaussian blur filter before display.
 * 5. When an e‑commerce platform automatically creates stylized product images by loading SVG assets, blurring them, and saving the result as PNG for promotional banners.
 */