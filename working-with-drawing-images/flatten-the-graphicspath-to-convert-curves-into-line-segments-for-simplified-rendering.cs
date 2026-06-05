using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                Aspose.Imaging.GraphicsPath path = new Aspose.Imaging.GraphicsPath();
                Aspose.Imaging.Figure figure = new Aspose.Imaging.Figure();

                Aspose.Imaging.PointF[] bezierPoints = new Aspose.Imaging.PointF[]
                {
                    new Aspose.Imaging.PointF(50f, 200f),
                    new Aspose.Imaging.PointF(150f, 50f),
                    new Aspose.Imaging.PointF(250f, 350f),
                    new Aspose.Imaging.PointF(350f, 150f)
                };

                figure.AddShape(new BezierShape(bezierPoints, true));
                figure.AddShape(new RectangleShape(new Aspose.Imaging.RectangleF(10f, 10f, 200f, 200f)));

                path.AddFigure(figure);
                path.Flatten();

                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);
                Aspose.Imaging.Pen pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Blue, 2);
                graphics.DrawPath(pen, path);

                PngOptions pngOptions = new PngOptions();
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
 * 1. When generating thumbnail previews of vector‑based drawings stored as PNG files, a developer can flatten the GraphicsPath to turn complex Bezier curves and rectangles into straight line segments for fast rasterization.
 * 2. When exporting CAD or GIS diagrams to a lightweight image format, flattening the path ensures that the resulting PNG can be rendered consistently on devices that do not support curve primitives.
 * 3. When creating a print‑ready raster image from a mixed shape figure, using GraphicsPath.Flatten simplifies the drawing pipeline by converting all curves to polylines before drawing with a Pen.
 * 4. When implementing a server‑side image‑processing service that must overlay custom shapes on user‑uploaded PNGs, flattening the path reduces CPU usage and memory overhead during the DrawPath operation.
 * 5. When developing a game asset pipeline that converts designer‑drawn Bezier paths into pixel‑perfect sprites, flattening the GraphicsPath allows the sprite to be saved as a PNG with only straight‑line segments for reliable collision detection.
 */