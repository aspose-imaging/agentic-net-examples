// HOW-TO: Convert BMP to Scalable SVG with Custom ViewBox in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.bmp";
        string outputPath = "output.svg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = new SizeF(200, 200)
                };

                var svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

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
 * 1. When you need to embed a bitmap logo into a responsive web page as a vector graphic.
 * 2. When you want to generate SVG icons from legacy BMP assets for high‑resolution displays.
 * 3. When you must create a scalable diagram with a fixed 200 × 200 px viewport for printing.
 * 4. When you are automating batch conversion of BMP screenshots to SVG for size‑optimized storage.
 * 5. When you require a programmatic way to set the SVG viewbox size while converting raster images in a C# application.
 */
