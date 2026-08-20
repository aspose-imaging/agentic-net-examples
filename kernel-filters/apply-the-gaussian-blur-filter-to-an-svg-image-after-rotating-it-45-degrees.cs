// HOW-TO: Apply Gaussian Blur to Rotated SVG and Save as PNG in C# (Aspose.Imaging for .NET)
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
            using (Image image = Image.Load(inputPath))
            {
                // Cast to SvgImage to access vector-specific methods
                SvgImage svgImage = (SvgImage)image;

                // Rotate the SVG by 45 degrees clockwise
                svgImage.Rotate(45f);

                // Prepare rasterization options for PNG output
                var rasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Rasterize the rotated SVG into a memory stream
                using (var ms = new MemoryStream())
                {
                    svgImage.Save(ms, pngOptions);
                    ms.Position = 0; // Reset stream position for reading

                    // Load the rasterized image as a RasterImage
                    using (Image rasterImageContainer = Image.Load(ms))
                    {
                        var rasterImage = (RasterImage)rasterImageContainer;

                        // Apply Gaussian blur filter to the entire image
                        rasterImage.Filter(
                            rasterImage.Bounds,
                            new GaussianBlurFilterOptions(5, 4.0) // radius = 5, sigma = 4.0
                        );

                        // Save the final blurred image
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
 * 1. When you need to generate a blurred thumbnail of a rotated SVG logo for a web dashboard.
 * 2. When you want to preprocess vector icons by rotating them 45 degrees and applying a soft blur before embedding them in a PDF report.
 * 3. When an e‑commerce site requires product illustrations rotated and softened to create consistent promotional banners in PNG format.
 * 4. When a mobile app dynamically rotates user‑uploaded SVG avatars and adds a Gaussian blur effect for privacy before saving them as raster images.
 * 5. When a GIS application must display map symbols at a fixed angle with a subtle blur to improve visual hierarchy in exported PNG tiles.
 */
