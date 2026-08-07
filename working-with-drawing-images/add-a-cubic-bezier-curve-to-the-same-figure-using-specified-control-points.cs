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
            // Output file path
            string outputPath = @"C:\temp\bezier_output.png";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up PNG options with a bound file source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            // Create a new image
            using (Image image = Image.Create(pngOptions, 600, 400))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Create a graphics path and a figure
                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();

                // Example rectangle shape (optional)
                figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 150f)));

                // Add a cubic Bezier curve to the same figure
                PointF[] bezierPoints = new PointF[]
                {
                    new PointF(0f, 0f),          // Start point
                    new PointF(200f, 133f),      // First control point
                    new PointF(400f, 166f),      // Second control point
                    new PointF(600f, 400f)       // End point
                };
                figure.AddShape(new BezierShape(bezierPoints));

                // Add the figure to the path
                path.AddFigure(figure);

                // Draw the path with a red pen
                graphics.DrawPath(new Pen(Color.Red, 2), path);

                // Save the image (file is already bound to the source)
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
 * 1. When a developer needs to generate a PNG diagram that combines vector shapes such as rectangles and smooth cubic Bezier curves for a web‑ready illustration.
 * 2. When creating dynamic chart annotations in a C# reporting tool, and the annotation line must follow a custom curved path defined by control points.
 * 3. When programmatically producing a signature stamp image where the signature stroke is rendered as a cubic Bezier curve over a white background.
 * 4. When building a CAD‑style preview image that overlays a curved guide line on top of existing geometric shapes and saves the result as a PNG file.
 * 5. When automating the creation of UI mock‑up assets that require a red curved connector between two components, using Aspose.Imaging’s GraphicsPath and BezierShape in .NET.
 */