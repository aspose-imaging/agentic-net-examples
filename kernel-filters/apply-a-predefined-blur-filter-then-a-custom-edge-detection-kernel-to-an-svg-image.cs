using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded paths
        string inputPath = @"C:\Images\input.svg";
        string intermediatePath = @"C:\Images\temp.png";
        string outputPath = @"C:\Images\output.png";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load SVG image
            using (SvgImage svgImage = new SvgImage(inputPath))
            {
                // Set up rasterization options for SVG -> PNG conversion
                SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions
                {
                    // Use default page size; can be customized if needed
                    PageWidth = 800,
                    PageHeight = 600
                };

                // Set up PNG save options with the rasterization settings
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Save rasterized PNG to an intermediate file
                svgImage.Save(intermediatePath, pngOptions);
            }

            // Load the rasterized PNG as a RasterImage to apply filters
            using (Image image = Image.Load(intermediatePath))
            {
                RasterImage rasterImage = (RasterImage)image;

                // Apply Gaussian blur filter
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Apply sharpen filter (acts as an edge‑detection kernel)
                rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(5, 4.0));

                // Save the final processed image
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
 * 1. When a developer needs to rasterize an SVG logo to PNG, apply a Gaussian blur for a soft background effect, and then use an edge‑detection kernel to highlight the logo’s outlines for a web UI.
 * 2. When an e‑learning platform preprocesses vector diagrams by converting SVGs to PNG thumbnails, adding blur to reduce visual clutter and sharpening edges to improve annotation visibility.
 * 3. When a GIS application generates map tiles from SVG files, uses a blur filter to smooth terrain textures and a custom edge‑detection filter to accentuate road and boundary lines in the resulting PNG.
 * 4. When a marketing automation tool creates stylized product icons by rasterizing SVG assets, applying a blur for a glow effect and then extracting edges to add a crisp drop‑shadow overlay.
 * 5. When a medical imaging system transforms SVG anatomical illustrations into PNGs, smooths fine details with Gaussian blur and emphasizes contours with an edge‑detection kernel for clearer diagnostic reports.
 */