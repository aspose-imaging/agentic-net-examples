// HOW-TO: Create BMP Gauge Indicator With Multiple Arcs In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = "output/gauge.bmp";
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            Source source = new FileCreateSource(outputPath, false);
            BmpOptions options = new BmpOptions() { Source = source };
            int width = 400;
            int height = 200;

            using (RasterImage canvas = (RasterImage)Image.Create(options, width, height))
            {
                Graphics graphics = new Graphics(canvas);
                graphics.Clear(Color.White);

                Pen pen = new Pen(Color.Blue, 5);

                int centerX = width / 2;
                int centerY = height;

                Rectangle outerRect = new Rectangle(centerX - 150, centerY - 150, 300, 300);
                graphics.DrawArc(pen, outerRect, 180, 180);

                Rectangle middleRect = new Rectangle(centerX - 120, centerY - 120, 240, 240);
                graphics.DrawArc(pen, middleRect, 180, 180);

                Rectangle innerRect = new Rectangle(centerX - 90, centerY - 90, 180, 180);
                graphics.DrawArc(pen, innerRect, 180, 180);

                Pen tickPen = new Pen(Color.Black, 2);
                for (int angle = 180; angle <= 360; angle += 30)
                {
                    double rad = angle * Math.PI / 180.0;
                    int rOuter = 150;
                    int rInner = 130;
                    int x1 = centerX + (int)(rOuter * Math.Cos(rad));
                    int y1 = centerY + (int)(rOuter * Math.Sin(rad));
                    int x2 = centerX + (int)(rInner * Math.Cos(rad));
                    int y2 = centerY + (int)(rInner * Math.Sin(rad));
                    graphics.DrawLine(tickPen, x1, y1, x2, y2);
                }

                canvas.Save();
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
 * 1. When you need to programmatically generate a BMP speedometer or gauge image for a Windows desktop dashboard.
 * 2. When you want to draw custom semi‑circular meter graphics with tick marks for a monitoring application.
 * 3. When you must create a lightweight BMP file containing multiple concentric arcs for printing or embedded UI components.
 * 4. When you require a reproducible gauge illustration that can be saved directly to disk without using external drawing tools.
 * 5. When you are building a C# reporting tool that needs to render circular progress indicators as BMP assets on the fly.
 */
