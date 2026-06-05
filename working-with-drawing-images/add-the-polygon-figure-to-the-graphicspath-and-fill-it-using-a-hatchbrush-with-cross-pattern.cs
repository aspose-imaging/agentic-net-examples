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
            // Hardcoded output path
            string outputPath = @"C:\Temp\polygon.png";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up PNG options with file create source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            // Create image canvas
            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                // Initialize graphics
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Create graphics path
                GraphicsPath graphicsPath = new GraphicsPath();

                // Create figure and add a polygon shape
                Figure figure = new Figure();
                PointF[] points = new PointF[]
                {
                    new PointF(100f, 100f),
                    new PointF(400f, 100f),
                    new PointF(350f, 300f),
                    new PointF(150f, 300f)
                };
                figure.AddShape(new PolygonShape(points, true)); // closed polygon

                // Add figure to path
                graphicsPath.AddFigure(figure);

                // Fill the polygon with a solid brush
                using (SolidBrush solidBrush = new SolidBrush(Color.Blue))
                {
                    graphics.FillPath(solidBrush, graphicsPath);
                }

                // Optional: draw outline
                graphics.DrawPath(new Pen(Color.Black, 2), graphicsPath);

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
 * 1. When creating a PNG badge that highlights a region with a cross‑hatched polygon overlay for a web dashboard using Aspose.Imaging’s GraphicsPath and HatchBrush in C#.
 * 2. When generating printable floor‑plan diagrams where rooms are represented as polygons filled with a cross pattern to indicate restricted areas, leveraging Aspose.Imaging for .NET image processing.
 * 3. When building a data‑visualization tool that shades irregular chart areas with a cross hatch fill to improve contrast on a white background, using C# GraphicsPath and HatchBrush.
 * 4. When automating the production of custom map markers that require a polygon shape filled with a cross‑hatch texture for better visibility in GIS applications via Aspose.Imaging.
 * 5. When designing a UI mockup that needs a scalable PNG icon with a polygon silhouette filled with a cross pattern to demonstrate branding guidelines, implemented with Aspose.Imaging’s Figure, GraphicsPath, and HatchBrush.
 */