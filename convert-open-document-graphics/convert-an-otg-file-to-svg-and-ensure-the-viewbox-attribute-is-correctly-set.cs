// HOW-TO: Convert OTG to SVG with Proper ViewBox in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input/sample.otg";
            string outputPath = "Output/sample.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (SvgOptions options = new SvgOptions())
                {
                    options.VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageWidth = image.Width,
                        PageHeight = image.Height,
                        BackgroundColor = Color.White
                    };
                    image.Save(outputPath, options);
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
 * 1. When you need to embed an OTG diagram into a web page and require an SVG with a correctly sized viewBox for responsive scaling.
 * 2. When a design pipeline receives OTG files from legacy CAD tools and must convert them to SVG for further processing in vector graphics editors.
 * 3. When generating printable PDFs from OTG assets, you first convert them to SVG with accurate dimensions to preserve layout before PDF conversion.
 * 4. When building a C# service that transforms user‑uploaded OTG files into web‑friendly SVGs while maintaining the original aspect ratio.
 * 5. When automating batch conversion of OTG icons to SVG sprites, ensuring each SVG includes the proper viewBox for CSS styling.
 */
