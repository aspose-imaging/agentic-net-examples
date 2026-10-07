// HOW-TO: Flatten Bezier Curve to Lines and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                Graphics graphics = new Graphics(image);
                Pen pen = new Pen(Aspose.Imaging.Color.Black, 2);

                Figure figure = new Figure();

                PointF p0 = new PointF(50, 150);
                PointF p1 = new PointF(150, 50);
                PointF p2 = new PointF(250, 250);
                PointF p3 = new PointF(350, 150);

                BezierShape bezier = new BezierShape(new PointF[] { p0, p1, p2, p3 });
                figure.AddShape(bezier);

                GraphicsPath path = new GraphicsPath();
                path.AddFigure(figure);
                path.Flatten();

                graphics.DrawPath(pen, path);

                PngOptions options = new PngOptions();
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
 * 1. When you need to render complex vector shapes as simple straight‑line outlines for faster rasterization in a C# PNG export.
 * 2. When converting SVG‑like Bezier paths to pixel‑perfect line art for printing or low‑resolution displays using Aspose.Imaging.
 * 3. When generating thumbnail previews of vector graphics where curve approximation reduces processing time.
 * 4. When preparing image data for collision detection or hit‑testing by simplifying curves into line segments.
 * 5. When creating custom diagram or chart elements that must be saved as PNG files without preserving curve data.
 */
