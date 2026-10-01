// HOW-TO: Convert PNG to SVG with White Background Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\source.png";
        string outputPath = "Output\\result.svg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (RasterImage pngImage = (RasterImage)Image.Load(inputPath))
            {
                int width = pngImage.Width;
                int height = pngImage.Height;

                var fileSource = new FileCreateSource(outputPath, false);
                using (SvgOptions svgOptions = new SvgOptions())
                {
                    svgOptions.Source = fileSource;

                    using (Image svgImage = Image.Create(svgOptions, width, height))
                    {
                        Graphics graphics = new Graphics(svgImage);
                        graphics.Clear(Aspose.Imaging.Color.White);
                        graphics.DrawImage(pngImage, new Aspose.Imaging.Point(0, 0));

                        svgImage.Save();
                    }
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
 * 1. When you need to embed a raster PNG into a scalable SVG for responsive web graphics while ensuring a consistent white canvas.
 * 2. When you want to programmatically generate SVG icons from existing PNG assets in a .NET batch‑processing pipeline.
 * 3. When you must convert user‑uploaded PNG files to SVG format for vector‑based printing or laser cutting, preserving background color.
 * 4. When you are building a C# application that creates SVG placeholders from PNG logos for dynamic PDF or report generation.
 * 5. When you require automated conversion of PNG screenshots to SVG diagrams for documentation tools that only accept vector images.
 */
