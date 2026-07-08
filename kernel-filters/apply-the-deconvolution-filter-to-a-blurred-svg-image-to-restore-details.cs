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
        string inputPath = @"C:\Images\blurred.svg";
        string outputPath = @"C:\Images\restored.png";

        // Path safety checks
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the SVG image
            using (Image svgImage = Image.Load(inputPath))
            {
                // Set up rasterization options to convert SVG to raster format
                var rasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Rasterize SVG into a memory stream
                using (var ms = new MemoryStream())
                {
                    svgImage.Save(ms, pngOptions);
                    ms.Position = 0;

                    // Load the rasterized image
                    using (Image rasterImage = Image.Load(ms))
                    {
                        var raster = (RasterImage)rasterImage;

                        // Apply a Gauss-Wiener deconvolution filter to restore details
                        var deconvOptions = new GaussWienerFilterOptions(5, 1.0);
                        raster.Filter(raster.Bounds, deconvOptions);

                        // Save the processed image
                        raster.Save(outputPath);
                    }
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
 * 1. When a web application needs to convert user‑uploaded blurred SVG logos into sharp PNG thumbnails for display on high‑resolution screens.
 * 2. When an e‑commerce platform must restore fine details in product vector illustrations that became blurry after compression before generating printable PNG assets.
 * 3. When a document‑generation service processes scanned SVG diagrams that suffer from motion blur and requires deconvolution to improve readability in the final PDF.
 * 4. When a GIS tool rasterizes blurred SVG map overlays and applies a Gauss‑Wiener filter to enhance road and label clarity before exporting to PNG tiles.
 * 5. When an automated branding pipeline receives low‑quality SVG assets from partners and needs to automatically deblur and rasterize them to PNG for consistent branding across digital channels.
 */