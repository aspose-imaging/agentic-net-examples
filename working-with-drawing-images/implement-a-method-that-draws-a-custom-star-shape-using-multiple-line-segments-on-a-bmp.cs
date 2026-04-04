using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Output BMP file path (hardcoded)
        string outputPath = @"C:\temp\star.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Image dimensions
        int width = 500;
        int height = 500;

        // Configure BMP options
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.BitsPerPixel = 24;
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        // Create the image canvas
        using (Image image = Image.Create(bmpOptions, width, height))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.Black); // background color

            // Parameters for a 5‑point star
            double centerX = width / 2.0;
            double centerY = height / 2.0;
            double outerRadius = 200;
            double innerRadius = 80;

            // Compute star vertices (10 points alternating outer/inner)
            Point[] starPoints = new Point[10];
            for (int i = 0; i < 10; i++)
            {
                double angleDeg = 18 + i * 36; // start at 18°
                double angleRad = Math.PI * angleDeg / 180.0;
                double radius = (i % 2 == 0) ? outerRadius : innerRadius;
                int x = (int)(centerX + radius * Math.Cos(angleRad));
                int y = (int)(centerY - radius * Math.Sin(angleRad));
                starPoints[i] = new Point(x, y);
            }

            // Pen for drawing the star
            Pen pen = new Pen(Color.Yellow, 2);

            // Draw lines between consecutive vertices to form the star
            for (int i = 0; i < 10; i++)
            {
                Point start = starPoints[i];
                Point end = starPoints[(i + 1) % 10];
                graphics.DrawLine(pen, start, end);
            }

            // Save the image (output file already bound to the source)
            image.Save();
        }
    }
}