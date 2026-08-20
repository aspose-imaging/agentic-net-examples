// HOW-TO: Apply Emboss5x5 Filter to SVG and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "templates/input.svg";
            string outputPath = "output/output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var svgImage = (Aspose.Imaging.FileFormats.Svg.SvgImage)image;

                // Rasterize SVG to PNG in memory
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = svgImage.Size
                    }
                };

                using (var memoryStream = new MemoryStream())
                {
                    svgImage.Save(memoryStream, pngOptions);
                    memoryStream.Position = 0;

                    using (Image rasterImageContainer = Image.Load(memoryStream))
                    {
                        var rasterImage = (RasterImage)rasterImageContainer;

                        // Apply Emboss5x5 filter
                        rasterImage.Filter(rasterImage.Bounds,
                            new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                                Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss5x5));

                        // Save the filtered image
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
 * 1. When you need to convert vector SVG graphics to raster PNG files while adding a 3‑D emboss effect for web thumbnails.
 * 2. When generating product catalog images from SVG logos and want a stylized embossed look without using external image editors.
 * 3. When automating batch processing of SVG icons to create embossed PNG assets for mobile app UI resources.
 * 4. When preparing SVG illustrations for print or PDF inclusion and require a subtle depth filter applied programmatically.
 * 5. When building a server‑side image service that receives SVG uploads, rasterizes them, applies an emboss filter, and returns PNGs to clients.
 */
