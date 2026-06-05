using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded output path
            string outputPath = @"c:\temp\batch_shapes.png";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up PNG options with a FileCreateSource bound to the output path
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            // Create the image canvas
            using (Image image = Image.Create(pngOptions, 800, 600))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Define a collection of shape descriptors
                var shapes = new List<(string Type, object[] Params)>
                {
                    ("Line", new object[] { new Point(50, 50), new Point(750, 50) }),
                    ("Rectangle", new object[] { new Rectangle(100, 100, 200, 150) }),
                    ("Ellipse", new object[] { new Rectangle(350, 100, 200, 150) }),
                    ("Pie", new object[] { new Rectangle(100, 300, 200, 150), 0f, 120f }),
                    ("Polygon", new object[] { new[] { new Point(400,300), new Point(500,350), new Point(450,450), new Point(350,400) } })
                };

                // Iterate over the descriptors and draw each shape
                foreach (var shape in shapes)
                {
                    switch (shape.Type)
                    {
                        case "Line":
                            var p1 = (Point)shape.Params[0];
                            var p2 = (Point)shape.Params[1];
                            graphics.DrawLine(new Pen(Color.Black, 2), p1, p2);
                            break;

                        case "Rectangle":
                            var rect = (Rectangle)shape.Params[0];
                            graphics.DrawRectangle(new Pen(Color.Blue, 2), rect);
                            break;

                        case "Ellipse":
                            var ellipseRect = (Rectangle)shape.Params[0];
                            graphics.DrawEllipse(new Pen(Color.Red, 2), ellipseRect);
                            break;

                        case "Pie":
                            var pieRect = (Rectangle)shape.Params[0];
                            var startAngle = (float)shape.Params[1];
                            var sweepAngle = (float)shape.Params[2];
                            graphics.DrawPie(new Pen(Color.Green, 2), pieRect, startAngle, sweepAngle);
                            break;

                        case "Polygon":
                            var points = (Point[])shape.Params[0];
                            graphics.DrawPolygon(new Pen(Color.Purple, 2), points);
                            break;
                    }
                }

                // Save the image (output file is already bound via FileCreateSource)
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
 * 1. When a developer needs to generate a PNG report that visualizes a series of geometric annotations (lines, rectangles, ellipses, pies, polygons) in a single image using Aspose.Imaging for .NET batch drawing.
 * 2. When an application must create thumbnails with overlaid shapes to highlight regions of interest in medical imaging or satellite photos, leveraging C# graphics drawing on an 800x600 canvas.
 * 3. When a web service automatically produces custom certificates or badges by iterating over shape descriptors and saving the result as a PNG file on the server.
 * 4. When a desktop tool needs to export a schematic diagram composed of multiple primitive shapes into a high‑resolution PNG for printing or archival purposes.
 * 5. When a batch processing job has to render a set of diagram elements defined in a collection into a single image file, using Aspose.Imaging’s FileCreateSource and PNG options for consistent output.
 */