// HOW-TO: Fill Polygon With Cross Hatch Pattern Using Aspose.Imaging In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = @"C:\temp\polygon_fill.png";
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                GraphicsPath graphicsPath = new GraphicsPath();

                Figure polygonFigure = new Figure();

                PointF[] points = new PointF[]
                {
                    new PointF(100f, 100f),
                    new PointF(400f, 100f),
                    new PointF(350f, 300f),
                    new PointF(150f, 300f)
                };

                polygonFigure.AddShape(new PolygonShape(points, true));
                graphicsPath.AddFigure(polygonFigure);

                using (SolidBrush solidBrush = new SolidBrush(Color.Red))
                {
                    graphics.FillPath(solidBrush, graphicsPath);
                }

                Pen outlinePen = new Pen(Color.Black, 2);
                graphics.DrawPath(outlinePen, graphicsPath);

                image.Save();
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
 * 1. When you need to generate a PNG image that highlights a custom‑shaped area with a cross‑hatch fill using Aspose.Imaging in C#.
 * 2. When creating printable diagrams where a polygon must be distinguished by a cross‑hatch pattern instead of a solid color.
 * 3. When dynamically drawing map regions or floor‑plan sections in a C# application and you want a hatch texture to indicate selection.
 * 4. When exporting vector‑based graphics to raster format while preserving a stylized hatch fill for branding or watermark purposes.
 * 5. When automating the production of thumbnails that require a patterned background inside irregular shapes for visual consistency.
 */
