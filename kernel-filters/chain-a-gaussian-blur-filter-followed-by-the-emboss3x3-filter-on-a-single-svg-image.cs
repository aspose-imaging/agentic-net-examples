using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.svg";
        string outputPath = "output.png";

        // Input file existence check
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
                // Rasterize SVG to PNG in memory
                using (var memoryStream = new MemoryStream())
                {
                    var rasterOptions = new SvgRasterizationOptions { PageSize = svgImage.Size };
                    var pngOptions = new PngOptions { VectorRasterizationOptions = rasterOptions };
                    svgImage.Save(memoryStream, pngOptions);
                    memoryStream.Position = 0;

                    // Load the rasterized image
                    using (Image rasterImageContainer = Image.Load(memoryStream))
                    {
                        RasterImage rasterImage = (RasterImage)rasterImageContainer;

                        // Apply Gaussian blur filter (radius 5, sigma 4.0)
                        rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                        // Apply Emboss3x3 filter using convolution filter options
                        rasterImage.Filter(rasterImage.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

                        // Save the final image as PNG
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
 * 1. When a developer needs to generate a stylized thumbnail of an SVG logo for a web dashboard, applying a Gaussian blur followed by an emboss effect creates a soft‑raised look before saving the result as a PNG file.
 * 2. When preparing SVG illustrations for print brochures, a developer can rasterize the vector, blur edges to reduce aliasing, then emboss to add subtle depth, outputting a high‑resolution PNG image.
 * 3. When building an image‑processing pipeline that converts user‑uploaded SVG icons into PNG assets with a smooth glow and tactile emboss for a mobile app UI, this code automates the filter chain in C#.
 * 4. When creating artistic background textures from SVG patterns, a developer may apply a Gaussian blur to blend shapes and then an Emboss3x3 filter to simulate a raised surface before exporting the result as a PNG.
 * 5. When generating preview images for an e‑commerce catalog where SVG product drawings need a soft focus and embossed highlight to match the site’s visual style, this code provides the required transformation.
 */