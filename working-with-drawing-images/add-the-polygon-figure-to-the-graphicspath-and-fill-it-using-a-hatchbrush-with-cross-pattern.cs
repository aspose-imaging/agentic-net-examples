using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = @"C:\Temp\polygon.png";

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int width = 500;
            int height = 500;

            PngOptions pngOptions = new PngOptions();
            using (Image image = Image.Create(pngOptions, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                PointF[] points = new PointF[]
                {
                    new PointF(100, 100),
                    new PointF(400, 100),
                    new PointF(350, 300),
                    new PointF(150, 300)
                };

                PolygonShape polygon = new PolygonShape(points, true);

                Figure figure = new Figure();
                figure.AddShape(polygon);

                GraphicsPath path = new GraphicsPath();
                path.AddFigure(figure);

                using (SolidBrush solidBrush = new SolidBrush(Color.Blue))
                {
                    graphics.FillPath(solidBrush, path);
                }

                image.Save(outputPath, pngOptions);
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
 * 1. When generating printable floor‑plan diagrams that require rooms drawn as polygons and filled with a cross‑hatch pattern to indicate restricted areas, a developer can use Aspose.Imaging to create a PNG via a GraphicsPath and HatchBrush.
 * 2. When building a GIS web application that overlays selected map regions with a cross‑pattern fill for visual emphasis, the polygon can be added to a GraphicsPath and filled using a HatchBrush in C#.
 * 3. When designing custom certification badges that include a polygonal shield shape filled with a cross hatch to meet branding guidelines, the code enables rendering the shape directly to a PNG file with Aspose.Imaging.
 * 4. When creating scientific data visualizations that shade irregular plot areas with a cross hatch to differentiate data sets, a developer can define the area as a PolygonShape, add it to a GraphicsPath, and apply a HatchBrush.
 * 5. When automating the generation of printable QR‑code frames where the frame is a polygon filled with a cross pattern for visual contrast, the Aspose.Imaging API allows drawing and filling the shape programmatically.
 */