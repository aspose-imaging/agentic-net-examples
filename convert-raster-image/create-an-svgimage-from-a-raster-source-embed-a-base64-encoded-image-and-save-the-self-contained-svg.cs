// HOW-TO: Create Self‑Contained SVG from JPEG with Base64 Image in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output.svg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image raster = Image.Load(inputPath))
            {
                SvgOptions svgOptions = new SvgOptions();

                using (Image svg = Image.Create(svgOptions, raster.Width, raster.Height))
                {
                    Graphics graphics = new Graphics(svg);
                    graphics.DrawImage(raster, new Point(0, 0));

                    svg.Save(outputPath);
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
 * 1. When you need to embed a raster photo directly into an SVG for web pages without external image files.
 * 2. When generating scalable graphics from user‑uploaded photos while keeping the SVG file portable.
 * 3. When converting product images to vector containers for responsive design that require a single file.
 * 4. When creating printable SVG assets that must include the original bitmap without linking to separate resources.
 * 5. When automating batch processing to transform a folder of JPEGs into self‑contained SVGs for archival purposes.
 */
