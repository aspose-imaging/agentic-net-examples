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
        string outputPath = @"c:\temp\polygon.bmp";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Set up BMP options with a file source
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create a new image canvas
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.Wheat);

                // Create a graphics path and a figure
                GraphicsPath graphicspath = new GraphicsPath();
                Figure figure = new Figure();

                // Define five vertices for the closed polygon
                PointF[] points = new PointF[]
                {
                    new PointF(100f, 50f),
                    new PointF(200f, 80f),
                    new PointF(250f, 200f),
                    new PointF(150f, 250f),
                    new PointF(80f, 150f)
                };

                // Create a closed polygon shape and add it to the figure
                PolygonShape polygon = new PolygonShape(points, true);
                figure.AddShape(polygon);

                // Add the figure to the graphics path
                graphicspath.AddFigure(figure);

                // Draw the path with a black pen
                graphics.DrawPath(new Pen(Color.Black, 2), graphicspath);

                // Save the image (output file is already bound to the source)
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
 * 1. When a developer needs to generate a custom BMP badge or logo with a five‑point PolygonShape drawn via GraphicsPath for branding or UI icons.
 * 2. When an application must programmatically draw a closed polygon on a 500×500 canvas using Aspose.Imaging’s Graphics and Figure classes to illustrate geographic boundaries or floor‑plan sections.
 * 3. When a reporting tool requires embedding a simple vector‑based diagram (e.g., a pentagon) into a BMP image using C# and Aspose.Imaging for printable invoices or PDFs.
 * 4. When a game or simulation engine needs to create a static obstacle silhouette as a BMP asset by defining five vertices with PointF and rendering it with a Pen.
 * 5. When an automated testing framework must produce a known‑shape BMP file to validate image‑processing algorithms such as edge detection or shape recognition.
 */