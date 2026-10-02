// HOW-TO: Apply Corner Detection Kernel to SVG and Save as PNG in C# (Aspose.Imaging for .NET)
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
        string inputPath = "input/input.svg";
        string tempPath = "temp/temp.png";
        string outputPath = "output/output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(tempPath));
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image svgImage = Image.Load(inputPath))
            {
                var pngOptions = new PngOptions();
                svgImage.Save(tempPath, pngOptions);
            }

            using (RasterImage raster = (RasterImage)Image.Load(tempPath))
            {
                double[,] customKernel = new double[,]
                {
                    { 1, 0, 1 },
                    { 0, 0, 0 },
                    { 1, 0, 1 }
                };

                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(customKernel);
                raster.Filter(raster.Bounds, filterOptions);

                var outOptions = new PngOptions();
                raster.Save(outputPath, outOptions);
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
 * 1. When you need to convert vector SVG graphics to raster PNG files while emphasizing corner features for further analysis.
 * 2. When you want to preprocess SVG images with a custom convolution kernel to highlight edges before feeding them into a machine‑learning model.
 * 3. When generating thumbnails of SVG icons that require corner isolation to improve visual contrast in a UI.
 * 4. When preparing SVG artwork for print or web where a corner‑detect filter helps identify alignment issues.
 * 5. When automating a batch workflow that transforms SVG assets into PNGs and applies a custom filter to detect corners for quality‑control checks.
 */
