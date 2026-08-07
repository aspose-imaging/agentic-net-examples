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
        // Hardcoded output path
        string outputPath = @"C:\temp\GraphicsPathBounds.png";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Set up PNG options with a bound file source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            // Create a new image canvas
            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Create a graphics path with a rectangle shape
                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();
                figure.AddShape(new RectangleShape(new RectangleF(100f, 80f, 250f, 150f)));
                path.AddFigure(figure);

                // Retrieve the bounding rectangle of the path
                RectangleF boundsF = path.GetBounds(new Matrix());

                // Convert to integer rectangle for drawing
                Rectangle boundsRect = new Rectangle(
                    (int)boundsF.X,
                    (int)boundsF.Y,
                    (int)boundsF.Width,
                    (int)boundsF.Height);

                // Draw the original path
                graphics.DrawPath(new Pen(Color.Black, 2), path);

                // Draw a red rectangle around the bounds
                graphics.DrawRectangle(new Pen(Color.Red, 2), boundsRect);

                // Save the image (output path already bound)
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
 * 1. When a developer wants to automatically draw a red border around any custom GraphicsPath (such as a rectangle, ellipse, or complex shape) to highlight its extents before saving the image as a PNG.
 * 2. When generating dynamic reports where chart elements or annotations must be positioned relative to the exact bounds of a drawn shape using Aspose.Imaging’s GetBounds method.
 * 3. When creating a thumbnail generator that needs to crop or pad an image based on the bounding rectangle of vector graphics drawn on a 500×500 canvas.
 * 4. When implementing collision detection or layout validation in a C# graphics editor by retrieving the path’s bounding rectangle and comparing it with other objects.
 * 5. When adding interactive hotspots or tooltips to a raster image by calculating the precise rectangle of a shape and then drawing a visible marker around it.
 */