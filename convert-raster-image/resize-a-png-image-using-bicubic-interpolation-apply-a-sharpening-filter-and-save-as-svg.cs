// HOW-TO: Resize PNG With Sharpen Filter And Convert To SVG In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output.svg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outDir ?? ".");

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                int newWidth = image.Width * 2;
                int newHeight = image.Height * 2;
                image.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);
                image.Filter(image.Bounds, new SharpenFilterOptions());
                SvgOptions svgOptions = new SvgOptions();
                image.Save(outputPath, svgOptions);
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
 * 1. When you need to double the size of a PNG logo for high‑resolution screens, sharpen the result, and store it as an SVG for scalable web use.
 * 2. When automating a pipeline that converts raster UI assets into vector format while preserving detail after upscaling.
 * 3. When preparing print‑ready graphics by enlarging a PNG image, enhancing edge definition with a sharpen filter, and exporting to SVG for lossless scaling.
 * 4. When migrating a legacy PNG icon set to responsive SVG icons, requiring resizing and sharpening to maintain visual quality.
 * 5. When building a C# batch process that upscales PNG screenshots, applies sharpening to counteract blur, and saves them as SVG files for further editing.
 */
