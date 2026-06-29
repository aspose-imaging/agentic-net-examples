using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Create a figure and add shapes (including a curve)
                Figure figure = new Figure();
                figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 200f)));
                figure.AddShape(new EllipseShape(new RectangleF(100f, 100f, 200f, 150f)));

                // Bezier curve points
                PointF[] bezierPoints = new PointF[]
                {
                    new PointF(150f, 150f),
                    new PointF(200f, 50f),
                    new PointF(250f, 250f),
                    new PointF(300f, 150f)
                };
                figure.AddShape(new BezierShape(bezierPoints, true));

                // Build the graphics path
                GraphicsPath path = new GraphicsPath();
                path.AddFigure(figure);

                // Flatten curves into line segments
                path.Flatten();

                // Draw the flattened path onto the image
                Graphics graphics = new Graphics(image);
                graphics.DrawPath(new Pen(Color.Blue, 2), path);

                // Save the modified image as PNG
                image.Save(outputPath, new PngOptions());
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
 * 1. When generating thumbnail previews of vector graphics for web pages, a developer can flatten the Bezier curves in a GraphicsPath and render them as straight line segments onto a PNG image to ensure fast, consistent display across browsers.
 * 2. When exporting CAD drawings to raster formats for printing, flattening the curves in the GraphicsPath allows the Aspose.Imaging library to convert complex shapes into simple line segments, reducing processing time and avoiding rendering artifacts in the output PNG.
 * 3. When creating simplified collision masks for game sprites, a developer can flatten the curve‑based shapes in a GraphicsPath and draw the resulting polygon onto a PNG file that the physics engine can efficiently analyze.
 * 4. When preparing images for laser engraving where only straight lines are supported, flattening the BezierShape in the GraphicsPath and saving the result as a high‑resolution PNG ensures the device receives a compatible vector‑to‑raster conversion.
 * 5. When performing batch image annotation that adds geometric overlays to existing PNG files, flattening the path guarantees that the drawn rectangles, ellipses, and curves are rendered as uniform line segments, making the annotations predictable across different display devices.
 */