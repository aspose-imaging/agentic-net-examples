// HOW-TO: Draw Precise Arc on BMP Using Float Rectangle in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded output path
            string outputPath = @"C:\Temp\output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up BMP options with a file create source
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                Source = new FileCreateSource(outputPath, false)
            };

            // Create a 500x500 BMP image
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics object for drawing
                Graphics graphics = new Graphics(image);

                // Clear background to white
                graphics.Clear(Color.White);

                // Define a pen with blue color and 2-pixel width
                Pen pen = new Pen(Color.Blue, 2);

                // Define a floating‑point rectangle for precise positioning
                RectangleF rect = new RectangleF(50.5f, 50.5f, 200.2f, 150.8f);

                // Draw an arc using the floating‑point overload
                graphics.DrawArc(pen, rect, 45f, 270f);

                // Save the image (writes to the file specified in bmpOptions.Source)
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
 * 1. When you need to generate a BMP report graphic with an accurately positioned curved line for engineering diagrams.
 * 2. When creating a thumbnail preview that requires a smooth arc drawn at sub‑pixel coordinates for high‑resolution UI elements.
 * 3. When programmatically adding a decorative arc to a bitmap logo where exact placement matters for branding consistency.
 * 4. When exporting scientific data visualizations to BMP and the arc must align precisely with measured data points.
 * 5. When building a custom map overlay in C# and you must draw arcs with floating‑point precision on a BMP background.
 */
