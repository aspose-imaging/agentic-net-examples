using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output\\result.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (FileStream inputStream = File.OpenRead(inputPath))
            using (SvgImage svgImage = new SvgImage(inputStream))
            {
                var rasterOptions = new SvgRasterizationOptions { PageSize = svgImage.Size };
                var pngOptions = new PngOptions { VectorRasterizationOptions = rasterOptions };

                using (MemoryStream ms = new MemoryStream())
                {
                    svgImage.Save(ms, pngOptions);
                    ms.Position = 0;

                    using (Image img = Image.Load(ms))
                    {
                        RasterImage raster = (RasterImage)img;

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
 * 1. When a developer needs to convert a vector logo (SVG) into a high‑contrast BMP thumbnail for a legacy Windows application, applying sharpen and emboss to enhance edge definition.
 * 2. When generating printable assets for a manufacturing system that only accepts BMP files, and the source artwork is in SVG, the code can rasterize, sharpen, and emboss the image to improve visual depth before saving.
 * 3. When creating custom map tiles where the original map is stored as SVG and the tile server requires BMP format with emphasized terrain features, the filter chain adds clarity and a 3‑D emboss effect.
 * 4. When preparing SVG icons for an embedded device that only supports BMP graphics, the developer can use this code to rasterize, sharpen details, and emboss to make the icons stand out on low‑resolution screens.
 * 5. When automating a batch process that transforms SVG diagrams into BMP images for inclusion in a PDF report, applying sharpen and emboss ensures the diagrams remain crisp and visually distinct after conversion.
 */