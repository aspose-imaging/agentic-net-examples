// HOW-TO: Apply Sharpen Then Emboss Filters to SVG and Save as BMP in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string inputPath = "input.svg";
            string tempPngPath = "temp.png";
            string outputPath = "output.bmp";

            // Validate input file
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load SVG and rasterize to PNG (temporary)
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

                svgImage.Save(tempPngPath, pngOptions);
            }

            // Load rasterized PNG, apply filters, and save as BMP
            using (Image rasterImage = Image.Load(tempPngPath))
            {
                var raster = (RasterImage)rasterImage;

                // Sharpen filter
                raster.Filter(raster.Bounds, new SharpenFilterOptions(5, 4.0));

                // Emboss filter using predefined kernel
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

                var bmpOptions = new BmpOptions();
                raster.Save(outputPath, bmpOptions);
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
 * 1. When you need to enhance a vector logo by sharpening and embossing it before converting it to a BMP for legacy Windows applications.
 * 2. When you must preprocess an SVG diagram with edge‑enhancement filters and output a bitmap for printing on devices that only accept BMP files.
 * 3. When you want to automate the creation of stylized thumbnails from SVG icons by applying a sharpen filter followed by an emboss effect in a C# batch job.
 * 4. When a game development pipeline requires converting SVG assets to BMP textures with added detail using Aspose.Imaging filters.
 * 5. When you are building a document generation system that embeds filtered BMP images derived from SVG illustrations for consistent visual styling.
 */
