// HOW-TO: Apply Emboss5x5 Filter to SVG and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "templates/input.svg";
        string outputPath = "output/embossed.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image svgImg = Image.Load(inputPath))
            {
                SvgImage svgImage = (SvgImage)svgImg;

                string tempPath = Path.Combine(Path.GetDirectoryName(outputPath), "temp.png");
                Directory.CreateDirectory(Path.GetDirectoryName(tempPath));

                var pngOptions = new PngOptions();
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageWidth = svgImage.Width,
                    PageHeight = svgImage.Height
                };
                pngOptions.VectorRasterizationOptions = rasterOptions;

                svgImage.Save(tempPath, pngOptions);

                using (RasterImage raster = (RasterImage)Image.Load(tempPath))
                {
                    raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss5x5));
                    raster.Save(outputPath, new PngOptions());
                }

                File.Delete(tempPath);
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
 * 1. When you need to convert an SVG logo to a PNG thumbnail with an embossed effect for a web UI.
 * 2. When generating product catalog images from vector assets and want a subtle 3‑D look without manual editing.
 * 3. When automating batch processing of SVG icons to create embossed PNGs for mobile app assets.
 * 4. When preparing printable graphics from SVG files and require a raised‑edge appearance for visual emphasis.
 * 5. When integrating image processing into a C# service that transforms vector diagrams into stylized raster images for reports.
 */
