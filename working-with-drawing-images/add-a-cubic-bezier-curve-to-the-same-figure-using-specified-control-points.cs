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
        string outputPath = @"C:\temp\bezier_output.bmp";
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Set up BMP options with a file source.
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create a new image canvas.
            using (Image image = Image.Create(bmpOptions, 600, 400))
            {
                // Initialize graphics for drawing.
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Create a graphics path and a figure.
                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();

                // Add a rectangle shape (optional visual reference).
                figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 200f)));

                // Define control points for the cubic Bezier curve.
                PointF[] bezierPoints = new PointF[]
                {
                    new PointF(0f, 0f),          // Start point
                    new PointF(200f, 133f),      // First control point
                    new PointF(400f, 166f),      // Second control point
                    new PointF(600f, 400f)       // End point
                };

                // Add the cubic Bezier shape to the figure.
                figure.AddShape(new BezierShape(bezierPoints));

                // Add the figure to the graphics path.
                path.AddFigure(figure);

                // Draw the path using a red pen.
                graphics.DrawPath(new Pen(Color.Red, 2), path);

                // Save the image (output file is already bound via FileCreateSource).
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
 * 1. When a developer needs to programmatically overlay a smooth cubic Bezier signature on a 24‑bit BMP thumbnail for document authentication.
 * 2. When a custom reporting engine must draw precise flow‑chart connectors as red Bezier curves on a 600×400 raster image before exporting to PDF.
 * 3. When an e‑commerce site generates product badge images in BMP format and wants to add a decorative curved ribbon using Aspose.Imaging’s BezierShape.
 * 4. When a GIS tool renders a curved road segment on a raster map by adding a cubic Bezier curve to a Figure within a GraphicsPath.
 * 5. When an automated UI test creates visual regression screenshots that include a red cubic Bezier curve to highlight expected element boundaries.
 */