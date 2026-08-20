// HOW-TO: Resize BMP to 1024x1024, Apply Gaussian Blur, Save as SVG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.bmp";
        string outputPath = "output.svg";

        try
        {
            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for raster operations
                RasterImage raster = (RasterImage)image;

                // Resize to 1024x1024
                raster.Resize(1024, 1024);

                // Apply Gaussian blur (radius 5, sigma 4.0)
                raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Save the result as SVG
                SvgOptions svgOptions = new SvgOptions();
                raster.Save(outputPath, svgOptions);
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
 * 1. When you need to convert a high‑resolution BMP logo into a scalable SVG for web use while applying a soft blur effect.
 * 2. When preparing thumbnail previews of bitmap drawings that must be resized to a fixed 1024 × 1024 size and exported as vector graphics.
 * 3. When a desktop application must programmatically blur and vectorize scanned BMP documents for inclusion in PDF reports.
 * 4. When automating a batch process that standardizes legacy BMP assets to a uniform dimension, adds a Gaussian blur, and stores them as SVG files for responsive design.
 * 5. When integrating image processing into a C# service that receives BMP uploads, resizes them, applies a blur filter, and returns SVG output for downstream rendering.
 */
