using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output directory for generated BMP files
            string outputDir = @"C:\Temp\Shapes";

            // List of geometric shapes to generate
            var shapes = new[] { "Rectangle", "Ellipse", "Line", "Arc", "Pie", "Polygon" };

            int canvasWidth = 200;
            int canvasHeight = 200;

            foreach (var shape in shapes)
            {
                // Define output file path for the current shape
                string outputPath = Path.Combine(outputDir, $"{shape}.bmp");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Configure BMP options with a file create source
                BmpOptions bmpOptions = new BmpOptions
                {
                    BitsPerPixel = 24,
                    Source = new FileCreateSource(outputPath, false)
                };

                // Create a bound BMP image canvas
                using (Image image = Image.Create(bmpOptions, canvasWidth, canvasHeight))
                {
                    // Initialize graphics for drawing
                    Graphics graphics = new Graphics(image);
                    graphics.Clear(Color.White);

                    // Common pen for outlines
                    Pen pen = new Pen(Color.Black, 2);

                    // Solid brush for fills (only SolidBrush is supported for FillXXX)
                    using (SolidBrush brush = new SolidBrush(Color.LightBlue))
                    {
                        switch (shape)
                        {
                            case "Rectangle":
                                graphics.FillRectangle(brush, 10, 10, canvasWidth - 20, canvasHeight - 20);
                                graphics.DrawRectangle(pen, 10, 10, canvasWidth - 20, canvasHeight - 20);
                                break;
                            case "Ellipse":
                                graphics.FillEllipse(brush, 10, 10, canvasWidth - 20, canvasHeight - 20);
                                graphics.DrawEllipse(pen, 10, 10, canvasWidth - 20, canvasHeight - 20);
                                break;
                            case "Line":
                                graphics.DrawLine(pen, 10, 10, canvasWidth - 10, canvasHeight - 10);
                                break;
                            case "Arc":
                                {
                                    Rectangle rect = new Rectangle(20, 20, canvasWidth - 40, canvasHeight - 40);
                                    graphics.DrawArc(pen, rect, 0, 180);
                                }
                                break;
                            case "Pie":
                                {
                                    Rectangle rect = new Rectangle(20, 20, canvasWidth - 40, canvasHeight - 40);
                                    graphics.FillPie(brush, rect, 0, 90);
                                    graphics.DrawPie(pen, rect, 0, 90);
                                }
                                break;
                            case "Polygon":
                                {
                                    Point[] points = new Point[]
                                    {
                                        new Point(10, canvasHeight - 10),
                                        new Point(canvasWidth / 2, 10),
                                        new Point(canvasWidth - 10, canvasHeight - 10)
                                    };
                                    graphics.FillPolygon(brush, points);
                                    graphics.DrawPolygon(pen, points);
                                }
                                break;
                        }
                    }

                    // Save the bound image
                    image.Save();
                }
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
 * 1. When a developer needs to create a set of sample BMP icons showing basic geometric shapes for testing image rendering pipelines in a .NET application.
 * 2. When an automated documentation generator must embed placeholder graphics of rectangles, ellipses, and other shapes into help files without manually drawing each image.
 * 3. When a quality‑control tool requires pre‑generated BMP test patterns to verify that a printer driver correctly handles different drawing primitives.
 * 4. When a game‑development team wants to quickly produce bitmap assets for UI elements such as buttons or health bars by programmatically drawing shapes with Aspose.Imaging.
 * 5. When a data‑visualization library needs to supply example BMP files illustrating how to use the Graphics, Pen, and SolidBrush classes for drawing shapes in C#.
 */