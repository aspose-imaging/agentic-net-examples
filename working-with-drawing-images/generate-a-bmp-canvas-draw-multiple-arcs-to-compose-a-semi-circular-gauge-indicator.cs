using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded output path
            string outputPath = @"C:\Temp\gauge.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set BMP creation options
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create a BMP canvas (width: 400, height: 200)
            using (Image image = Image.Create(bmpOptions, 400, 200))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Gauge parameters
                int centerX = 200;
                int centerY = 200;
                int radiusOuter = 180;
                int radiusInner = 150;

                // Outer semi‑circular arc (0° to 180°)
                Pen outerPen = new Pen(Color.Black, 4);
                graphics.DrawArc(
                    outerPen,
                    new Rectangle(centerX - radiusOuter, centerY - radiusOuter, radiusOuter * 2, radiusOuter * 2),
                    0,
                    180);

                // Inner semi‑circular arc
                Pen innerPen = new Pen(Color.Gray, 2);
                graphics.DrawArc(
                    innerPen,
                    new Rectangle(centerX - radiusInner, centerY - radiusInner, radiusInner * 2, radiusInner * 2),
                    0,
                    180);

                // Tick marks every 10 degrees
                Pen tickPen = new Pen(Color.Black, 2);
                for (int angle = 0; angle <= 180; angle += 10)
                {
                    double rad = angle * Math.PI / 180.0;
                    int xOuter = centerX + (int)(radiusOuter * Math.Cos(rad));
                    int yOuter = centerY - (int)(radiusOuter * Math.Sin(rad));
                    int xInner = centerX + (int)(radiusInner * Math.Cos(rad));
                    int yInner = centerY - (int)(radiusInner * Math.Sin(rad));
                    graphics.DrawLine(tickPen, xInner, yInner, xOuter, yOuter);
                }

                // Needle pointing at 75 degrees
                Pen needlePen = new Pen(Color.Red, 3);
                int needleLength = radiusInner - 20;
                double needleRad = 75 * Math.PI / 180.0;
                int xNeedle = centerX + (int)(needleLength * Math.Cos(needleRad));
                int yNeedle = centerY - (int)(needleLength * Math.Sin(needleRad));
                graphics.DrawLine(needlePen, centerX, centerY, xNeedle, yNeedle);

                // Save the image (output path already bound to the source)
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
 * 1. When a developer needs to generate a 24‑bit BMP image of a semi‑circular gauge for a Windows desktop dashboard widget using C# and Aspose.Imaging.
 * 2. When a C# backend service must create a static gauge graphic on the fly to embed in PDF or HTML reports generated with Aspose libraries.
 * 3. When an IoT monitoring application requires a lightweight BMP gauge indicator that can be rendered programmatically without external image files.
 * 4. When a legacy SCADA system expects a BMP gauge image with precise arc and tick‑mark geometry that can be refreshed automatically via Aspose.Imaging.
 * 5. When a developer wants to export a custom semi‑circular gauge illustration as a BMP file for printing on labels, manuals, or other documentation.
 */