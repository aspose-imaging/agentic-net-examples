using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.svg";
        string outputPath = "output.png";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            // Load the SVG image
            using (SvgImage svgImage = new SvgImage(inputPath))
            {
                // Set up rasterization options for SVG -> raster conversion
                SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions();

                // Prepare PNG save options that include the rasterization settings
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Rasterize SVG into a memory stream
                using (MemoryStream rasterStream = new MemoryStream())
                {
                    svgImage.Save(rasterStream, pngOptions);
                    rasterStream.Position = 0;

                    // Load the rasterized image as a RasterImage to apply filters
                    using (RasterImage rasterImage = (RasterImage)Image.Load(rasterStream))
                    {
                        // Apply Gaussian blur filter (radius 5, sigma 4.0)
                        rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                        // Apply Gauss-Wiener deconvolution filter (radius 5, sigma 4.0)
                        rasterImage.Filter(rasterImage.Bounds, new GaussWienerFilterOptions(5, 4.0));

                        // Ensure the output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the processed image
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
 * 1. When a developer needs to convert an SVG logo to a high‑resolution PNG while smoothing and sharpening the image for web display.
 * 2. When a graphics pipeline requires applying a Gaussian blur followed by Gauss‑Wiener deconvolution to reduce noise in vector‑based diagrams before embedding them in a PDF.
 * 3. When an e‑learning platform wants to preprocess SVG illustrations into PNG thumbnails with controlled blur and de‑blur effects using C# and Aspose.Imaging.
 * 4. When a UI designer automates the generation of blurred background assets from SVG icons, then restores edge detail with deconvolution for mobile app themes.
 * 5. When a data‑visualization tool programmatically rasterizes SVG charts to PNG and applies blur and deconvolution filters to enhance visual clarity in printed reports.
 */