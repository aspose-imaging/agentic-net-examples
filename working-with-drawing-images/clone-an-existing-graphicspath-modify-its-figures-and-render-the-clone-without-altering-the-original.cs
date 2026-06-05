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
            string outputPath = "output\\result.png";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set PNG options with a file create source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            // Create a blank image canvas
            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Build the original GraphicsPath
                GraphicsPath originalPath = new GraphicsPath();
                Figure originalFigure = new Figure();
                originalFigure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 200f)));
                originalFigure.AddShape(new EllipseShape(new RectangleF(100f, 100f, 200f, 200f)));
                originalPath.AddFigure(originalFigure);

                // Clone the original path
                GraphicsPath clonedPath = originalPath.DeepClone();

                // Modify the cloned path by adding a new figure
                Figure newFigure = new Figure();
                newFigure.AddShape(new PolygonShape(
                    new[] { new PointF(300f, 300f), new PointF(350f, 350f), new PointF(300f, 400f) },
                    true));
                clonedPath.AddFigure(newFigure);

                // Draw the original path with a black pen
                graphics.DrawPath(new Pen(Color.Black, 2), originalPath);

                // Draw the cloned (modified) path with a red pen
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
 * 1. When a developer needs to add a temporary watermark or annotation to a PNG image while keeping the original vector shapes intact for later reuse, they can deep‑clone the GraphicsPath, add the new figure, and render the clone in a different color.
 * 2. When creating a multi‑layer diagram where the base rectangle and ellipse must remain unchanged for export to other formats, cloning the GraphicsPath lets the developer append additional polygons and draw the modified path separately.
 * 3. When implementing a side‑by‑side preview that shows an edited version of a shape collection next to the original in a Windows Forms application, the code can clone the original path, modify the clone, and render both on a 500×500 canvas.
 * 4. When generating test images for unit testing image‑processing algorithms, a tester can clone the original GraphicsPath, add extra figures to the clone, and compare the rendering of the original black path versus the modified red path.
 * 5. When building a CAD‑like tool that requires an immutable master geometry while allowing temporary user annotations, deep‑cloning the GraphicsPath enables the addition of new figures to the clone without altering the master shape data.
 */