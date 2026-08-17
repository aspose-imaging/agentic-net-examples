// HOW-TO: Create a PNG with a Closed Five‑Point Polygon in C# (Aspose.Imaging for .NET)
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
            string outputPath = @"C:\temp\polygon.png";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up PNG options with file source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            // Create a new image canvas
            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Create a graphics path
                GraphicsPath graphicsPath = new GraphicsPath();

                // Create a figure
                Figure figure = new Figure();

                // Define five vertices for the closed polygon
                PointF[] points = new PointF[]
                {
                    new PointF(100f, 100f),
                    new PointF(200f, 80f),
                    new PointF(300f, 150f),
                    new PointF(250f, 250f),
                    new PointF(150f, 200f)
                };

                // Add the polygon shape (closed)
                figure.AddShape(new PolygonShape(points, true));

                // Add the figure to the graphics path
                graphicsPath.AddFigure(figure);

                // Draw the path with a black pen
                graphics.DrawPath(new Pen(Color.Black, 2), graphicsPath);

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
 * 1. When you need to generate a custom diagram or badge with a specific five‑vertex shape and save it directly as a PNG file in a .NET application.
 * 2. When you want to programmatically draw closed polygons for map overlays or UI icons without using external design tools.
 * 3. When an automated report requires dynamically created vector‑based graphics, such as a stylized logo or watermark, that must be rendered as a raster PNG.
 * 4. When you are building a game or simulation that needs to render simple polygonal sprites on the fly using Aspose.Imaging.
 * 5. When you have to export user‑drawn shapes from a web form to a server‑side image for printing or archival purposes.
 */
