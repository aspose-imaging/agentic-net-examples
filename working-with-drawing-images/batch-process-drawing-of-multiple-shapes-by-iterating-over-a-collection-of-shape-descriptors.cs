// HOW-TO: Create PNG Image with Multiple Shapes Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output file path (hard‑coded)
            string outputPath = @"c:\temp\shapes_output.png";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up PNG options with a file create source
            PngOptions pngOptions = new PngOptions
            {
                Source = new FileCreateSource(outputPath, false)
            };

            // Create the image canvas
            using (Image image = Image.Create(pngOptions, 800, 600))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Draw Rectangle
                Pen rectPen = new Pen(Color.Red, 2);
                graphics.DrawRectangle(rectPen, new Rectangle(50, 50, 200, 150));

                // Draw Ellipse
                Pen ellipsePen = new Pen(Color.Green, 2);
                graphics.DrawEllipse(ellipsePen, new Rectangle(300, 100, 150, 150));

                // Draw Line
                Pen linePen = new Pen(Color.Blue, 2);
                graphics.DrawLine(linePen, new Point(100, 400), new Point(700, 500));

                // Draw Polygon
                Pen polyPen = new Pen(Color.Purple, 2);
                Point[] polygonPoints = new[]
                {
                    new Point(400, 300),
                    new Point(500, 350),
                    new Point(450, 450)
                };
                graphics.DrawPolygon(polyPen, polygonPoints);

                // Save the final image
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
 * 1. When you need to generate a PNG report that visualizes geometric diagrams such as rectangles, ellipses, lines, and polygons programmatically.
 * 2. When you want to automate the creation of placeholder graphics for UI mockups or documentation without using external design tools.
 * 3. When you must batch‑produce simple vector‑based icons or badges on a fixed canvas size for a web application.
 * 4. When you need to render custom shapes onto an image for testing image‑processing algorithms or OCR pipelines.
 * 5. When you are building a server‑side service that creates annotated screenshots or diagrams on the fly in C#.
 */
