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
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.bmp"; // not used but shown for rule compliance
            string outputPath = @"C:\temp\output.bmp";

            // Input path check (rule compliance)
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists (rule compliance)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up BMP options
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                Source = new FileCreateSource(outputPath, false)
            };

            // Create a new image (500x500)
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics object
                Graphics graphics = new Graphics(image);

                // Clear background
                graphics.Clear(Color.Wheat);

                // Create a pen with high MiterLimit
                Pen pen = new Pen(Color.Black, 5);
                pen.MiterLimit = 20f; // high value for sharp angles

                // Define a sharp‑angled polygon
                Point[] polygonPoints = new Point[]
                {
                    new Point(100, 100),
                    new Point(200, 50),   // sharp angle point
                    new Point(300, 100),
                    new Point(250, 200),
                    new Point(150, 200)
                };

                // Draw the polygon
                graphics.DrawPolygon(pen, polygonPoints);

                // Save changes
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
 * 1. When a developer needs to generate a high‑resolution BMP diagram that highlights sharp corners, such as a technical schematic or architectural floor plan, they can set Pen.MiterLimit to a high value and draw a polygon with acute angles.
 * 2. When creating custom map markers or icons for a GIS application where the shape must retain crisp, pointed edges in a 24‑bit BMP file, using a high MiterLimit ensures the polygon’s sharp vertices are rendered without clipping.
 * 3. When producing printable engineering drawings that require precise line joins on a BMP canvas, increasing Pen.MiterLimit prevents miter truncation on tight angles and preserves the intended geometry.
 * 4. When building a game asset pipeline that generates simple BMP sprites with stylized, jagged shapes, a high MiterLimit allows the developer to draw sharp‑angled polygons that maintain visual fidelity at various scales.
 * 5. When automating the creation of watermark overlays with intricate, pointed patterns on BMP images, setting a high MiterLimit guarantees that the polygon’s acute corners appear clean and consistent across all generated files.
 */