using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the SVG image
            using (Image svgImage = Image.Load(inputPath))
            {
                // Set up rasterization options for PNG output
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Rasterize SVG to PNG in memory
                using (MemoryStream ms = new MemoryStream())
                {
                    svgImage.Save(ms, pngOptions);
                    ms.Position = 0;

                    // Load the rasterized PNG
                    using (Image rasterImageContainer = Image.Load(ms))
                    {
                        RasterImage rasterImage = (RasterImage)rasterImageContainer;

                        // Apply Gaussian blur with radius 2 and sigma 1.0
                        var blurOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(2, 1.0);
                        rasterImage.Filter(rasterImage.Bounds, blurOptions);

                        // Save the blurred image as high-quality PNG
                        rasterImage.Save(outputPath, new PngOptions());
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
 * 1. When a web developer needs to convert an SVG logo into a blurred PNG thumbnail for faster page loading and consistent appearance across browsers.
 * 2. When a desktop application generates preview images of vector diagrams and wants to apply a subtle Gaussian blur to soften edges before saving them as high‑quality PNG files.
 * 3. When an e‑commerce platform creates product watermarks by rasterizing SVG badges, applying a radius‑2 blur for a smooth effect, and exporting the result as PNG for display on product pages.
 * 4. When a reporting tool transforms SVG charts into PNG assets, adds a gentle blur to reduce visual noise, and stores the images for inclusion in PDF or email reports.
 * 5. When a mobile app preprocesses SVG icons, applies a Gaussian blur to achieve a soft‑shadow look, and saves them as high‑resolution PNGs for use in the app’s UI.
 */