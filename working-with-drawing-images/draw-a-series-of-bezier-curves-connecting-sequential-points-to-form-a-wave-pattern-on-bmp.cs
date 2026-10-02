// HOW-TO: Create a Wave Pattern BMP Using Bezier Curves in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output/wave.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int width = 800;
            int height = 200;

            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            using (RasterImage image = Image.Create(bmpOptions, width, height) as RasterImage)
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                Pen pen = new Pen(Aspose.Imaging.Color.Blue, 2);

                List<Point> points = new List<Point>();
                int waveCount = 5;
                int segmentWidth = width / waveCount;
                for (int i = 0; i <= waveCount; i++)
                {
                    int x = i * segmentWidth;
                    int y = (i % 2 == 0) ? height / 4 : 3 * height / 4;
                    points.Add(new Point(x, y));
                }

                for (int i = 0; i < points.Count - 1; i++)
                {
                    Point start = points[i];
                    Point end = points[i + 1];
                    int ctrlX = (start.X + end.X) / 2;
                    Point ctrl1 = new Point(ctrlX, start.Y);
                    Point ctrl2 = new Point(ctrlX, end.Y);
                    graphics.DrawBezier(pen, start, ctrl1, ctrl2, end);
                }

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
 * 1. When you need to generate a decorative wave overlay on a BMP file for a UI background.
 * 2. When you want to programmatically draw smooth Bezier‑based waveforms for signal‑processing visualizations in a .NET application.
 * 3. When you must create a series of connected curves to simulate water ripples in a bitmap image for a game asset.
 * 4. When you are automating the production of printable wave patterns in BMP format for engineering reports.
 * 5. When you require a simple C# routine that uses Aspose.Imaging to draw scalable vector‑like curves without relying on external graphics libraries.
 */
