using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        string inputPath = "input.tif";
        string outputPath = "output.svg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (var tiffImage = (TiffImage)Image.Load(inputPath))
            {
                var pathResources = tiffImage.ActiveFrame.PathResources;
                if (pathResources == null || pathResources.Count == 0)
                {
                    Console.Error.WriteLine("No clipping path found in the TIFF frame.");
                    return;
                }

                var graphicsPath = Aspose.Imaging.FileFormats.Tiff.PathResources.PathResourceConverter.ToGraphicsPath(
                    pathResources.ToArray(),
                    tiffImage.ActiveFrame.Size);

                var svgOptions = new SvgOptions();

                using (var svgImage = Image.Create(svgOptions, tiffImage.Width, tiffImage.Height))
                {
                    var graphics = new Graphics(svgImage);
                    var pen = new Pen(Color.Black, 2);
                    graphics.DrawPath(pen, graphicsPath);
                    svgImage.Save(outputPath, svgOptions);
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
 * 1. When a graphics developer needs to extract a TIFF image’s embedded clipping path and convert it to an SVG file for precise vector editing in tools like Adobe Illustrator or Inkscape.
 * 2. When a printing workflow requires converting TIFF page outlines into scalable SVG vectors to ensure resolution‑independent cut lines for a digital press.
 * 3. When a GIS application must transform raster map boundaries stored as TIFF path resources into SVG polygons for overlaying on web‑based vector maps.
 * 4. When an e‑commerce platform wants to generate editable SVG masks from product photos saved as TIFFs to allow designers to tweak shapes without losing quality.
 * 5. When a document archiving system needs to preserve the original TIFF clipping path as an SVG vector so that future users can edit or reuse the shape in vector‑based design software.
 */