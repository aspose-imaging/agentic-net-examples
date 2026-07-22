using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.svg";
            string outputPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (SvgImage svgImage = new SvgImage(inputPath))
            {
                // Set up rasterization options for PNG output
                var rasterizationOptions = new SvgRasterizationOptions();
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Rasterize SVG to a memory stream (PNG format)
                using (var ms = new MemoryStream())
                {
                    svgImage.Save(ms, pngOptions);
                    ms.Position = 0;

                    // Load the rasterized PNG as a RasterImage to apply the filter
                    using (RasterImage rasterImage = (RasterImage)Image.Load(ms))
                    {
                        // Apply the predefined 3x3 sharpen convolution kernel
                        rasterImage.Filter(
                            rasterImage.Bounds,
                            new ConvolutionFilterOptions(ConvolutionFilter.Sharpen3x3));

                        // Save the sharpened image as PNG
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
 * 1. When a developer needs to convert an SVG icon set into PNG assets for a mobile app and wants to improve edge definition by applying the Sharpen3x3 convolution filter.
 * 2. When a web‑service generates dynamic charts as SVG templates and must deliver them as sharpened PNG images for faster loading in browsers.
 * 3. When an e‑commerce platform automates product image processing by rasterizing vendor‑provided SVG logos to PNG and enhancing visual clarity with a 3×3 sharpen filter.
 * 4. When a reporting tool exports vector diagrams to PNG for inclusion in PDF reports and requires a crisp appearance achieved through Aspose.Imaging’s Sharpen3x3 filter.
 * 5. When a desktop application batch‑processes SVG UI assets, converts them to PNG, and applies a convolution sharpen operation to meet branding guidelines for high‑contrast displays.
 */