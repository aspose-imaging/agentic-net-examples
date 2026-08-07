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
            // Hardcoded output path
            string outputPath = @"c:\temp\output.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up BMP options with a file source
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create image canvas
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.Wheat);

                // Create a graphics path and figures with shapes
                GraphicsPath graphicspath = new GraphicsPath();

                Figure figure1 = new Figure();
                figure1.AddShape(new EllipseShape(new RectangleF(50, 50, 300, 300)));
                figure1.AddShape(new PieShape(new RectangleF(110, 110, 200, 200), 0, 90));

                Figure figure2 = new Figure();
                figure2.AddShape(new ArcShape(new RectangleF(10, 10, 300, 300), 0, 45));
                figure2.AddShape(new PolygonShape(new[]
                {
                    new PointF(150, 10),
                    new PointF(150, 200),
                    new PointF(250, 300),
                    new PointF(350, 400)
                }, true));
                figure2.AddShape(new RectangleShape(new RectangleF(250, 250, 200, 200)));

                // Add figures to the path
                graphicspath.AddFigure(figure1);
                graphicspath.AddFigure(figure2);

                // Iterate over each figure and log the number of shapes it contains
                int index = 0;
                foreach (Figure fig in graphicspath.Figures)
                {
                    int shapeCount = fig.Shapes.Count();
                    Console.WriteLine($"Figure {index} contains {shapeCount} shape(s).");
                    index++;
                }

                // Draw the path onto the image
                graphics.DrawPath(new Pen(Color.Black, 2), graphicspath);

                // Save the image (output file already bound via FileCreateSource)
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
 * 1. When generating a complex BMP report that combines multiple vector figures, a developer can iterate over each Figure in a GraphicsPath to log how many shapes each figure contains, ensuring the expected composition before saving the image.
 * 2. When validating user‑drawn diagrams in a C# drawing application, counting the shapes per Figure helps detect incomplete figures and provides feedback for corrective actions.
 * 3. When exporting layered graphics to formats like BMP or PNG, logging the shape count per Figure allows developers to audit resource usage and optimize performance for large images.
 * 4. When performing automated unit tests on image‑processing pipelines, iterating through the GraphicsPath figures and recording their shape counts verifies that shape‑creation logic produces the intended number of elements.
 * 5. When integrating Aspose.Imaging with a CAD‑to‑raster conversion tool, tracking the number of shapes in each Figure assists in mapping vector entities to raster layers and troubleshooting mismatches.
 */