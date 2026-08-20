// HOW-TO: Export TIFF Frame Clipping Path to SVG for Vector Editing in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.tif";
            string outputPath = "Output/clipPath.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (var tiffImage = (TiffImage)Image.Load(inputPath))
            {
                var graphicsPath = Aspose.Imaging.FileFormats.Tiff.PathResources.PathResourceConverter.ToGraphicsPath(
                    tiffImage.ActiveFrame.PathResources.ToArray(),
                    tiffImage.ActiveFrame.Size);

                var svgOptions = new SvgOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                using (var svgImage = Image.Create(svgOptions, tiffImage.ActiveFrame.Width, tiffImage.ActiveFrame.Height))
                {
                    var graphics = new Graphics(svgImage);
                    graphics.DrawPath(new Pen(Color.Black, 1), graphicsPath);
                    svgImage.Save();
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
 * 1. When you need to edit the vector clipping path of a scanned TIFF image in a design tool like Adobe Illustrator.
 * 2. When you want to extract a TIFF page’s precise cutout shape and reuse it as an SVG mask in a web application.
 * 3. When a printing workflow requires converting embedded TIFF clipping paths to scalable SVG for pre‑press proofing.
 * 4. When automating batch processing to generate SVG outlines from multi‑page TIFF documents for GIS or CAD integration.
 * 5. When you must preserve the exact dimensions of a TIFF frame while providing a vector representation for responsive UI rendering.
 */
