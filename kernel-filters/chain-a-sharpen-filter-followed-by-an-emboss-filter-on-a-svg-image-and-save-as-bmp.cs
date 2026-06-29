using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = @"C:\Images\input.svg";
            string outputPath = @"C:\Images\output.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var svgRasterOptions = new SvgRasterizationOptions
                {
                    PageWidth = image.Width,
                    PageHeight = image.Height,
                    BackgroundColor = Aspose.Imaging.Color.White
                };
                var pngOptions = new PngOptions { VectorRasterizationOptions = svgRasterOptions };

                using (var memoryStream = new MemoryStream())
                {
                    image.Save(memoryStream, pngOptions);
                    memoryStream.Position = 0;

                    using (RasterImage raster = (RasterImage)Image.Load(memoryStream))
                    {
                        raster.Filter(raster.Bounds, new SharpenFilterOptions(5, 4.0));
                        raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

                        var bmpOptions = new BmpOptions();
                        raster.Save(outputPath, bmpOptions);
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
 * 1. When a developer needs to convert a vector SVG logo into a high‑contrast BMP thumbnail for a Windows desktop application, applying a sharpen filter followed by an emboss filter to enhance edge definition.
 * 2. When an e‑commerce platform wants to generate printable BMP product images from SVG artwork while adding visual depth through sharpening and embossing for better catalog presentation.
 * 3. When a GIS system requires rasterizing map SVG layers into BMP tiles with enhanced detail, using Aspose.Imaging C# API to apply sharpening and emboss filters before saving.
 * 4. When a game developer prepares BMP textures from SVG UI icons, chaining a sharpen filter and an emboss filter to create crisp, stylized graphics for in‑game menus.
 * 5. When an automated reporting tool transforms SVG charts into BMP images for inclusion in legacy PDF reports, adding sharpening and emboss effects to improve readability on low‑resolution printers.
 */