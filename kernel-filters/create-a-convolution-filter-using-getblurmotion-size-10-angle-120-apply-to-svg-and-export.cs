using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (Image image = Image.Load(inputPath))
            {
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                using (var ms = new MemoryStream())
                {
                    image.Save(ms, pngOptions);
                    ms.Position = 0;

                    using (Image rasterImg = Image.Load(ms))
                    {
                        var raster = (RasterImage)rasterImg;

                        var kernel = ConvolutionFilter.GetBlurMotion(10, 120.0);
                        var filterOptions = new ConvolutionFilterOptions(kernel);
                        raster.Filter(raster.Bounds, filterOptions);

                        raster.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to add a motion‑blur effect to an SVG logo before converting it to a PNG for use on a website.
 * 2. When an automated build pipeline must generate blurred thumbnails from vector assets to improve page load performance.
 * 3. When a desktop application requires dynamic image processing to simulate camera shake on SVG illustrations and export them as raster PNG files.
 * 4. When a reporting tool has to rasterize SVG charts, apply a directional blur of size 10 at 120° and embed the result in PDF documents.
 * 5. When a batch script processes a folder of SVG icons, applies a consistent motion‑blur filter, and saves the output as high‑quality PNGs for mobile apps.
 */