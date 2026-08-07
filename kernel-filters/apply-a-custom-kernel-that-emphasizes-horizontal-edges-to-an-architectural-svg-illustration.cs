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
        string inputPath = "input.svg";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load SVG and rasterize to a temporary PNG
            string tempPngPath = Path.Combine(Path.GetDirectoryName(outputPath), "temp.png");
            using (Image image = Image.Load(inputPath))
            {
                SvgImage svgImage = (SvgImage)image;

                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size,
                    BackgroundColor = Color.White
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                svgImage.Save(tempPngPath, pngOptions);
            }

            // Load the rasterized PNG, apply horizontal edge detection kernel, and save final output
            using (Image rasterImageContainer = Image.Load(tempPngPath))
            {
                RasterImage rasterImage = (RasterImage)rasterImageContainer;

                double[,] kernel = new double[,]
                {
                    { -1, -2, -1 },
                    {  0,  0,  0 },
                    {  1,  2,  1 }
                };

                var convOptions = new ConvolutionFilterOptions(kernel);
                rasterImage.Filter(rasterImage.Bounds, convOptions);
                rasterImage.Save(outputPath);
            }

            // Clean up temporary file
            File.Delete(tempPngPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer wants to highlight horizontal edges in an architectural SVG drawing by converting it to PNG and applying a Sobel‑like convolution kernel.
 * 2. When a C# application needs to rasterize vector floor plans from SVG to a raster format before performing edge detection for feature extraction.
 * 3. When a .NET service must generate a printable PNG preview of a building blueprint with emphasized horizontal lines for visual inspection.
 * 4. When an image‑processing pipeline requires converting SVG schematics to raster images and applying a custom convolution filter to detect roof or wall outlines.
 * 5. When a developer is building a GIS tool that extracts horizontal structural edges from SVG maps by loading, rasterizing, filtering, and saving the result as PNG.
 */