// HOW-TO: Apply Blur Filter to SVG and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
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

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            string tempPngPath = Path.Combine(Path.GetTempPath(), "temp_svg.png");
            Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath) ?? ".");

            using (Image svgImage = Image.Load(inputPath))
            {
                var pngOptions = new PngOptions();
                svgImage.Save(tempPngPath, pngOptions);
            }

            using (RasterImage raster = (RasterImage)Image.Load(tempPngPath))
            {
                double[,] kernel = ConvolutionFilter.GetBlurBox(5);
                var convOptions = new ConvolutionFilterOptions(kernel);
                raster.Filter(raster.Bounds, convOptions);

                var outPngOptions = new PngOptions();
                raster.Save(outputPath, outPngOptions);
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
 * 1. When you need to soften the edges of an SVG graphic before embedding it as a PNG in a web page.
 * 2. When you want to generate a blurred thumbnail from a vector logo for a mobile app UI.
 * 3. When you must apply a uniform box blur to an SVG diagram to reduce visual noise prior to printing.
 * 4. When you are automating a pipeline that converts SVG assets to PNG with a predefined blur effect for PDF reports.
 * 5. When you require a C# solution that uses Aspose.Imaging to rasterize an SVG and apply a convolution blur filter without external image editors.
 */
