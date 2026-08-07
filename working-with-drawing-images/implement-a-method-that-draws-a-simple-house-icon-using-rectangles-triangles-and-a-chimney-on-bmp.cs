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
            // Output BMP file path
            string outputPath = @"C:\temp\house.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create file source for BMP output
            Source source = new FileCreateSource(outputPath, false);

            // BMP options with the source
            BmpOptions options = new BmpOptions() { Source = source };

            // Define canvas size
            int canvasWidth = 200;
            int canvasHeight = 200;

            // Create bound BMP canvas
            using (RasterImage canvas = (RasterImage)Image.Create(options, canvasWidth, canvasHeight))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(canvas);

                // Clear background to white
                graphics.Clear(Color.White);

                // Pen for outlines
                Pen blackPen = new Pen(Color.Black, 2);

                // Draw house base rectangle
                Rectangle houseBase = new Rectangle(50, 100, 100, 80);
                graphics.DrawRectangle(blackPen, houseBase);
                using (SolidBrush houseBrush = new SolidBrush(Color.LightGray))
                {
                    graphics.FillRectangle(houseBrush, houseBase);
                }

                // Draw roof as a triangle (polygon)
                Point[] roofPoints = new Point[]
                {
                    new Point(50, 100),   // left corner
                    new Point(150, 100),  // right corner
                    new Point(100, 50)    // top peak
                };
                graphics.DrawPolygon(blackPen, roofPoints);
                using (SolidBrush roofBrush = new SolidBrush(Color.Brown))
                {
                    graphics.FillPolygon(roofBrush, roofPoints);
                }

                // Draw chimney rectangle
                Rectangle chimney = new Rectangle(115, 55, 20, 30);
                graphics.DrawRectangle(blackPen, chimney);
                using (SolidBrush chimneyBrush = new SolidBrush(Color.DarkRed))
                {
                    graphics.FillRectangle(chimneyBrush, chimney);
                }

                // Save the bound image
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
 * 1. When a developer needs to generate a lightweight BMP placeholder icon for real‑estate listings or property management software, this Aspose.Imaging C# code can quickly draw a simple house silhouette using rectangles and polygons.
 * 2. When building an educational Windows desktop app that teaches basic geometry, the code provides a clear example of drawing shapes (rectangle, triangle, chimney) on a raster canvas with Aspose.Imaging.
 * 3. When creating BMP assets for low‑resource embedded devices or IoT dashboards, the method produces a minimal house graphic without requiring external image files.
 * 4. When testing an image‑processing pipeline that expects BMP input, developers can use this code to produce consistent, programmatically generated house images for validation.
 * 5. When designing custom UI icons for a C# WinForms application, the snippet demonstrates how to draw and fill vector‑style shapes directly into a BMP file using Aspose.Imaging’s Graphics API.
 */