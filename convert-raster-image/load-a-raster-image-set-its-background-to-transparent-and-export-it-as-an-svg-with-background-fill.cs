// HOW-TO: Convert PNG to Transparent SVG with Background Fill in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input\\sample.png";
            string outputPath = "Output\\result.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (Image image = Image.Load(inputPath))
            {
                image.BackgroundColor = Color.Transparent;

                using (SvgOptions svgOptions = new SvgOptions())
                {
                    svgOptions.VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        BackgroundColor = Color.Transparent,
                        PageWidth = image.Width,
                        PageHeight = image.Height
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
 * 1. When you need to embed a PNG logo into a web page as a scalable SVG without any background color.
 * 2. When generating vector graphics from user‑uploaded photos for print layouts while preserving transparency.
 * 3. When creating responsive UI icons that must scale on high‑DPI screens and require a transparent canvas.
 * 4. When converting scanned raster diagrams to SVG for editing in vector tools while keeping the background clear.
 * 5. When automating batch processing of product images to produce transparent SVG assets for e‑commerce catalogs.
 */
