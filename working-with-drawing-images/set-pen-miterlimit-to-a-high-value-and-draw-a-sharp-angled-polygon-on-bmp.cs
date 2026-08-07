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

            // Set up BMP options
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                Source = new FileCreateSource(outputPath, false)
            };

            // Create a new BMP image
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics surface
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.Wheat);

                // Configure pen with a high MiterLimit
                Pen pen = new Pen(Color.Black, 2);
                pen.MiterLimit = 20f; // high value to handle sharp angles

                // Define a sharp‑angled polygon
                Point[] points = new Point[]
                {
                    new Point(50, 400),
                    new Point(250, 50),
                    new Point(450, 400),
                    new Point(300, 300),
                    new Point(200, 300)
                };

                // Draw the polygon
                graphics.DrawPolygon(pen, points);

                // Save the image
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
 * 1. When a developer needs to generate a 24‑bit BMP file containing a sharp‑angled polygon without miter clipping, they can set Pen.MiterLimit to a high value and draw the shape using Aspose.Imaging for .NET.
 * 2. When creating custom map markers or architectural diagrams in a BMP image, increasing the pen’s MiterLimit ensures the acute corners of the polygon remain crisp and accurate.
 * 3. When exporting a printable technical illustration to a BMP format, using a high MiterLimit prevents the default miter cutoff from distorting the sharp angles of the drawn polygon.
 * 4. When building a C# utility that programmatically adds watermark graphics with sharp corners to BMP images, configuring Pen.MiterLimit and calling Graphics.DrawPolygon produces clean, non‑rounded edges.
 * 5. When testing image rendering performance in Aspose.Imaging, drawing a complex, sharp‑angled polygon on a BMP canvas with a high MiterLimit helps verify that the library correctly handles extreme pen settings.
 */