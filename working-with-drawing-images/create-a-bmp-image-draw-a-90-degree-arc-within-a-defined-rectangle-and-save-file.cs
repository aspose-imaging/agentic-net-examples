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
            // Output BMP file path
            string outputPath = @"C:\temp\arc_output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure BMP options
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                Source = new FileCreateSource(outputPath, false)
            };

            // Create a 500x500 BMP image
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Optional: clear background to white
                graphics.Clear(Color.White);

                // Define a pen for the arc
                Pen pen = new Pen(Color.Black, 2);

                // Define the rectangle that bounds the arc
                Rectangle rect = new Rectangle(100, 100, 200, 200);

                // Draw a 90-degree arc (start angle 0, sweep angle 90)
                graphics.DrawArc(pen, rect, 0, 90);

                // Save the image (bound to the output source)
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
 * 1. When a developer needs to generate a BMP thumbnail that includes a 90‑degree arc as a visual progress indicator for a Windows desktop application.
 * 2. When an automated reporting tool must create a BMP chart legend with a quarter‑circle arc to represent a sector of a pie diagram in C#.
 * 3. When a game engine requires a simple BMP sprite sheet where a 90‑degree arc defines a collision boundary for a circular object.
 * 4. When a manufacturing system has to produce BMP labels with a quarter‑arc cut‑out shape to align with physical templates on a production line.
 * 5. When a legacy GIS application expects BMP map overlays and the developer must draw a 90‑degree arc to highlight a specific quadrant of a geographic region.
 */