// HOW-TO: Handle Invalid Convolution Filter Kernel When Converting SVG to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output.png";
            string tempPngPath = "temp.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");
            Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath) ?? ".");

            using (Image svgImg = Image.Load(inputPath))
            {
                SvgImage svgImage = (SvgImage)svgImg;
                svgImage.Save(tempPngPath, new PngOptions());
            }

            using (RasterImage raster = (RasterImage)Image.Load(tempPngPath))
            {
                double[,] invalidKernel = new double[2, 3];
                try
                {
                    raster.Filter(raster.Bounds, new ConvolutionFilterOptions(invalidKernel));
                }
                catch (Exception filterEx)
                {
                    Console.Error.WriteLine($"Filter error: {filterEx.Message}");
                }

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
 * 1. When you need to convert an SVG illustration to a PNG file while safely handling possible errors from an invalid custom convolution filter kernel.
 * 2. When your image processing pipeline applies user‑defined convolution kernels to rasterized SVGs and you must log filter exceptions without stopping the conversion.
 * 3. When you are building a C# service that generates PNG assets from SVG sources and want to catch and record filter‑related errors for debugging.
 * 4. When you want to ensure that missing or malformed kernel dimensions do not break the rendering of SVG graphics in a .NET application.
 * 5. When you need to create a temporary PNG from an SVG, attempt a convolution operation, and gracefully handle any exception before saving the final image.
 */
