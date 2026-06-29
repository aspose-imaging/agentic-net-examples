using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Rasterize SVG to a temporary PNG
            string tempPngPath = Path.Combine(Path.GetDirectoryName(outputPath), "temp.png");
            using (Image svgImage = Image.Load(inputPath))
            {
                VectorRasterizationOptions vectorOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size
                };
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = vectorOptions
                };
                svgImage.Save(tempPngPath, pngOptions);
            }

            // Load the rasterized PNG and apply Gaussian blur
            using (Image rasterImageContainer = Image.Load(tempPngPath))
            {
                RasterImage rasterImage = (RasterImage)rasterImageContainer;
                rasterImage.Filter(rasterImage.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 1.0));
                rasterImage.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to rasterize an SVG logo to a PNG thumbnail and apply a Gaussian blur (size 5, sigma 1.0) for smooth UI icons using Aspose.Imaging for .NET.
 * 2. When a web service generates blurred background PNGs from vector SVG assets on the fly, employing C# rasterization and the Gaussian blur filter to improve responsive design aesthetics.
 * 3. When a reporting application converts SVG charts to raster images and adds a subtle Gaussian blur to de‑emphasize grid lines before embedding the PNG in PDF reports.
 * 4. When an e‑commerce platform creates product preview images by rasterizing SVG product illustrations to PNG and applying a Gaussian blur to mask details during loading placeholders.
 * 5. When a desktop publishing tool processes SVG illustrations, rasterizes them to PNG, and uses the GetGaussian (size 5, sigma 1.0) filter to produce blurred watermarks for copyrighted images.
 */