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
        string outputPath = "output/output.png";

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            using (Image image = Image.Create(pngOptions, 600, 400))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();

                figure.AddShape(new RectangleShape(new RectangleF(50, 50, 200, 100)));

                figure.AddShape(new BezierShape(new PointF[]
                {
                    new PointF(0, 0),
                    new PointF(200, 133),
                    new PointF(400, 166),
                    new PointF(600, 400)
                }));

                path.AddFigure(figure);

                graphics.DrawPath(new Pen(Color.Red, 2), path);

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
 * 1. When a developer needs to generate a PNG report that visualizes a custom data trend using a red cubic Bezier curve over a rectangle background.
 * 2. When creating dynamic chart graphics in a C# web application where the curve represents a smooth transition between data points and must be drawn on a 600x400 image.
 * 3. When producing a printable flyer in .NET that combines vector shapes like rectangles and Bezier curves, saved as a high‑resolution PNG for downstream design tools.
 * 4. When implementing a signature capture preview that renders the user’s stroke as a cubic Bezier curve on a white canvas using Aspose.Imaging’s GraphicsPath.
 * 5. When automating the generation of UI mockups that require a curved connector line between two rectangular components, rendered as a red BezierShape in a PNG file.
 */