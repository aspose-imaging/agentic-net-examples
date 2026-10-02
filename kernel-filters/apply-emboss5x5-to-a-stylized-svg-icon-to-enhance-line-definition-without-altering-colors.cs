// HOW-TO: Apply Emboss5x5 Filter to SVG Icon and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var svgImage = (SvgImage)image;

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new Aspose.Imaging.ImageOptions.SvgRasterizationOptions
                    {
                        PageWidth = svgImage.Width,
                        PageHeight = svgImage.Height,
                        BackgroundColor = Aspose.Imaging.Color.White
                    }
                };

                using (var ms = new MemoryStream())
                {
                    svgImage.Save(ms, pngOptions);
                    ms.Position = 0;

                    using (RasterImage raster = (RasterImage)Image.Load(ms))
                    {
                        var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                            Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss5x5);

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
 * 1. When you need to convert a vector SVG logo into a high‑contrast PNG thumbnail with enhanced edge definition for UI icons.
 * 2. When you want to programmatically apply an emboss effect to a stylized SVG illustration before exporting it as a raster image for print or web.
 * 3. When a desktop application must render SVG assets with a white background and sharpen their lines using the Emboss5x5 convolution filter in C#.
 * 4. When automating a build pipeline that processes SVG icons, adds depth via embossing, and outputs PNG files for responsive design assets.
 * 5. When creating custom image processing tools that require loading SVG, rasterizing at original dimensions, applying a convolution filter, and saving the result without altering original colors.
 */
