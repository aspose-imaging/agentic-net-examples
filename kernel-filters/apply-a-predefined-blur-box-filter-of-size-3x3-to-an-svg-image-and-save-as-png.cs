// HOW-TO: Apply 3x3 Blur Box Filter to SVG and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output/output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image svgImage = Image.Load(inputPath))
            {
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = new SizeF(svgImage.Width, svgImage.Height),
                    BackgroundColor = Color.White
                };

                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                using (MemoryStream ms = new MemoryStream())
                {
                    svgImage.Save(ms, pngOptions);
                    ms.Position = 0;

                    using (RasterImage raster = (RasterImage)Image.Load(ms))
                    {
                        double[,] kernel = ConvolutionFilter.GetBlurBox(3);
                        ConvolutionFilterOptions filterOptions = new ConvolutionFilterOptions(kernel);
                        raster.Filter(raster.Bounds, filterOptions);

                        PngOptions outOptions = new PngOptions();
                        raster.Save(outputPath, outOptions);
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
 * 1. When you need to generate a softened PNG thumbnail from an SVG logo for a website’s UI.
 * 2. When you want to preprocess vector graphics by applying a blur effect before embedding them in a PDF report.
 * 3. When you are creating low‑resolution preview images of SVG diagrams with a uniform blur for a design‑review tool.
 * 4. When you must convert SVG icons to PNG format while adding a subtle blur to match a mobile app’s visual style.
 * 5. When you automate batch processing of SVG assets, applying a 3×3 blur box filter and saving the results as PNG files for a game’s texture pipeline.
 */
