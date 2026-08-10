// HOW-TO: Widen a GraphicsPath by 3 Pixels for Hit Testing in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = "output.png";

        try
        {
            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create PNG options with a file create source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            // Create a new image canvas
            using (Image image = Image.Create(pngOptions, 400, 300))
            {
                // Initialize graphics
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Original path (rectangle)
                GraphicsPath originalPath = new GraphicsPath();
                Figure originalFigure = new Figure();
                originalFigure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 150f)));
                originalPath.AddFigure(originalFigure);

                // Draw original path with a thin black pen
                Pen thinPen = new Pen(Color.Black, 1);
                graphics.DrawPath(thinPen, originalPath);

                // Widened path for hit testing
                GraphicsPath widenedPath = new GraphicsPath();
                Figure widenedFigure = new Figure();
                widenedFigure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 150f)));
                widenedPath.AddFigure(widenedFigure);

                // Pen that defines the widening width (3 pixels)
                Pen thickPen = new Pen(Color.Red, 3);
                widenedPath.Widen(thickPen);

                // Draw the widened path with a blue pen to visualize the expanded area
                Pen visualPen = new Pen(Color.Blue, 1);
                graphics.DrawPath(visualPen, widenedPath);

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
 * 1. When you need to detect mouse clicks on a rectangle with a tolerance of a few pixels, you can widen the GraphicsPath using a thick Pen for accurate hit testing.
 * 2. When creating a selectable UI overlay on a PNG image, widening the path ensures the selection area is larger than the visible border, improving user interaction.
 * 3. When generating printable graphics where the clickable region must extend beyond the visual shape, using Widen with a 3‑pixel pen creates a buffer zone for the hit test.
 * 4. When implementing custom shape editing tools in a C# application, widening the path helps to capture drag events even if the user clicks slightly outside the original shape.
 * 5. When building a diagram editor that saves to PNG, widening the path before hit testing allows you to highlight the expanded area with a different color for debugging.
 */
