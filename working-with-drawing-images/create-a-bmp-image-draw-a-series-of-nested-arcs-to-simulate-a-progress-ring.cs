using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded output path
        string outputPath = @"C:\temp\progress_ring.bmp";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a bound BMP image
        Source source = new FileCreateSource(outputPath, false);
        BmpOptions bmpOptions = new BmpOptions() { Source = source };
        int width = 400;
        int height = 400;

        using (BmpImage canvas = (BmpImage)Image.Create(bmpOptions, width, height))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(canvas);
            graphics.Clear(Color.White); // Background

            // Parameters for nested arcs
            int centerX = width / 2;
            int centerY = height / 2;
            int maxRadius = 150;
            int ringCount = 5;
            int ringWidth = 20;
            int gap = 5; // gap between rings

            for (int i = 0; i < ringCount; i++)
            {
                int radius = maxRadius - i * (ringWidth + gap);
                int rectSize = radius * 2;
                Rectangle rect = new Rectangle(centerX - radius, centerY - radius, rectSize, rectSize);

                // Vary color for each ring
                int blue = Math.Max(0, 255 - i * 40);
                Color penColor = Color.FromArgb(255, 0, 0, blue);
                Pen pen = new Pen(penColor, ringWidth);

                // Draw a 270-degree arc to simulate progress
                graphics.DrawArc(pen, rect, 0, 270);
            }

            // Save the bound image
            canvas.Save();
        }
    }
}