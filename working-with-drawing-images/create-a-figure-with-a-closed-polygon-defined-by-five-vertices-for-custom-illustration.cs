// HOW-TO: Create a Filled Five‑Vertex Polygon in PNG with C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.png";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            int width = 500;
            int height = 500;
            PngOptions options = new PngOptions();

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(options, width, height))
            {
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                // Define five vertices for the polygon
                Aspose.Imaging.PointF[] points = new Aspose.Imaging.PointF[]
                {
                    new Aspose.Imaging.PointF(100, 100),
                    new Aspose.Imaging.PointF(200, 50),
                    new Aspose.Imaging.PointF(300, 100),
                    new Aspose.Imaging.PointF(250, 200),
                    new Aspose.Imaging.PointF(150, 200)
                };

                // Create a polygon shape and add it to a figure
                PolygonShape polygon = new PolygonShape(points);
                Aspose.Imaging.Figure figure = new Aspose.Imaging.Figure();
                figure.AddShape(polygon);

                // Create a GraphicsPath and add the figure
                Aspose.Imaging.GraphicsPath path = new Aspose.Imaging.GraphicsPath();
                path.AddFigure(figure);

                // Fill the polygon
                using (SolidBrush brush = new SolidBrush(Aspose.Imaging.Color.Blue))
                {
                    graphics.FillPath(brush, path);
                }

                // Draw the polygon outline
                Aspose.Imaging.Pen pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 2);
                graphics.DrawPath(pen, path);

                image.Save(outputPath, options);
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
 * 1. When you need to generate a custom PNG badge that contains a colored pentagon shape for a web dashboard.
 * 2. When you want to programmatically create a filled polygon overlay on a map image in a C# reporting tool.
 * 3. When you are building a diagram generator that draws complex shapes, such as a five‑pointed figure, and saves them as high‑quality PNG files.
 * 4. When you need to add a stylized polygon watermark to product images during an automated image‑processing pipeline.
 * 5. When you are creating instructional graphics that require a blue filled polygon with a black outline for documentation or e‑learning content.
 */
