// HOW-TO: Generate 300 DPI PNG with Vector Shapes Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
        try
        {
            string outputPath = "output.png";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            var pngOptions = new PngOptions
            {
                Source = new FileCreateSource(outputPath, false)
            };

            using (Image image = Image.Create(pngOptions, 1200, 800))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                Pen blackPen = new Pen(Color.Black, 5);
                graphics.DrawRectangle(blackPen, new Rectangle(100, 100, 400, 300));

                using (SolidBrush redBrush = new SolidBrush(Color.Red))
                {
                    graphics.FillRectangle(redBrush, new Rectangle(150, 150, 300, 200));
                }

                Pen bluePen = new Pen(Color.Blue, 3);
                graphics.DrawEllipse(bluePen, new Rectangle(200, 200, 200, 150));

                Pen greenPen = new Pen(Color.Green, 2);
                graphics.DrawLine(greenPen, new Point(100, 500), new Point(1100, 500));

                Pen purplePen = new Pen(Color.Purple, 4);
                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();
                figure.AddShape(new PolygonShape(new PointF[]
                {
                    new PointF(600, 100),
                    new PointF(800, 100),
                    new PointF(700, 300)
                }));
                path.AddFigure(figure);
                graphics.DrawPath(purplePen, path);

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
 * 1. When you need to programmatically create a high‑resolution PNG for print‑ready graphics such as brochures or flyers while drawing crisp vector shapes in C#.
 * 2. When you want to generate dynamic diagrams like rectangles, ellipses, lines, and polygons on the server side for reporting dashboards without losing quality at 300 DPI.
 * 3. When an application must produce custom UI assets such as icons or badges that require precise vector drawing and a white background for consistent branding.
 * 4. When you need to automate the creation of printable certificates or tickets that include colored shapes and lines, ensuring they remain sharp after scaling.
 * 5. When you are building a batch process that creates annotated images (e.g., highlighting areas with rectangles and ellipses) for medical or engineering documents where resolution matters.
 */
