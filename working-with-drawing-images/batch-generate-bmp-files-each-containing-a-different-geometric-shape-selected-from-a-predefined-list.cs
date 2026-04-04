using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Output directory for generated BMP files
        string outputDir = @"C:\Temp\Shapes";

        // List of shape identifiers
        var shapes = new List<string> { "Rectangle", "Ellipse", "Line", "Polygon", "FilledRectangle" };

        foreach (var shape in shapes)
        {
            // Construct output file path
            string outputPath = Path.Combine(outputDir, shape + ".bmp");

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure BMP options with a file create source
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create a 500x500 BMP canvas bound to the output file
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Pen for outlines
                Pen pen = new Pen(Color.Black, 3);

                // Draw the specific shape
                if (shape == "Rectangle")
                {
                    graphics.DrawRectangle(pen, new Rectangle(50, 50, 400, 400));
                }
                else if (shape == "Ellipse")
                {
                    graphics.DrawEllipse(pen, new Rectangle(50, 50, 400, 400));
                }
                else if (shape == "Line")
                {
                    graphics.DrawLine(pen, new Point(0, 0), new Point(500, 500));
                }
                else if (shape == "Polygon")
                {
                    Point[] points = new Point[]
                    {
                        new Point(250, 50),
                        new Point(450, 250),
                        new Point(350, 450),
                        new Point(150, 450),
                        new Point(50, 250)
                    };
                    graphics.DrawPolygon(pen, points);
                }
                else if (shape == "FilledRectangle")
                {
                    using (SolidBrush brush = new SolidBrush(Color.LightBlue))
                    {
                        graphics.FillRectangle(brush, new Rectangle(100, 100, 300, 300));
                    }
                    graphics.DrawRectangle(pen, new Rectangle(100, 100, 300, 300));
                }

                // Save the bound image
                image.Save();
            }
        }
    }
}