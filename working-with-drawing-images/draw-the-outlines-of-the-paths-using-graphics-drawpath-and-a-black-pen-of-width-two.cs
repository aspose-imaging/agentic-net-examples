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
            // Define output path and ensure its directory exists
            string outputPath = "output/output.png";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up PNG options with a bound file source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            // Create a 500x500 image canvas
            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Build a graphics path with several shapes
                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();

                // Rectangle shape
                figure.AddShape(new RectangleShape(new RectangleF(10f, 10f, 300f, 300f)));
                // Ellipse shape
                figure.AddShape(new EllipseShape(new RectangleF(50f, 50f, 300f, 300f)));
                // Pie shape
                figure.AddShape(new PieShape(
                    new RectangleF(new PointF(250f, 250f), new SizeF(200f, 200f)),
                    0f, 45f));

                // Add the figure to the path
                path.AddFigure(figure);

                // Draw the path outline with a black pen of width 2
                graphics.DrawPath(new Pen(Color.Black, 2), path);

                // Save the image (output file is already bound via FileCreateSource)
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
 * 1. When a developer needs to generate a PNG thumbnail that highlights the outlines of multiple vector shapes (rectangle, ellipse, pie) for a reporting dashboard.
 * 2. When an application must programmatically create a white 500×500 canvas and draw black 2‑pixel stroke paths to illustrate geometric diagrams in a CAD preview.
 * 3. When a web service needs to export user‑drawn shapes as a PNG image with crisp black outlines for printing invoices or certificates.
 * 4. When a testing tool requires a deterministic image file to verify that Graphics.DrawPath with a Pen renders consistent path outlines across .NET environments.
 * 5. When a documentation generator wants to embed a sample PNG showing the combined outlines of basic shapes to illustrate Aspose.Imaging’s drawing API.
 */