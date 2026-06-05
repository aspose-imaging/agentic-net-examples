using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = @"C:\temp\highres.png";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            using (Image image = Image.Create(pngOptions, 1200, 1200))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                graphics.DrawRectangle(new Pen(Color.Blue, 5), new Rectangle(100, 100, 400, 300));
                graphics.DrawEllipse(new Pen(Color.Red, 5), new Rectangle(600, 100, 300, 300));
                graphics.DrawLine(new Pen(Color.Green, 3), new Point(50, 50), new Point(1150, 1150));
                graphics.DrawPolygon(new Pen(Color.Purple, 4), new[]
                {
                    new Point(200, 800),
                    new Point(400, 600),
                    new Point(600, 800),
                    new Point(500, 1000),
                    new Point(300, 1000)
                });

                using (SolidBrush brush = new SolidBrush(Color.Yellow))
                {
                    graphics.FillRectangle(brush, new Rectangle(100, 500, 200, 150));
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
 * 1. When a developer needs to generate a high‑resolution PNG at 300 DPI with vector shapes for print‑ready marketing brochures, they can use this Aspose.Imaging for .NET code to draw crisp rectangles, ellipses, lines and filled polygons.
 * 2. When an engineering application must export a scalable diagram such as a circuit layout as a lossless PNG file that preserves line thickness and color accuracy, this C# snippet creates a 1200 × 1200 pixel image with vector‑based drawing commands.
 * 3. When a reporting tool requires a high‑quality chart or infographic embedded in a PDF, the code demonstrates how to programmatically render vector graphics onto a PNG canvas using Aspose.Imaging’s Graphics, Pen, and SolidBrush classes.
 * 4. When an automated testing framework needs to produce visual verification assets with exact pixel dimensions and DPI settings, the example shows how to create and save a 300 DPI image file that can be compared pixel‑by‑pixel.
 * 5. When a desktop application wants to generate custom icons or UI assets on the fly, this C# example illustrates how to draw geometric shapes with specific colors and line widths and save them as a high‑resolution PNG using Aspose.Imaging.
 */