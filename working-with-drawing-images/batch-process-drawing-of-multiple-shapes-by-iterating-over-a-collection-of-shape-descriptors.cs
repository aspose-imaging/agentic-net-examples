// HOW-TO: Batch Draw Multiple Shapes Onto BMP Image With Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            int width = 800;
            int height = 600;

            BmpOptions options = new BmpOptions();
            options.Source = new FileCreateSource(outputPath, false);

            using (Image image = Image.Create(options, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                var shapes = new List<(string shape, object[] args)>();

                shapes.Add(("Line", new object[] { new Aspose.Imaging.Point(100, 100), new Aspose.Imaging.Point(200, 200) }));
                shapes.Add(("Rectangle", new object[] { new Aspose.Imaging.Rectangle(250, 150, 200, 100) }));
                shapes.Add(("Ellipse", new object[] { new Aspose.Imaging.Rectangle(500, 300, 150, 100) }));
                shapes.Add(("Polygon", new object[] { new Aspose.Imaging.Point[] {
                    new Aspose.Imaging.Point(400, 400),
                    new Aspose.Imaging.Point(450, 450),
                    new Aspose.Imaging.Point(400, 500)
                } }));

                foreach (var shape in shapes)
                {
                    switch (shape.shape)
                    {
                        case "Line":
                            var p1 = (Aspose.Imaging.Point)shape.args[0];
                            var p2 = (Aspose.Imaging.Point)shape.args[1];
                            Pen linePen = new Pen(Aspose.Imaging.Color.Blue, 2);
                            graphics.DrawLine(linePen, p1, p2);
                            break;

                        case "Rectangle":
                            var rect = (Aspose.Imaging.Rectangle)shape.args[0];
                            Pen rectPen = new Pen(Aspose.Imaging.Color.Green, 2);
                            graphics.DrawRectangle(rectPen, rect);
                            using (SolidBrush brush = new SolidBrush(Aspose.Imaging.Color.FromArgb(128, Aspose.Imaging.Color.Yellow)))
                            {
                                graphics.FillRectangle(brush, rect);
                            }
                            break;

                        case "Ellipse":
                            var ellRect = (Aspose.Imaging.Rectangle)shape.args[0];
                            Pen ellipsePen = new Pen(Aspose.Imaging.Color.Red, 2);
                            graphics.DrawEllipse(ellipsePen, ellRect);
                            using (SolidBrush brush = new SolidBrush(Aspose.Imaging.Color.FromArgb(128, Aspose.Imaging.Color.Pink)))
                            {
                                graphics.FillEllipse(brush, ellRect);
                            }
                            break;

                        case "Polygon":
                            var points = (Aspose.Imaging.Point[])shape.args[0];
                            Pen polyPen = new Pen(Aspose.Imaging.Color.Purple, 2);
                            graphics.DrawPolygon(polyPen, points);
                            using (SolidBrush brush = new SolidBrush(Aspose.Imaging.Color.FromArgb(128, Aspose.Imaging.Color.LightGray)))
                            {
                                graphics.FillPolygon(brush, points);
                            }
                            break;
                    }
                }

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
 * 1. When you need to generate a template BMP file that contains a set of predefined lines, rectangles, ellipses, and polygons for a reporting dashboard.
 * 2. When you want to programmatically create vector‑based graphics for a game map overlay by iterating over a collection of shape definitions.
 * 3. When you have to produce batch‑processed engineering diagrams, such as circuit schematics, by drawing multiple shapes onto a single bitmap in C#.
 * 4. When you are building an automated watermarking tool that adds various geometric shapes to scanned documents saved as BMP files.
 * 5. When you need to export shape data from a database into a visual BMP preview for a CAD‑like web application using Aspose.Imaging.
 */
