using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Output directory for generated BMP files
        string outputDir = @"C:\temp\shapes";
        Directory.CreateDirectory(outputDir);

        int canvasWidth = 500;
        int canvasHeight = 500;

        // List of shape identifiers
        var shapeNames = new List<string> { "Rectangle", "Ellipse", "Line", "Polygon", "Arc", "Pie" };

        foreach (var shapeName in shapeNames)
        {
            // Construct output file path for the current shape
            string outputPath = Path.Combine(outputDir, $"shape_{shapeName.ToLower()}.bmp");

            // Ensure the directory exists (already created above)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure BMP creation options
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create a bound BMP image canvas
            using (Image image = Image.Create(bmpOptions, canvasWidth, canvasHeight))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Draw the specific shape
                switch (shapeName)
                {
                    case "Rectangle":
                        graphics.DrawRectangle(new Pen(Color.Black, 2), new Rectangle(50, 50, 400, 300));
                        break;
                    case "Ellipse":
                        graphics.DrawEllipse(new Pen(Color.Blue, 2), new Rectangle(100, 100, 300, 200));
                        break;
                    case "Line":
                        graphics.DrawLine(new Pen(Color.Red, 2), new Point(0, 0), new Point(canvasWidth, canvasHeight));
                        break;
                    case "Polygon":
                        graphics.DrawPolygon(new Pen(Color.Green, 2), new[]
                        {
                            new Point(250, 50),
                            new Point(450, 250),
                            new Point(250, 450),
                            new Point(50, 250)
                        });
                        break;
                    case "Arc":
                        graphics.DrawArc(new Pen(Color.Purple, 2), new Rectangle(100, 100, 300, 300), 0, 270);
                        break;
                    case "Pie":
                        graphics.DrawPie(new Pen(Color.Orange, 2), new Rectangle(150, 150, 200, 200), 0, 120);
                        break;
                }

                // Save the bound image to the file
                image.Save();
            }
        }
    }
}