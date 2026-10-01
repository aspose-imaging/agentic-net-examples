// HOW-TO: Convert PNG to SVG with Matching ViewBox in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\image.png";
            string outputPath = "Output\\image.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (SvgOptions svgOptions = new SvgOptions())
                {
                    svgOptions.VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageWidth = image.Width,
                        PageHeight = image.Height,
                        BackgroundColor = Color.White
                    };
                    image.Save(outputPath, svgOptions);
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
 * 1. When you need to embed a raster PNG into a web page as a scalable SVG while preserving its original size.
 * 2. When generating vector graphics from user‑uploaded PNGs for responsive design in a C# web application.
 * 3. When converting product images to SVG format for printing or laser cutting where exact dimensions are required.
 * 4. When creating an automated pipeline that transforms PNG assets into SVG files for use in mobile apps with resolution‑independent graphics.
 * 5. When preparing icons for UI libraries that require SVG files with a viewbox that matches the original PNG dimensions.
 */
