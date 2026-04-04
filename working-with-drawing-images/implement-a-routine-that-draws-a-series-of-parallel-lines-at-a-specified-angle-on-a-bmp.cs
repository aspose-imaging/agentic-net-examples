using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Output BMP file path (hard‑coded)
        string outputPath = "output\\parallel_lines.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Image dimensions
        int width = 800;
        int height = 600;

        // Line drawing parameters
        double angleDeg = 45.0;          // Angle of the lines in degrees
        double spacing = 20.0;           // Distance between parallel lines
        int penWidth = 2;                // Pen thickness
        Color lineColor = Color.Black;   // Line color

        // Prepare BMP options with a FileCreateSource (output is already bound)
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        // Create the image canvas
        using (Image image = Image.Create(bmpOptions, width, height))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);
            Pen pen = new Pen(lineColor, penWidth);

            // Pre‑compute trigonometric values
            double angleRad = angleDeg * Math.PI / 180.0;
            double dirX = Math.Cos(angleRad);
            double dirY = Math.Sin(angleRad);
            double perpX = -Math.Sin(angleRad);
            double perpY = Math.Cos(angleRad);

            // Length sufficient to cover the whole canvas (diagonal)
            double maxOffset = Math.Sqrt(width * width + height * height);

            // Center of the canvas
            double centerX = width / 2.0;
            double centerY = height / 2.0;

            // Draw parallel lines across the canvas
            for (double offset = -maxOffset; offset <= maxOffset; offset += spacing)
            {
                double startX = centerX + perpX * offset - dirX * maxOffset;
                double startY = centerY + perpY * offset - dirY * maxOffset;
                double endX   = centerX + perpX * offset + dirX * maxOffset;
                double endY   = centerY + perpY * offset + dirY * maxOffset;

                graphics.DrawLine(pen,
                    (int)Math.Round(startX), (int)Math.Round(startY),
                    (int)Math.Round(endX),   (int)Math.Round(endY));
            }

            // Save the image (output already bound to the file)
            image.Save();
        }
    }
}