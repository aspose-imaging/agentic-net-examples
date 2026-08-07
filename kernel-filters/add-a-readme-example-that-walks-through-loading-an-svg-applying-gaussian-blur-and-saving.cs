using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

namespace SvgGaussianBlurExample
{
    class Program
    {
        static void Main()
        {
            // Path definitions (hard‑coded as required)
            string inputSvgPath = @"C:\temp\input.svg";
            string intermediatePngPath = @"C:\temp\intermediate.png";
            string outputPngPath = @"C:\temp\output_blur.png";

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

                // ------------------------------------------------------------
                // Step 1: Load the SVG and rasterize it to a temporary PNG file
                // ------------------------------------------------------------
                using (Image svgImage = Image.Load(inputSvgPath))
                {
                    // Configure rasterization options for SVG → PNG conversion
                    var rasterizationOptions = new SvgRasterizationOptions();
                    var pngSaveOptions = new PngOptions
                    {
                        VectorRasterizationOptions = rasterizationOptions
                    };

                    // Save the rasterized image to the intermediate PNG file
                    svgImage.Save(intermediatePngPath, pngSaveOptions);
                }

                // ------------------------------------------------------------
                // Step 2: Load the rasterized PNG, apply Gaussian blur, and save
                // ------------------------------------------------------------
                using (Image rasterImageContainer = Image.Load(intermediatePngPath))
                {
                    // Cast to RasterImage to gain access to filtering capabilities
                    var rasterImage = (RasterImage)rasterImageContainer;

                    // Apply Gaussian blur with radius 5 and sigma 4.0 to the whole image
                    var blurOptions = new GaussianBlurFilterOptions(5, 4.0);
                    rasterImage.Filter(rasterImage.Bounds, blurOptions);

                    // Save the blurred image to the final output path
                    rasterImage.Save(outputPngPath);
                }
            }
            catch (Exception ex)
            {
                // Any unexpected error is reported without crashing the program
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    /*
    README Example
    ---------------
    This example demonstrates how to:
    1. Load an SVG file from disk.
    2. Rasterize the SVG to a PNG image.
    3. Apply a Gaussian blur filter to the rasterized image.
    4. Save the processed image.

    Steps:
    • Define the input SVG path and the desired output PNG path.
    • Use `Image.Load` to read the SVG.
    • Configure `SvgRasterizationOptions` and `PngOptions` to rasterize the SVG.
    • Save the rasterized PNG to a temporary location.
    • Load the temporary PNG as a `RasterImage`.
    • Call `Filter` with `GaussianBlurFilterOptions` to blur the image.
    • Save the final blurred PNG.

    The code follows strict path‑safety rules:
    • Input existence is checked with `File.Exists`.
    • Output directories are created with `Directory.CreateDirectory`.
    • All operations are wrapped in a try/catch block to report errors gracefully.
    */
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to convert vector graphics (SVG) into a raster format (PNG) and then apply a Gaussian blur for creating soft‑focused thumbnails in a C# web application.
 * 2. When an e‑commerce platform wants to generate blurred background images from product SVG logos for promotional banners using Aspose.Imaging for .NET.
 * 3. When a UI designer requires automated preprocessing of SVG icons into blurred PNG assets for mobile app splash screens via C# code.
 * 4. When a reporting tool must embed blurred SVG diagrams into PDF reports by rasterizing them to PNG and applying a Gaussian blur filter with Aspose.Imaging.
 * 5. When a content management system automates the creation of stylized, blurred preview images from uploaded SVG files for SEO‑friendly image galleries.
 */