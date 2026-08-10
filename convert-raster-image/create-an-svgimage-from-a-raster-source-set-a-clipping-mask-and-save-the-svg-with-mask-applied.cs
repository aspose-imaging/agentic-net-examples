// HOW-TO: Create SVG from JPEG with Elliptical Clipping Mask in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.Shapes;

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
            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                int width = raster.Width;
                int height = raster.Height;

                using (SvgImage svg = new SvgImage(width, height))
                {
                    // Create clipping mask (ellipse covering the whole image)
                    GraphicsPath clipPath = new GraphicsPath();
                    Figure figure = new Figure();
                    figure.AddShape(new EllipseShape(new RectangleF(0, 0, width, height)));
                    clipPath.AddFigure(figure);

                    Region clipRegion = new Region(clipPath);

                    // Draw raster onto SVG with clipping mask
                    Graphics graphics = new Graphics(svg);
                    graphics.Clip = clipRegion;
                    graphics.DrawImage(raster, new Point(0, 0));

                    // Save the SVG with mask applied
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
 * 1. When you need to embed a photo in a web page as a scalable SVG while displaying only an elliptical portion of the original JPEG.
 * 2. When you want to generate vector graphics that contain raster content cropped to a circular shape for print or marketing materials using C#.
 * 3. When building a .NET service that converts user‑uploaded images to SVG thumbnails with a consistent elliptical mask for branding purposes.
 * 4. When creating SVG badges or icons that show a raster logo inside a rounded mask to maintain visual consistency across devices.
 * 5. When preparing responsive design assets and require a raster‑to‑SVG conversion that applies a custom clipping path to preserve quality in Aspose.Imaging for .NET.
 */
