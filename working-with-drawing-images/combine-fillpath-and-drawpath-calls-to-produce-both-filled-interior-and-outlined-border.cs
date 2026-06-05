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
        string outputPath = @"C:\temp\output.png";

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            var pngOptions = new PngOptions();
            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();
                figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 200f)));
                figure.AddShape(new EllipseShape(new RectangleF(100f, 100f, 200f, 150f)));
                path.AddFigure(figure);

                using (SolidBrush brush = new SolidBrush())
                {
                    brush.Color = Color.LightBlue;
                    brush.Opacity = 100;
                    graphics.FillPath(brush, path);
                }

                Pen outlinePen = new Pen(Color.Red, 2);
                graphics.DrawPath(outlinePen, path);

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
 * 1. When creating a PNG badge that uses a GraphicsPath to define a light‑blue rectangle and ellipse and needs a red Pen outline to match corporate branding.
 * 2. When generating image‑based reports that require filled geometric annotations drawn with a SolidBrush and then outlined with a Pen to improve readability on a white background.
 * 3. When producing dynamic map markers saved as PNG files where the marker shape is filled via FillPath and highlighted with DrawPath to ensure visibility over varying map tiles.
 * 4. When building thumbnail previews for a design tool that display complex shapes using FillPath for interior shading and DrawPath for a crisp border, helping users recognize the shape at a glance.
 * 5. When exporting user‑drawn shapes from a C# application to a PNG image, using FillPath and DrawPath together so the shapes retain their fill color and a sharp outline for high‑resolution printing.
 */