// HOW-TO: Generate Multiple BMP Images with Different Shapes Using C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define canvas size
            const int canvasWidth = 500;
            const int canvasHeight = 500;

            // List of shapes to draw
            var shapes = new List<string>
            {
                "Rectangle",
                "Ellipse",
                "Line",
                "Polygon",
                "Arc",
                "Pie"
            };

            foreach (var shapeName in shapes)
            {
                // Output file path (hardcoded)
                string outputPath = Path.Combine("output", $"shape_{shapeName}.bmp");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Create BMP options with file source
                var bmpOptions = new BmpOptions
                {
                    BitsPerPixel = 24,
                    Source = new FileCreateSource(outputPath, false)
                };

                // Create image canvas
                using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(bmpOptions, canvasWidth, canvasHeight))
                {
                    // Initialize graphics for drawing
                    Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);
                    graphics.Clear(Aspose.Imaging.Color.White);

                    // Common pen
                    var pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 3);

                    // Draw specific shape
                    switch (shapeName)
                    {
                        case "Rectangle":
                            graphics.DrawRectangle(pen, new Aspose.Imaging.Rectangle(100, 100, 300, 200));
                            break;
                        case "Ellipse":
                            graphics.DrawEllipse(pen, new Aspose.Imaging.Rectangle(100, 100, 300, 200));
                            break;
                        case "Line":
                            graphics.DrawLine(pen, new Aspose.Imaging.Point(50, 50), new Aspose.Imaging.Point(450, 450));
                            break;
                        case "Polygon":
                            graphics.DrawPolygon(pen, new[]
                            {
                                new Aspose.Imaging.Point(250, 50),
                                new Aspose.Imaging.Point(450, 250),
                                new Aspose.Imaging.Point(250, 450),
                                new Aspose.Imaging.Point(50, 250)
                            });
                            break;
                        case "Arc":
                            graphics.DrawArc(pen, new Aspose.Imaging.Rectangle(100, 100, 300, 300), 0, 270);
                            break;
                        case "Pie":
                            graphics.DrawPie(pen, new Aspose.Imaging.Rectangle(100, 100, 300, 300), 0, 90);
                            break;
                    }

                    // Save the image (bound to source, so just call Save())
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
 * 1. When you need to create a set of BMP files that each show a specific geometric shape for testing image‑processing algorithms or UI components.
 * 2. When you want to automate the production of sample graphics such as rectangles, ellipses, lines, polygons, arcs, and pies for documentation or training material.
 * 3. When a game or simulation requires pre‑rendered shape assets in BMP format that can be loaded quickly at runtime.
 * 4. When you are benchmarking drawing performance in Aspose.Imaging by measuring how fast each shape can be rendered to a 24‑bit BMP canvas.
 * 5. When you need to generate placeholder images for a web service that expects BMP files containing distinct shapes for validation or mock‑up purposes.
 */
