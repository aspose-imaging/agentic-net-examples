// HOW-TO: Draw a 5‑pointed Star on a BMP with Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main()
    {
        // Hardcoded paths
        string outputPath = @"C:\Temp\star.bmp";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Create BMP image options
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                Source = new FileCreateSource(outputPath, false)
            };

            int width = 400;
            int height = 400;

            // Create a new BMP image
            using (Image image = Image.Create(bmpOptions, width, height))
            {
                // Initialize graphics object
                Graphics graphics = new Graphics(image);

                // Clear background
                graphics.Clear(Color.White);

                // Define star points (5‑pointed star)
                // Center at (200,200), outer radius 150, inner radius 60
                Point[] starPoints = new Point[10];
                double angle = -Math.PI / 2; // start at top
                double step = Math.PI / 5;   // 36 degrees

                for (int i = 0; i < 10; i++)
                {
                    double radius = (i % 2 == 0) ? 150 : 60;
                    int x = (int)(200 + radius * Math.Cos(angle));
                    int y = (int)(200 + radius * Math.Sin(angle));
                    starPoints[i] = new Point(x, y);
                    angle += step;
                }

                // Draw star using line segments
                Pen starPen = new Pen(Color.Gold, 3);
                for (int i = 0; i < 10; i++)
                {
                    Point p1 = starPoints[i];
                    Point p2 = starPoints[(i + 1) % 10];
                    graphics.DrawLine(starPen, p1, p2);
                }

                // Save the image (the source is already a FileCreateSource)
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
 * 1. When you need to generate a custom star logo dynamically and save it as a BMP for use in Windows desktop applications.
 * 2. When you want to create a high‑resolution star watermark on images without relying on external drawing libraries.
 * 3. When you are building a game asset pipeline that requires programmatically drawing geometric shapes such as stars directly into bitmap files.
 * 4. When you need to produce printable star icons for reports or PDFs by rendering them with precise line‑segment control in C#.
 * 5. When you must generate a series of star‑shaped markers for map visualizations and store them as BMP files for fast loading.
 */
