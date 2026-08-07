using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string intermediatePath = "temp\\intermediate.png";
            string outputPath = "output\\filtered.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(intermediatePath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Rasterize SVG to PNG
            using (Image svgImage = Image.Load(inputPath))
            {
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = ((Aspose.Imaging.FileFormats.Svg.SvgImage)svgImage).Size
                };

                var pngSaveOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                svgImage.Save(intermediatePath, pngSaveOptions);
            }

            // Load raster PNG and apply reduced emboss filter
            using (Image rasterImage = Image.Load(intermediatePath))
            {
                RasterImage raster = (RasterImage)rasterImage;

                double[,] originalKernel = ConvolutionFilter.Emboss5x5;
                double factor = 0.5;
                int size = originalKernel.GetLength(0);
                double[,] kernel = new double[size, size];

                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        kernel[i, j] = originalKernel[i, j] * factor;
                    }
                }

                var filterOptions = new ConvolutionFilterOptions(kernel);
                raster.Filter(raster.Bounds, filterOptions);
                raster.Save(outputPath);
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
 * 1. When a developer wants to create a subtle embossed effect on a company logo stored as SVG before publishing it as a PNG on a website.
 * 2. When an e‑learning platform needs to convert vector illustrations to raster images with a reduced emboss filter to improve readability on low‑resolution screens.
 * 3. When a mobile app generates thumbnails from user‑uploaded SVG icons and applies a light emboss to add depth without overwhelming the UI.
 * 4. When a print‑ready PDF workflow requires rasterizing SVG diagrams to PNG with a softened emboss effect to meet branding guidelines.
 * 5. When a digital signage system automatically processes SVG artwork, applies a mild emboss filter, and saves the result as PNG for fast rendering on displays.
 */