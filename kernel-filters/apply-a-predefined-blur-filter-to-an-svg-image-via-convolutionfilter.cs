using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input\\image.svg";
            string outputPath = "output\\blurred.png";
            string tempPath = "temp\\temp.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output and temporary directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            Directory.CreateDirectory(Path.GetDirectoryName(tempPath));

            // Load SVG and rasterize to a temporary PNG
            using (Image svgImage = Image.Load(inputPath))
            {
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                svgImage.Save(tempPath, pngOptions);
            }

            // Load the rasterized PNG, apply Gaussian blur, and save the result
            using (Image rasterImage = Image.Load(tempPath))
            {
                var raster = (RasterImage)rasterImage;
                // Apply Gaussian blur with radius 5 and sigma 4.0
                raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));
                raster.Save(outputPath);
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
 * 1. When a web developer uses Aspose.Imaging for .NET to generate a blurred PNG thumbnail from an SVG logo for a website’s loading screen.
 * 2. When a desktop application needs to rasterize an SVG illustration to PNG and apply a Gaussian blur filter to create a soft‑focus image for a print brochure.
 * 3. When an e‑commerce platform automatically converts product SVG icons to blurred background PNGs for promotional banners using C# image processing.
 * 4. When a UI designer programmatically adds a subtle blur effect to SVG assets before saving them as PNGs for mobile app splash screens with Aspose.Imaging.
 * 5. When a data‑visualization tool rasterizes SVG charts to PNG and applies a Gaussian blur to de‑emphasize certain chart elements in a generated report.
 */