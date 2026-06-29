using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main()
    {
        // Hardcoded output path
        string outputPath = @"C:\temp\GraphicsPathCloneOutput.bmp";

        try
        {
            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a new BMP image
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                Source = new FileCreateSource(outputPath, false)
            };

            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics surface
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.Wheat);

                // Build the original GraphicsPath
                GraphicsPath originalPath = new GraphicsPath();

                // Figure 1: a rectangle
                Figure rectFigure = new Figure();
                rectFigure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 200f)));
                originalPath.AddFigure(rectFigure);

                // Draw the original path in black
                graphics.DrawPath(new Pen(Color.Black, 2), originalPath);

                // Deep clone the original path
                GraphicsPath clonedPath = originalPath.DeepClone();

                // Modify the clone by adding an ellipse figure
                Figure ellipseFigure = new Figure();
                ellipseFigure.AddShape(new EllipseShape(new RectangleF(150f, 150f, 200f, 200f)));
                clonedPath.AddFigure(ellipseFigure);

                // Draw the cloned (modified) path in red
                graphics.DrawPath(new Pen(Color.Red, 2), clonedPath);

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
 * 1. When generating a printable BMP report that needs a fixed rectangle base shape while dynamically adding extra figures such as ellipses without altering the original GraphicsPath.
 * 2. When creating UI thumbnails where the original vector outline is cloned and modified for different theme colors, preserving the source path for reuse across multiple images.
 * 3. When building a CAD‑style application that must keep the original blueprint path intact while allowing users to experiment with additional geometry on a cloned GraphicsPath.
 * 4. When producing layered game assets where the background shape remains static and a deep‑cloned path is drawn in a different color to visualize hit‑boxes or effects.
 * 5. When automating batch image processing that appends watermarks or signatures to existing vector paths on a BMP canvas, ensuring the original path data stays unchanged.
 */