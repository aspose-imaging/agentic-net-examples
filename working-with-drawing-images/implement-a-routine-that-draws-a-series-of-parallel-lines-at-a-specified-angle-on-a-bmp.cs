using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded output path
        string outputPath = @"C:\Temp\ParallelLines.bmp";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Canvas size
        int width = 800;
        int height = 600;

        // Line parameters
        double angleDeg = 45.0;               // Angle of lines in degrees
        double spacing = 20.0;                // Distance between parallel lines
        double angleRad = angleDeg * Math.PI / 180.0;
        double dx = Math.Cos(angleRad);       // Direction vector X
        double dy = Math.Sin(angleRad);       // Direction vector Y
        double px = -dy;                      // Perpendicular vector X
        double py = dx;                       // Perpendicular vector Y
        double halfLength = Math.Sqrt(width * width + height * height); // Half length to cover canvas

        // Number of lines to cover the whole image
        int lineCount = (int)((width + height) / spacing) * 2;

        // Create BMP image bound to the output file
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        using (Image image = Image.Create(bmpOptions, width, height))
        {
            // Initialize graphics
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.White);

            Pen pen = new Pen(Color.Black, 1);

            // Center of the canvas
            double centerX = width / 2.0;
            double centerY = height / 2.0;

            // Draw parallel lines
            for (int i = -lineCount; i <= lineCount; i++)
            {
                double offset = i * spacing;
                double cx = centerX + offset * px;
                double cy = centerY + offset * py;

                double x1 = cx - halfLength * dx;
                double y1 = cy - halfLength * dy;
                double x2 = cx + halfLength * dx;
                double y2 = cy + halfLength * dy;

                graphics.DrawLine(pen,
                    (int)Math.Round(x1), (int)Math.Round(y1),
                    (int)Math.Round(x2), (int)Math.Round(y2));
            }

            // Save the image (output file already bound)
            image.Save();
        }
    }
}