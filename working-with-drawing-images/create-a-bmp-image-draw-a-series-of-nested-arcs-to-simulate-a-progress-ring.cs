using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Output BMP file path
        string outputPath = @"C:\temp\progress_ring.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Bind the image to the output file
        Source source = new FileCreateSource(outputPath, false);
        BmpOptions options = new BmpOptions() { Source = source };

        int width = 400;
        int height = 400;

        // Create a BMP canvas
        using (RasterImage canvas = (RasterImage)Image.Create(options, width, height))
        {
            // Initialize graphics
            Graphics graphics = new Graphics(canvas);
            graphics.Clear(Color.White);

            int centerX = width / 2;
            int centerY = height / 2;
            int maxRadius = Math.Min(width, height) / 2 - 20;
            int steps = 5;
            int stepSize = 20;

            // Draw nested arcs to simulate a progress ring
            for (int i = 0; i < steps; i++)
            {
                int radius = maxRadius - i * stepSize;
                if (radius <= 0) break;

                Rectangle rect = new Rectangle(centerX - radius, centerY - radius, radius * 2, radius * 2);
                Color arcColor = (i % 2 == 0) ? Color.Blue : Color.Green;

                Pen pen = new Pen(arcColor, 8);
                // Start angle -90 draws from top, sweep 270 creates three‑quarter arc
                graphics.DrawArc(pen, rect, -90, 270);
            }

            // Save the bound image
            canvas.Save();
        }
    }
}