using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
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
            using (Image svgImage = Image.Load(inputPath))
            {
                // Rasterize SVG to PNG in memory
                using (var memoryStream = new MemoryStream())
                {
                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = new SvgRasterizationOptions
                        {
                            PageSize = svgImage.Size
                        }
                    };
                    svgImage.Save(memoryStream, pngOptions);
                    memoryStream.Position = 0;

                    // Load the rasterized image
                    using (Image rasterImageContainer = Image.Load(memoryStream))
                    {
                        var rasterImage = (RasterImage)rasterImageContainer;

                        // Apply Gaussian blur filter (radius 5, sigma 4.0)
                        rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                        // Save the filtered image as PNG
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
 * 1. When a developer needs to generate a soft‑focused thumbnail of an SVG logo for a web gallery, they can rasterize the SVG and apply a Gaussian blur filter before saving it as PNG.
 * 2. When creating background images for mobile apps where vector icons must appear with a subtle glow, the code can blur the rasterized SVG to achieve the effect.
 * 3. When preparing print‑ready assets that require a blurred watermark overlay derived from an SVG vector, the developer can use this routine to rasterize and blur the image.
 * 4. When building an automated image‑processing pipeline that converts user‑uploaded SVG diagrams into blurred preview images for faster loading, this code provides the necessary rasterization and Gaussian blur steps.
 * 5. When implementing a PDF generation service that inserts blurred SVG illustrations as decorative elements, the developer can apply the Gaussian blur filter to the rasterized PNG before embedding it.
 */