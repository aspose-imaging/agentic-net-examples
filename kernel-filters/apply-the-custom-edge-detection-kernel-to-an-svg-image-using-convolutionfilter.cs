using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output.png";
            string tempPath = "temp.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            Directory.CreateDirectory(Path.GetDirectoryName(tempPath));

            using (Image svgImage = Image.Load(inputPath))
            {
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                svgImage.Save(tempPath, pngOptions);
            }

            using (Image img = Image.Load(tempPath))
            {
                var rasterImage = (RasterImage)img;

                double[,] kernel = new double[,]
                {
                    { -1, -1, -1 },
                    { -1,  8, -1 },
                    { -1, -1, -1 }
                };

                var convOptions = new ConvolutionFilterOptions(kernel, 1.0, 0);
                rasterImage.Filter(rasterImage.Bounds, convOptions);
                rasterImage.Save(outputPath);
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
 * 1. When a developer needs to convert an SVG logo to a high‑resolution PNG and apply a custom edge‑detection convolution filter to make the logo’s outlines sharper.
 * 2. When an application must generate thumbnail previews of vector diagrams, rasterize the SVG to PNG, and highlight the diagram edges using a convolution kernel.
 * 3. When a web service processes user‑uploaded SVG icons, rasterizes them to PNG, and applies edge‑enhancement to improve visual contrast for accessibility.
 * 4. When a reporting tool creates printable PNG charts from SVG templates and uses a custom convolution filter to emphasize borders for better readability.
 * 5. When a batch job automates the conversion of a folder of SVG assets to PNG files with built‑in edge detection to prepare the images for downstream machine‑learning preprocessing.
 */