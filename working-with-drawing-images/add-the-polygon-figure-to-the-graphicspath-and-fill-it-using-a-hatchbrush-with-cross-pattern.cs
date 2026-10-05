// HOW-TO: Fill Polygon with Cross Hatch Brush Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            int width = 400;
            int height = 400;

            BmpOptions options = new BmpOptions();
            options.Source = new FileCreateSource(outputPath, false);

            using (Image image = Image.Create(options, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                GraphicsPath path = new GraphicsPath();

                Figure figure = new Figure();
                PointF[] points = new PointF[]
                {
                    new PointF(100, 100),
                    new PointF(300, 100),
                    new PointF(200, 300)
                };
                PolygonShape polygon = new PolygonShape(points);
                figure.AddShape(polygon);
                path.AddFigure(figure);

                using (SolidBrush brush = new SolidBrush(Color.LightBlue))
                {
                    graphics.FillPath(brush, path);
                }

                Pen pen = new Pen(Color.Black);
                graphics.DrawPath(pen, path);

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
 * 1. When you need to programmatically generate a BMP file that contains a custom‑shaped polygon filled with a cross‑hatch pattern for reports or printable graphics.
 * 2. When creating dynamic UI elements such as icons or badges where a triangular shape must be highlighted with a hatch fill to distinguish it from solid colors.
 * 3. When exporting CAD or GIS data to raster images and you want to represent selected areas with a hatch pattern to indicate zoning or selection.
 * 4. When building a server‑side image service that produces watermarked diagrams, using a hatch brush to overlay a semi‑transparent pattern on specific polygonal regions.
 * 5. When automating the production of printable forms that require patterned fills (e.g., cross‑hatch) inside polygons to meet branding guidelines without manual graphic design.
 */
