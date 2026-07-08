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
            // Define output path
            string outputPath = @"c:\temp\output.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up BMP options with a file source
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create a new image canvas
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Build a graphics path with some shapes
                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();
                figure.AddShape(new RectangleShape(new RectangleF(100f, 80f, 200f, 150f)));
                figure.AddShape(new EllipseShape(new RectangleF(150f, 120f, 100f, 80f)));
                path.AddFigure(figure);

                // Retrieve the bounding rectangle of the path
                // Using an identity matrix for transformation
                var bounds = path.GetBounds(new Matrix());

                // Draw the original path
                graphics.DrawPath(new Pen(Color.Black, 2), path);

                // Align a rectangle around the bounds
                graphics.DrawRectangle(
                    new Pen(Color.Red, 2),
                    new Rectangle((int)bounds.X, (int)bounds.Y, (int)bounds.Width, (int)bounds.Height));

                // Save the image (output file already bound to the source)
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
 * 1. When generating a BMP report that overlays a red border around a complex shape composed of rectangles and ellipses, a developer can use GetBounds to determine the exact outer limits for the border.
 * 2. When creating a printable label in C# where a logo defined by a GraphicsPath must be centered within a fixed-size canvas, GetBounds provides the coordinates needed to align the logo precisely.
 * 3. When developing a diagram editor that needs to snap additional annotation boxes to the edges of a drawn path, the bounding rectangle returned by GetBounds lets the program position those boxes automatically.
 * 4. When exporting a composite vector drawing to a raster image and wanting to add a watermark that fits tightly around the drawing, GetBounds helps calculate the area to place the watermark without covering the artwork.
 * 5. When implementing automated UI testing that verifies visual elements by drawing shapes and then checking their extents, GetBounds allows the test to compare the expected bounding box against the actual rendered size.
 */