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
            string outputPath = "output\\widened_path.png";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up PNG options with a file create source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath);

            // Create a new image canvas
            using (Image image = Image.Create(pngOptions, 200, 200))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Build a graphics path containing a rectangle shape
                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();
                figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 100f, 100f)));
                path.AddFigure(figure);

                // Draw the original path with a thin black pen
                Pen thinPen = new Pen(Color.Black, 1);
                graphics.DrawPath(thinPen, path);

                // Widen the path by 3 pixels using a thick red pen (hit testing)
                Pen thickPen = new Pen(Color.Red, 3);
                path.Widen(thickPen);

                // Draw the widened path with a blue pen to visualize the result
                Pen widenedPen = new Pen(Color.Blue, 1);
                graphics.DrawPath(widenedPen, path);

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
 * 1. When a developer needs to create a PNG thumbnail with a selectable rectangle that can be hit‑tested accurately, they can widen the path by three pixels using a thick Pen before rendering.
 * 2. When building a custom UI control in C# that requires visual feedback for mouse hover over a shape, the Widen method expands the hit‑test region without changing the displayed outline.
 * 3. When generating printable diagrams where the clickable area must be larger than the visible line, widening the GraphicsPath with a red Pen ensures reliable click detection while keeping the original thin black border.
 * 4. When implementing a map editor that stores vector shapes in PNG files, using path.Widen with a thick Pen lets the engine detect user selections even if the shape’s stroke is only 1 pixel wide.
 * 5. When creating an image processing pipeline that overlays annotations on a 200×200 canvas and needs precise hit testing for automated QA, widening the path by three pixels provides a robust detection zone for the rectangle.
 */