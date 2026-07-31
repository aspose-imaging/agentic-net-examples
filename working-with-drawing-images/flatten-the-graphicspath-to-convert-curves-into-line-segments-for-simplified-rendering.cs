using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Create a GraphicsPath with various shapes, including a Bezier curve
                GraphicsPath path = new GraphicsPath();

                // Rectangle shape
                Figure rectFigure = new Figure();
                rectFigure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 150f)));
                path.AddFigure(rectFigure);

                // Ellipse shape
                Figure ellipseFigure = new Figure();
                ellipseFigure.AddShape(new EllipseShape(new RectangleF(300f, 50f, 150f, 150f)));
                path.AddFigure(ellipseFigure);

                // Bezier curve shape (creates a curve)
                Figure bezierFigure = new Figure();
                PointF[] bezierPoints = new PointF[]
                {
                    new PointF(100f, 300f),
                    new PointF(150f, 250f),
                    new PointF(200f, 350f),
                    new PointF(250f, 300f)
                };
                bezierFigure.AddShape(new BezierShape(bezierPoints, true));
                path.AddFigure(bezierFigure);

                // Flatten the path: convert curves to line segments
                path.Flatten();

                // Draw the flattened path onto the image
                Graphics graphics = new Graphics(image);
                Pen pen = new Pen(Color.Blue, 2);
                graphics.DrawPath(pen, path);

                // Save the modified image as PNG
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
 * 1. When generating vector‑based overlays on PNG images for web maps, a developer can flatten the GraphicsPath to convert Bezier curves into straight line segments that render consistently across browsers.
 * 2. When exporting a complex drawing to a format that does not support curves, such as older BMP files or simple raster printers, flattening the path ensures the shapes are approximated with lines before saving as PNG.
 * 3. When performing hit‑testing or collision detection on shapes drawn on an image, converting curves to line segments simplifies the calculations and improves performance in C# image‑processing pipelines.
 * 4. When creating a low‑resolution thumbnail where curve rendering is costly, flattening the GraphicsPath reduces computational load while preserving the visual outline of rectangles, ellipses, and Bezier curves.
 * 5. When integrating Aspose.Imaging with a CAD‑to‑image workflow that requires only linear segments for downstream CNC machining, flattening the path provides a line‑only representation that can be exported as a PNG mask.
 */