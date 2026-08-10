// HOW-TO: How To Fill And Outline Shapes With Aspose.Imaging In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define output file path
            string outputPath = "output.png";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create PNG options with a file source bound to the output path
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            // Create a new image canvas (500x500)
            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Clear background to white
                graphics.Clear(Color.White);

                // Build a graphics path with a rectangle and an ellipse
                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();

                // Add a rectangle shape
                figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 200f)));
                // Add an ellipse shape
                figure.AddShape(new EllipseShape(new RectangleF(100f, 100f, 200f, 200f)));

                // Attach the figure to the path
                path.AddFigure(figure);

                // Fill the interior of the path with yellow
                using (SolidBrush fillBrush = new SolidBrush(Color.Yellow))
                {
                    graphics.FillPath(fillBrush, path);
                }

                // Draw the outline of the path with a black pen (2px width)
                graphics.DrawPath(new Pen(Color.Black, 2), path);
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
 * 1. When you need to generate a PNG badge that shows a colored rectangle with a highlighted border for a web dashboard.
 * 2. When creating printable certificates that require filled shapes with precise outlines using C# and Aspose.Imaging.
 * 3. When building a custom chart where overlapping shapes must be both filled and stroked to improve visual clarity.
 * 4. When developing a game UI element that displays a semi‑transparent background shape with a crisp black edge.
 * 5. When automating the production of marketing thumbnails that combine filled ellipses and rectangles with defined outlines.
 */
