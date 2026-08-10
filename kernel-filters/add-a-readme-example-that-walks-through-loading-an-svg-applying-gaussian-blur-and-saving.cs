// HOW-TO: How To Rasterize SVG To PNG And Apply Gaussian Blur In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputSvgPath = @"C:\Images\input.svg";
        string intermediatePngPath = @"C:\Images\intermediate.png";
        string outputPngPath = @"C:\Images\output.png";

        try
        {
            // Verify input SVG exists
            if (!File.Exists(inputSvgPath))
            {
                Console.Error.WriteLine($"File not found: {inputSvgPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(intermediatePngPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPngPath));

            // Load the SVG image
            using (Image svgImage = Image.Load(inputSvgPath))
            {
                // Set up rasterization options for SVG to PNG conversion
                var rasterizationOptions = new SvgRasterizationOptions();
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Save the rasterized SVG as an intermediate PNG
                svgImage.Save(intermediatePngPath, pngOptions);
            }

            // Load the intermediate PNG as a raster image
            using (RasterImage rasterImage = (RasterImage)Image.Load(intermediatePngPath))
            {
                // Apply Gaussian blur filter (radius 5, sigma 4.0) to the whole image
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Save the blurred image to the final output path
                rasterImage.Save(outputPngPath);
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
 * 1. When you need to convert vector SVG graphics into a raster PNG for web thumbnails and then soften the image with a Gaussian blur.
 * 2. When generating blurred background images from SVG logos for UI overlays in a C# desktop application.
 * 3. When preprocessing SVG assets for machine‑learning pipelines that require blurred raster images in PNG format.
 * 4. When creating stylized product mockups where the original SVG must be rasterized and a blur effect applied before compositing.
 * 5. When automating batch processing of SVG icons to produce blurred PNG versions for responsive design breakpoints.
 */
