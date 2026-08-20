// HOW-TO: Flatten GraphicsPath To Convert Curves To Lines In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.png";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();

                figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 300f, 300f)));
                figure.AddShape(new EllipseShape(new RectangleF(100f, 100f, 200f, 200f)));

                path.AddFigure(figure);
                path.Flatten();

                graphics.DrawPath(new Pen(Color.Black, 2), path);

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
 * 1. When you need to rasterize complex vector drawings with curves into a PNG while ensuring the rendering engine only processes straight line segments.
 * 2. When generating thumbnails of SVG‑like shapes in C# and want to flatten Bézier curves to improve performance on low‑power devices.
 * 3. When exporting a mixed rectangle and ellipse diagram to a bitmap and require the path to be simplified for compatibility with printers that do not support curve primitives.
 * 4. When creating a custom chart or diagram where the drawing logic must convert all curve data into linear segments before applying a uniform stroke width.
 * 5. When preprocessing vector graphics for a game engine that only accepts flattened paths, allowing you to save the result as a PNG image.
 */
