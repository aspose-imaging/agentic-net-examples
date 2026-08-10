// HOW-TO: Create a Spiral BMP Image Using Bezier Curves in C# (Aspose.Imaging for .NET)
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
            string outputPath = "output/spiral.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up BMP options with a file source
            Source source = new FileCreateSource(outputPath, false);
            BmpOptions bmpOptions = new BmpOptions() { Source = source };

            int width = 800;
            int height = 800;

            // Create a BMP canvas
            using (RasterImage canvas = (RasterImage)Image.Create(bmpOptions, width, height))
            {
                // Initialize graphics and clear background
                Graphics graphics = new Graphics(canvas);
                graphics.Clear(Color.White);

                Pen pen = new Pen(Color.Black, 2);

                // Spiral parameters
                double centerX = width / 2.0;
                double centerY = height / 2.0;
                double radius = 300;
                double angle = 0;
                double angleStep = Math.PI / 4; // 45 degrees per segment
                int segments = 12;

                for (int i = 0; i < segments; i++)
                {
                    double startAngle = angle;
                    double endAngle = angle + angleStep;

                    // Start and end points of the Bezier curve
                    int x1 = (int)(centerX + radius * Math.Cos(startAngle));
                    int y1 = (int)(centerY + radius * Math.Sin(startAngle));
                    int x4 = (int)(centerX + radius * Math.Cos(endAngle));
                    int y4 = (int)(centerY + radius * Math.Sin(endAngle));

                    // Control points for smooth curvature
                    double ctrlRadius = radius * 0.7;
                    int x2 = (int)(centerX + ctrlRadius * Math.Cos(startAngle + angleStep / 3));
                    int y2 = (int)(centerY + ctrlRadius * Math.Sin(startAngle + angleStep / 3));
                    int x3 = (int)(centerX + ctrlRadius * Math.Cos(startAngle + 2 * angleStep / 3));
                    int y3 = (int)(centerY + ctrlRadius * Math.Sin(startAngle + 2 * angleStep / 3));

                    // Draw the Bezier segment
                    graphics.DrawBezier(pen,
                        new Point(x1, y1),
                        new Point(x2, y2),
                        new Point(x3, y3),
                        new Point(x4, y4));

                    // Reduce radius for the next segment to create a spiral effect
                    radius *= 0.85;
                    angle += angleStep;
                }

                // Save the image
                canvas.Save();
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
 * 1. When you need to generate a decorative spiral pattern programmatically for a BMP background in a Windows desktop application.
 * 2. When you want to create vector‑like smooth curves on a raster canvas for scientific visualizations or logo designs using Aspose.Imaging.
 * 3. When you must export a custom spiral illustration to a BMP file for printing or embedding in legacy systems that only support BMP.
 * 4. When you are building a procedural art generator that draws complex shapes with Bezier curves without relying on external drawing libraries.
 * 5. When you need to automate the creation of test images with predictable geometry to validate image‑processing algorithms.
 */
