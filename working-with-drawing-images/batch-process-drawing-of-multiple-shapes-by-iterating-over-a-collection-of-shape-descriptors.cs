using System;
using System.IO;
using System.Collections.Generic;
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
            // Output image path
            string outputPath = @"C:\temp\shapes_output.png";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create PNG options with file source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            // Create a new image canvas
            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                // Initialize graphics
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Define shape descriptors
                var shapes = new List<ShapeInfo>
                {
                    new ShapeInfo
                    {
                        Type = ShapeType.Rectangle,
                        X = 50,
                        Y = 50,
                        Width = 150,
                        Height = 100,
                        PenColor = Color.Blue,
                        PenWidth = 3
                    },
                    new ShapeInfo
                    {
                        Type = ShapeType.Ellipse,
                        X = 250,
                        Y = 50,
                        Width = 120,
                        Height = 120,
                        PenColor = Color.Green,
                        PenWidth = 2
                    },
                    new ShapeInfo
                    {
                        Type = ShapeType.Line,
                        X = 50,
                        Y = 200,
                        X2 = 400,
                        Y2 = 300,
                        PenColor = Color.Red,
                        PenWidth = 4
                    },
                    new ShapeInfo
                    {
                        Type = ShapeType.Arc,
                        X = 100,
                        Y = 350,
                        Width = 200,
                        Height = 100,
                        StartAngle = 0,
                        SweepAngle = 180,
                        PenColor = Color.Purple,
                        PenWidth = 2
                    },
                    new ShapeInfo
                    {
                        Type = ShapeType.Pie,
                        X = 320,
                        Y = 300,
                        Width = 150,
                        Height = 150,
                        StartAngle = 45,
                        SweepAngle = 90,
                        PenColor = Color.Orange,
                        PenWidth = 2
                    },
                    new ShapeInfo
                    {
                        Type = ShapeType.Polygon,
                        Points = new[]
                        {
                            new Point(200, 150),
                            new Point(250, 200),
                            new Point(300, 150),
                            new Point(275, 250),
                            new Point(225, 250)
                        },
                        PenColor = Color.Brown,
                        PenWidth = 2
                    }
                };

                // Iterate and draw each shape
                foreach (var shape in shapes)
                {
                    Pen pen = new Pen(shape.PenColor, shape.PenWidth);
                    switch (shape.Type)
                    {
                        case ShapeType.Rectangle:
                            graphics.DrawRectangle(pen, new Rectangle(shape.X, shape.Y, shape.Width, shape.Height));
                            break;
                        case ShapeType.Ellipse:
                            graphics.DrawEllipse(pen, new Rectangle(shape.X, shape.Y, shape.Width, shape.Height));
                            break;
                        case ShapeType.Line:
                            graphics.DrawLine(pen, new Point(shape.X, shape.Y), new Point(shape.X2, shape.Y2));
                            break;
                        case ShapeType.Arc:
                            graphics.DrawArc(pen, new Rectangle(shape.X, shape.Y, shape.Width, shape.Height), shape.StartAngle, shape.SweepAngle);
                            break;
                        case ShapeType.Pie:
                            graphics.DrawPie(pen, new Rectangle(shape.X, shape.Y, shape.Width, shape.Height), shape.StartAngle, shape.SweepAngle);
                            break;
                        case ShapeType.Polygon:
                            graphics.DrawPolygon(pen, shape.Points);
                            break;
                    }
                }

                // Save the image (file is already bound to the source)
                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    enum ShapeType
    {
        Rectangle,
        Ellipse,
        Line,
        Arc,
        Pie,
        Polygon
    }

    class ShapeInfo
    {
        public ShapeType Type { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int X2 { get; set; }
        public int Y2 { get; set; }
        public float StartAngle { get; set; }
        public float SweepAngle { get; set; }
        public Color PenColor { get; set; }
        public float PenWidth { get; set; }
        public Point[] Points { get; set; }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to generate a PNG report that visualizes a set of geometric annotations such as rectangles, ellipses, and lines on a white canvas using Aspose.Imaging for .NET.
 * 2. When an application must programmatically create batch images for a UI mock‑up, drawing multiple shapes from a collection of shape descriptors and saving each as a PNG file.
 * 3. When a server‑side service has to produce dynamic diagram thumbnails (e.g., floor plans or flowcharts) by iterating over shape data and rendering them with specific pen colors and widths.
 * 4. When a data‑driven graphics engine needs to convert shape metadata stored in a database into a raster image for export to PNG format without manual drawing.
 * 5. When an automated testing tool requires the creation of consistent visual fixtures by drawing predefined shapes on an image canvas and saving the result for pixel comparison.
 */