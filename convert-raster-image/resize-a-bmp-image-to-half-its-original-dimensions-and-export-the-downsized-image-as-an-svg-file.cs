// HOW-TO: Resize BMP Image to Half Size and Save as SVG in C# (Aspose.Imaging for .NET)
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
            string inputPath = Path.Combine("Input", "sample.bmp");
            string outputPath = Path.Combine("Output", "sample_resized.svg");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                int newWidth = image.Width / 2;
                int newHeight = image.Height / 2;

                image.Resize(newWidth, newHeight);

                using (SvgOptions svgOptions = new SvgOptions())
                {
                    svgOptions.VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = newWidth,
                        PageHeight = newHeight
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
 * 1. When you need to generate a lightweight vector version of a legacy BMP logo for responsive web pages, you can resize it and export it as SVG using C# and Aspose.Imaging.
 * 2. When a desktop application must downscale high‑resolution BMP scans before embedding them into a PDF as scalable graphics, this code provides the resizing and SVG conversion.
 * 3. When an automated build pipeline processes BMP assets and requires half‑size SVG files for mobile UI assets, the snippet automates the transformation in .NET.
 * 4. When converting BMP screenshots into scalable diagrams for documentation, resizing them to half their dimensions reduces file size while preserving quality in the resulting SVG.
 * 5. When a game development tool needs to import BMP textures, shrink them for performance, and store them as SVG for vector‑based rendering, this approach handles the conversion in C#.
 */
