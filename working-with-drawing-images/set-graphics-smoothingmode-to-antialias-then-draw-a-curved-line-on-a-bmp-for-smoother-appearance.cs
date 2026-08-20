// HOW-TO: Create BMP With Anti‑Aliased Curved Line In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output BMP file path (hard‑coded)
            string outputPath = @"C:\temp\curved_line.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create BMP options
            BmpOptions bmpOptions = new BmpOptions();

            // Create a new image canvas (400x300)
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(bmpOptions, 400, 300))
            {
                // Initialize Graphics for drawing
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);

                // Enable antialiasing for smoother curves
                graphics.SmoothingMode = Aspose.Imaging.SmoothingMode.AntiAlias;

                // Define a blue pen for the curve
                Aspose.Imaging.Pen pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Blue, 3);

                // Points defining the curved line
                Aspose.Imaging.Point[] points = new Aspose.Imaging.Point[]
                {
                    new Aspose.Imaging.Point(50, 250),
                    new Aspose.Imaging.Point(150, 50),
                    new Aspose.Imaging.Point(250, 250),
                    new Aspose.Imaging.Point(350, 50)
                };

                // Draw the curved line
                graphics.DrawCurve(pen, points);

                // Save the image to the specified path
                image.Save(outputPath, bmpOptions);
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
 * 1. When you need to generate a BMP chart or diagram with smooth, anti‑aliased curves for reports or UI elements.
 * 2. When you want to programmatically draw a decorative wavy line on a bitmap for a game background or banner.
 * 3. When you must export a vector‑style curve as a raster BMP image while preserving visual quality using Aspose.Imaging.
 * 4. When you are creating custom icons or thumbnails that require precise curve rendering without jagged edges.
 * 5. When you need to automate the production of high‑resolution BMP assets with consistent smoothing settings across multiple images.
 */
