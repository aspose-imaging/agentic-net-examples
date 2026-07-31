using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string outputPath = "output\\drawn_path.png";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up PNG options with a file create source
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
                figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 300f, 300f)));
                figure.AddShape(new EllipseShape(new RectangleF(100f, 100f, 200f, 200f)));
                figure.AddShape(new PieShape(new RectangleF(new PointF(150f, 150f), new SizeF(200f, 200f)), 0f, 45f));
                path.AddFigure(figure);

                // Draw the outline of the path with a black pen of width 2
                graphics.DrawPath(new Pen(Color.Black, 2), path);

                // Save the image (output is already bound to the file)
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
 * 1. When a developer needs to generate a PNG thumbnail that highlights the borders of UI components such as buttons, panels, or custom shapes for documentation or design reviews.
 * 2. When creating vector‑based diagrams in a .NET application where the outlines of rectangles, ellipses, and pie slices must be rendered with a consistent 2‑pixel black stroke for printing or reporting.
 * 3. When building an automated testing tool that captures screenshots of rendered graphics and overlays black outlines on specific shapes to verify layout accuracy.
 * 4. When producing marketing assets that require a clean, high‑resolution PNG image with highlighted shape boundaries to illustrate product features in brochures or web pages.
 * 5. When implementing a CAD‑like preview in a C# application that draws the contour of geometric figures using Aspose.Imaging’s Graphics.DrawPath and a black Pen of width two for precise visual feedback.
 */