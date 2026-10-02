// HOW-TO: Create High Resolution BMP With Vector Shapes In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output/output.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            int width = 800;
            int height = 600;

            BmpOptions options = new BmpOptions();
            options.Source = new FileCreateSource(outputPath, false);

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(options, width, height))
            {
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                Aspose.Imaging.Pen penBlue = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Blue, 5);
                graphics.DrawRectangle(penBlue, 50, 50, 200, 150);

                using (SolidBrush redBrush = new SolidBrush(Aspose.Imaging.Color.Red))
                {
                    graphics.FillEllipse(redBrush, 100, 100, 150, 100);
                }

                Aspose.Imaging.Pen penGreen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Green, 3);
                graphics.DrawLine(penGreen, 0, 0, width, height);

                Aspose.Imaging.Point[] points = new Aspose.Imaging.Point[]
                {
                    new Aspose.Imaging.Point(10, 10),
                    new Aspose.Imaging.Point(200, 20),
                    new Aspose.Imaging.Point(150, 200)
                };
                graphics.DrawPolygon(penBlue, points);

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
 * 1. To programmatically generate a blank BMP file and draw basic vector shapes such as rectangles, ellipses, lines, and polygons for dynamic graphics in a C# application.
 * 2. To create a high‑resolution image that can be saved directly to disk without intermediate files, useful for automated report generation or batch image processing.
 * 3. To render crisp, scalable graphics on a bitmap when preparing assets for printing or exporting to other formats like PNG or PDF.
 * 4. To integrate custom drawing logic into a server‑side service that produces on‑the‑fly diagrams or charts for web APIs.
 * 5. To replace manual design tools with code‑driven drawing for consistent branding elements across multiple generated images.
 */
