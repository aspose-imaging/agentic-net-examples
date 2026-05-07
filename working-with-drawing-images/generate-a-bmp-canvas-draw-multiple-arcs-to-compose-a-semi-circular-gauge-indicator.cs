using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main()
    {
        // Hardcoded paths
        string outputPath = @"C:\Temp\gauge.bmp";

        try
        {
            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create BMP options (24 bits per pixel)
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                Source = new FileCreateSource(outputPath, false)
            };

            // Define image size
            const int width = 400;
            const int height = 200;

            // Create the image
            using (Image image = Image.Create(bmpOptions, width, height))
            {
                // Initialize graphics object
                Graphics graphics = new Graphics(image);

                // Clear background
                graphics.Clear(Color.Wheat);

                // Define common pen for arcs
                Pen arcPen = new Pen(Color.Blue, 4);

                // Center of the gauge
                int centerX = width / 2;
                int centerY = height;

                // Radius of the outer arc
                int outerRadius = 180;

                // Draw outer semi‑circular arc (180° sweep)
                graphics.DrawArc(
                    arcPen,
                    new Rectangle(centerX - outerRadius, centerY - outerRadius, outerRadius * 2, outerRadius * 2),
                    180,   // start angle (leftmost point)
                    180);  // sweep angle (semi‑circle)

                // Draw inner semi‑circular arc to create thickness
                int innerRadius = 150;
                graphics.DrawArc(
                    arcPen,
                    new Rectangle(centerX - innerRadius, centerY - innerRadius, innerRadius * 2, innerRadius * 2),
                    180,
                    180);

                // Draw tick marks (small arcs) at 0°, 45°, 90°, 135°, 180°
                int tickRadius = outerRadius;
                int tickLength = 10;
                Pen tickPen = new Pen(Color.Black, 2);
                for (int angle = 180; angle <= 360; angle += 45)
                {
                    // Convert angle to radians
                    double rad = angle * Math.PI / 180.0;
                    // Start point on outer radius
                    int x1 = (int)(centerX + (tickRadius - tickLength) * Math.Cos(rad));
                    int y1 = (int)(centerY + (tickRadius - tickLength) * Math.Sin(rad));
                    // End point on outer radius
                    int x2 = (int)(centerX + tickRadius * Math.Cos(rad));
                    int y2 = (int)(centerY + tickRadius * Math.Sin(rad));
                    // Draw line as a very short arc (using DrawLine for simplicity)
                    graphics.DrawLine(tickPen, x1, y1, x2, y2);
                }

                // Save the image (the FileCreateSource already points to outputPath)
                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}