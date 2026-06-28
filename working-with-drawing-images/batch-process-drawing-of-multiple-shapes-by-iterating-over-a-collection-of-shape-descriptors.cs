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
            // Define output path
            string outputPath = @"C:\temp\shapes_output.png";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create PNG options with file source
            Source source = new FileCreateSource(outputPath, false);
            PngOptions pngOptions = new PngOptions() { Source = source };

            // Create a new image canvas
            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Define a collection of shape descriptors
                var shapes = new List<(string Type, Color Color, int X, int Y, int Width, int Height)>
                {
                    ("Rectangle", Color.Red, 50, 50, 150, 100),
                    ("Ellipse", Color.Blue, 250, 50, 120, 120),
                    ("Line", Color.Green, 100, 200, 300, 350),
                    ("Pie", Color.Purple, 150, 250, 200, 200)
                };

                // Iterate and draw each shape
                foreach (var s in shapes)
                {
                    Pen pen = new Pen(s.Color, 2);
                    switch (s.Type)
                    {
                        case "Rectangle":
                            graphics.DrawRectangle(pen, new Rectangle(s.X, s.Y, s.Width, s.Height));
                            break;
                        case "Ellipse":
                            graphics.DrawEllipse(pen, new Rectangle(s.X, s.Y, s.Width, s.Height));
                            break;
                        case "Line":
                            graphics.DrawLine(pen, new Point(s.X, s.Y), new Point(s.Width, s.Height));
                            break;
                        case "Pie":
                            graphics.DrawPie(pen, new Rectangle(s.X, s.Y, s.Width, s.Height), 0, 90);
                            break;
                    }
                }

                // Save the image (bound to the file source)
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
 * 1. When a developer needs to generate a PNG report thumbnail that visualizes layout zones (rectangles, ellipses, lines, pies) based on dynamic data, they can use this Aspose.Imaging C# code to batch‑draw the shapes onto a 500×500 canvas.
 * 2. When an application must create custom diagram assets (e.g., flow‑chart symbols) on the fly and save them as PNG files, iterating over a shape descriptor list with Aspose.Imaging simplifies the batch rendering process.
 * 3. When a web service has to produce on‑demand image badges that combine multiple geometric elements (colored rectangles, circles, lines, and pie slices) for user profiles, this code provides a programmatic way to compose and export the PNG.
 * 4. When an automated testing tool needs to overlay visual markers (rectangular highlights, ellipses around defects, connecting lines, and pie charts) onto screenshots for defect documentation, the batch shape drawing loop in Aspose.Imaging handles the composition.
 * 5. When a desktop utility must convert a collection of shape definitions stored in a database into a single PNG illustration for printing or archiving, the C# example demonstrates how to iterate through the descriptors and render each shape with Aspose.Imaging.
 */