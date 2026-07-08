using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.PathResources;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tif";
            string outputPath = "output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (var tiffImage = (TiffImage)Aspose.Imaging.Image.Load(inputPath))
            {
                var graphicsPath = PathResourceConverter.ToGraphicsPath(
                    tiffImage.ActiveFrame.PathResources.ToArray(),
                    tiffImage.ActiveFrame.Size);

                var svgOptions = new SvgOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                using (var svgImage = Aspose.Imaging.Image.Create(svgOptions, tiffImage.Width, tiffImage.Height))
                {
                    var graphics = new Aspose.Imaging.Graphics(svgImage);
                    graphics.DrawPath(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 1), graphicsPath);
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
 * 1. When a developer needs to convert proprietary TIFF clipping paths from scanned artwork into scalable SVG vectors for web publishing.
 * 2. When a GIS application must extract region outlines stored as TIFF path resources to generate SVG overlays for interactive maps.
 * 3. When an e‑commerce platform wants to transform product label TIFF files with embedded cut lines into SVG cut‑paths for automated laser cutting.
 * 4. When a digital archiving system requires preserving the original vector clipping information of historical TIFF documents by exporting them as SVG for future editing.
 * 5. When a printing workflow needs to validate and visualize TIFF clipping paths by rendering them as SVG graphics in a C# reporting tool.
 */