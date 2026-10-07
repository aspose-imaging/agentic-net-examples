// HOW-TO: Apply Horizontal Edge Detection to SVG and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

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

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");
            Directory.CreateDirectory(Path.GetDirectoryName(tempPath) ?? ".");

            // Load SVG and rasterize to temporary PNG
            using (Image image = Image.Load(inputPath))
            {
                var svgImage = (SvgImage)image;
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageWidth = svgImage.Width,
                    PageHeight = svgImage.Height
                };
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };
                image.Save(tempPath, pngOptions);
            }

            // Load raster image, apply horizontal edge detection filter, and save final output
            using (RasterImage raster = (RasterImage)Image.Load(tempPath))
            {
                double[,] kernel = new double[,]
                {
                    { -1, -2, -1 },
                    {  0,  0,  0 },
                    {  1,  2,  1 }
                };
                var filterOptions = new ConvolutionFilterOptions(kernel);
                raster.Filter(raster.Bounds, filterOptions);
                raster.Save(outputPath, new PngOptions());
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
 * 1. When you need to highlight horizontal architectural lines in an SVG blueprint by converting it to a raster PNG with edge detection.
 * 2. When generating stylized floor‑plan thumbnails that emphasize wall edges for a web gallery using Aspose.Imaging in C#.
 * 3. When preprocessing vector diagrams for computer‑vision algorithms that require edge‑enhanced raster images.
 * 4. When creating print‑ready PNGs from SVG schematics with emphasized horizontal features for technical documentation.
 * 5. When automating a batch workflow that converts SVG assets to PNGs while applying a Sobel horizontal filter to improve visual contrast.
 */
