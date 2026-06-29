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
            // Output file path (hard‑coded)
            string outputPath = @"c:\temp\polygon.png";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set PNG options with a file source bound to the output path
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            // Create a 500x500 image canvas
            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Create a graphics path and a figure
                GraphicsPath graphicPath = new GraphicsPath();
                Figure figure = new Figure();

                // Define five vertices for the closed polygon
                PointF[] points = new PointF[]
                {
                    new PointF(100f, 50f),
                    new PointF(200f, 80f),
                    new PointF(250f, 180f),
                    new PointF(150f, 250f),
                    new PointF(80f, 150f)
                };

                // Create a closed polygon shape and add it to the figure
                PolygonShape polygon = new PolygonShape(points, true);
                figure.AddShape(polygon);

                // Add the figure to the graphics path
                graphicPath.AddFigure(figure);

                // Draw the path with a blue pen
                graphics.DrawPath(new Pen(Color.Blue, 2), graphicPath);

                // Save the image (output is already bound to the file source)
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
 * 1. When a developer needs to programmatically generate a PNG image that contains a custom closed polygon for use in diagrams, UI icons, or branding assets.
 * 2. When an application must create a 500×500 canvas and draw a precise five‑vertex shape with Aspose.Imaging’s GraphicsPath and PolygonShape classes for reporting thumbnails or dashboards.
 * 3. When a server‑side C# service has to render a blue‑outlined polygon directly to a file on disk using a FileCreateSource without intermediate memory streams.
 * 4. When a GIS or mapping tool requires drawing geometric shapes with exact coordinates on a white background, leveraging Aspose.Imaging’s drawing API for accurate vector rendering.
 * 5. When an automated test suite needs a deterministic PNG file (white background, blue polygon) to validate image‑processing logic or visual regression results.
 */