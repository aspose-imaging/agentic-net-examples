// HOW-TO: Apply Gaussian Blur and Deconvolution to SVG and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

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
            using (Image svgImage = Image.Load(inputPath))
            {
                // Prepare rasterization options for converting SVG to raster
                var rasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size
                };

                // Rasterize SVG to a PNG in memory
                using (var memoryStream = new MemoryStream())
                {
                    var pngSaveOptions = new PngOptions
                    {
                        VectorRasterizationOptions = rasterizationOptions
                    };
                    svgImage.Save(memoryStream, pngSaveOptions);
                    memoryStream.Position = 0;

                    // Load the rasterized image as a RasterImage
                    using (Image rasterImageBase = Image.Load(memoryStream))
                    {
                        var rasterImage = (RasterImage)rasterImageBase;

                        // Apply Gaussian blur filter
                        rasterImage.Filter(
                            rasterImage.Bounds,
                            new GaussianBlurFilterOptions(5, 4.0));

                        // Apply Gauss-Wiener deconvolution filter
                        rasterImage.Filter(
                            rasterImage.Bounds,
                            new GaussWienerFilterOptions(5, 4.0));

                        // Save the processed image to the output path
                        rasterImage.Save(outputPath);
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
 * 1. When you need to reduce noise in a vector graphic before converting it to a raster format for web display.
 * 2. When you want to sharpen details in an SVG after applying a blur to simulate depth‑of‑field effects.
 * 3. When preparing SVG logos for printing and require both smoothing and de‑blurring to meet quality standards.
 * 4. When automating a batch process that converts SVG icons to PNG thumbnails with consistent blur and deconvolution settings.
 * 5. When integrating image preprocessing into a C# application that analyses rasterized SVGs for computer‑vision tasks.
 */
