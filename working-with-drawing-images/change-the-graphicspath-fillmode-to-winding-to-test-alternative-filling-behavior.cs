// HOW-TO: Create PNG with Overlapping Shapes Using Winding Fill Mode in C# (Aspose.Imaging for .NET)
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
        try
        {
            string outputPath = "output.png";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            int width = 400;
            int height = 300;
            PngOptions pngOptions = new PngOptions();

            using (Image image = Image.Create(pngOptions, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                GraphicsPath path = new GraphicsPath();
                path.FillMode = FillMode.Winding;

                Figure figure = new Figure();

                RectangleF rect = new RectangleF(50, 50, 200, 150);
                RectangleShape rectShape = new RectangleShape(rect);
                figure.AddShape(rectShape);

                RectangleF ellipseRect = new RectangleF(150, 100, 200, 150);
                EllipseShape ellipseShape = new EllipseShape(ellipseRect);
                figure.AddShape(ellipseShape);

                path.AddFigure(figure);

                using (SolidBrush brush = new SolidBrush(Color.LightBlue))
                {
                    graphics.FillPath(brush, path);
                }

                Pen pen = new Pen(Color.Blue, 2);
                graphics.DrawPath(pen, path);

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
 * 1. When you need to generate a PNG thumbnail that shows how overlapping rectangles and ellipses combine using the winding fill rule.
 * 2. When you want to programmatically create vector‑based graphics with complex fill behavior for reports or dashboards in a .NET application.
 * 3. When you are testing different fill modes to ensure correct rendering of intersecting shapes in a printing or PDF conversion workflow.
 * 4. When you need to produce a light‑blue filled illustration with a blue outline for UI icons without using external design tools.
 * 5. When you are automating image generation for marketing assets and must control how overlapping shapes are filled to achieve a specific visual effect.
 */
