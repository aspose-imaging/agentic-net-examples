// HOW-TO: Convert SVG to 8‑Bit PNG with Custom Palette in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\image.svg";
            string outputPath = "Output\\image.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                SvgImage svgImage = (SvgImage)image;

                PngOptions pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageWidth = svgImage.Width,
                        PageHeight = svgImage.Height,
                        BackgroundColor = Color.White
                    }
                };

                image.Save(outputPath, pngOptions);
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
 * 1. When you need to generate a low‑size PNG thumbnail from an SVG while preserving a specific brand color scheme.
 * 2. When an application must convert vector icons to 8‑bit PNGs for use in legacy systems that only support indexed colors.
 * 3. When you want to replace the default colors of an SVG with a predefined palette before embedding the image in a PDF report.
 * 4. When automating batch processing of SVG assets to produce web‑ready PNGs with a limited color palette for faster page loads.
 * 5. When creating game sprites from SVG artwork and need the output PNG to use an indexed palette for memory‑efficient rendering.
 */
