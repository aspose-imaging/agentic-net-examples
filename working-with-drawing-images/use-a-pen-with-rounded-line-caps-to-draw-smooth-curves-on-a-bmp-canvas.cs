// HOW-TO: Draw Smooth Curves on BMP with Rounded Pen Caps in C# (Aspose.Imaging for .NET)
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
            // Output BMP file path (hard‑coded)
            string outputPath = @"C:\temp\smooth_curves.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up BMP options with a file source bound to the output path
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create a 500x300 BMP canvas
            using (Image image = Image.Create(bmpOptions, 500, 300))
            {
                // Initialize graphics for drawing on the canvas
                Graphics graphics = new Graphics(image);

                // Clear the canvas with a white background
                graphics.Clear(Color.White);

                // Create a pen with blue color, width 5 and rounded line caps
                Pen pen = new Pen(Color.Blue, 5f);
                pen.StartCap = LineCap.Round;
                pen.EndCap = LineCap.Round;

                // Draw a smooth curve using a set of points
                graphics.DrawCurve(pen, new[]
                {
                    new Point(50, 250),
                    new Point(150, 50),
                    new Point(250, 250),
                    new Point(350, 50),
                    new Point(450, 250)
                });

                // Save the bound image (no need to pass path/options again)
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
 * 1. When you need to generate a BMP image that visualizes a smooth curve chart using Aspose.Imaging’s Graphics.DrawCurve with a rounded‑cap pen in C#.
 * 2. When you want to create custom icons or UI elements with anti‑aliased, rounded‑cap lines on a bitmap for a Windows desktop application.
 * 3. When you must programmatically draw decorative wave patterns or borders on a BMP canvas using a blue pen with rounded caps.
 * 4. When you need to export hand‑drawn‑style signatures or free‑form paths to a BMP file with smooth, rounded‑cap strokes.
 * 5. When you are building a server‑side service that produces BMP diagrams with smooth curves for embedding in reports or PDFs.
 */
