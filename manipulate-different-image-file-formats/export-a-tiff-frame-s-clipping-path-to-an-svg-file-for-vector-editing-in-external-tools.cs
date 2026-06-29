using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.PathResources;
using Aspose.Imaging.FileFormats.Svg;

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

            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                TiffFrame frame = tiffImage.ActiveFrame;

                var graphicsPath = PathResourceConverter.ToGraphicsPath(
                    frame.PathResources.ToArray(),
                    frame.Size);

                var svgOptions = new SvgOptions();

                using (SvgImage svgImage = (SvgImage)Image.Create(svgOptions, frame.Width, frame.Height))
                {
                    var graphics = new Graphics(svgImage);
                    graphics.DrawPath(new Pen(Color.Black, 1), graphicsPath);
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
 * 1. When a developer needs to extract a clipping path from a multi‑page TIFF and convert it to an editable SVG for vector graphic editing in tools like Adobe Illustrator.
 * 2. When a workflow requires converting the vector outline of a scanned document stored in a TIFF frame into an SVG to enable resolution‑independent scaling on the web.
 * 3. When an application must preserve the exact shape of a TIFF’s path resources while exporting them to a format that can be styled with CSS in modern browsers.
 * 4. When a batch‑processing script has to automate the transformation of TIFF clipping paths into SVG files for downstream CAD or GIS processing.
 * 5. When a developer wants to render a TIFF frame’s vector path using Aspose.Imaging’s Graphics class and save the result as an SVG for further manipulation in vector‑based design pipelines.
 */