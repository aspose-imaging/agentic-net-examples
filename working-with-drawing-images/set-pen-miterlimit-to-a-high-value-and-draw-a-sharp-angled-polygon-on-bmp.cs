// HOW-TO: Draw Sharp Angled Polygon on BMP with High Miter Limit in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded output path
            string outputPath = @"C:\temp\sharp_polygon.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up BMP options with a file create source
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                Source = new FileCreateSource(outputPath, false)
            };

            // Create a new BMP image (500x500)
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics object
                Graphics graphics = new Graphics(image);

                // Clear background
                graphics.Clear(Color.Wheat);

                // Define a sharp‑angled polygon (a thin triangle)
                Point[] points = new Point[]
                {
                    new Point(250, 50),   // Top vertex
                    new Point(240, 200),  // Left vertex (sharp angle)
                    new Point(260, 200)   // Right vertex
                };

                // Create a pen with high MiterLimit to preserve the sharp corner
                Pen pen = new Pen(Color.Black, 5);
                pen.MiterLimit = 20f; // high value

                // Draw the polygon
                graphics.DrawPolygon(pen, points);

                // Save the image (the path is already defined in the source)
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
 * 1. When you need to generate a BMP thumbnail that includes a precise, sharp‑cornered shape for a CAD preview.
 * 2. When creating custom report graphics where thin triangles must retain crisp corners despite thick stroke widths.
 * 3. When exporting vector‑style diagrams to BMP for legacy systems that require exact corner rendering.
 * 4. When programmatically drawing UI icons with sharp angles and need to prevent miter clipping by increasing the pen’s MiterLimit.
 * 5. When automating batch image creation for printing labels that contain narrow, pointed polygons and must preserve edge fidelity.
 */
