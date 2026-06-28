using System;
using System.IO;
using System.Linq;
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
            // Hardcoded input path
            string inputPath = @"c:\temp\input.bmp";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Hardcoded output path
            string outputPath = @"c:\temp\output.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create BMP image
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.Wheat);

                // Create graphics path and figures
                GraphicsPath graphicspath = new GraphicsPath();

                Figure figure1 = new Figure();
                figure1.AddShape(new RectangleShape(new RectangleF(10f, 10f, 300f, 300f)));
                figure1.AddShape(new EllipseShape(new RectangleF(50f, 50f, 300f, 300f)));
                graphicspath.AddFigure(figure1);

                Figure figure2 = new Figure();
                figure2.AddShape(new PolygonShape(new[]
                {
                    new PointF(150f, 10f),
                    new PointF(150f, 200f),
                    new PointF(250f, 300f),
                    new PointF(350f, 400f)
                }, true));
                graphicspath.AddFigure(figure2);

                // Draw the path
                graphics.DrawPath(new Pen(Color.Black, 2), graphicspath);

                // Iterate over figures and log shape counts
                foreach (var fig in graphicspath.Figures)
                {
                    int shapeCount = fig.Shapes.Count();
                    Console.WriteLine($"Figure has {shapeCount} shape(s).");
                }

                // Save the image
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
 * 1. When generating a composite BMP report that combines multiple vector shapes, a developer can iterate over each Figure in a GraphicsPath to log how many shapes (rectangles, ellipses, polygons) are present for auditing the diagram complexity.
 * 2. When validating that a dynamically created graphics path for a CAD‑like drawing contains the expected number of elements before rendering to a 500×500 bitmap, a developer can count the shapes per Figure to catch missing or extra geometry.
 * 3. When exporting a layered illustration to BMP and needing to produce a diagnostic log for quality‑control pipelines, iterating through each Figure lets the developer record the shape count for each layer.
 * 4. When implementing a custom thumbnail generator that skips overly complex figures, a developer can traverse the GraphicsPath and log shape counts to decide whether to simplify the path before drawing.
 * 5. When building a server‑side image‑processing service that tracks resource usage, iterating over Figures and logging their shape totals helps monitor memory impact of complex vector paths in Aspose.Imaging for .NET.
 */