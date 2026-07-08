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

        try
        {
            // Load the SVG image
            using (Image svgImage = Image.Load(inputPath))
            {
                // Set up rasterization options for converting SVG to raster format
                var rasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size
                };

                // Configure PNG save options with the rasterization settings
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Rasterize SVG into a memory stream
                using (var memoryStream = new MemoryStream())
                {
                    svgImage.Save(memoryStream, pngOptions);
                    memoryStream.Position = 0; // Reset stream position for reading

                    // Load the rasterized image
                    using (Image rasterImage = Image.Load(memoryStream))
                    {
                        var raster = (RasterImage)rasterImage;

                        // Apply Gaussian blur filter
                        raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                        // Apply Gauss-Wiener deconvolution filter
                        raster.Filter(raster.Bounds, new GaussWienerFilterOptions(5, 4.0));

                        // Save the processed image to the output path
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
 * 1. When a web application needs to generate a softened logo from an SVG and then sharpen it to remove rendering artifacts before serving it as a PNG thumbnail.
 * 2. When an e‑commerce platform wants to create product badge overlays from vector SVGs, apply a gentle blur for visual depth, and then deconvolve to retain crisp edges in the final PNG.
 * 3. When a scientific reporting tool converts SVG diagrams to raster images, uses Gaussian blur to reduce noise and Gauss‑Wiener deconvolution to enhance detail for high‑resolution PDF export.
 * 4. When a mobile game engine imports SVG assets, applies blur for a motion‑blur effect and deconvolution to correct the blur, then saves the result as a PNG for fast texture loading.
 * 5. When an automated branding pipeline processes corporate SVG icons, applies blur to match a design style and deconvolution to preserve legibility before storing the PNG in a CDN.
 */