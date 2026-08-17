// HOW-TO: Shift Drawing Origin with TranslateTransform and Draw Shapes on BMP in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = @"c:\temp\translated_output.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            var source = new FileCreateSource(outputPath, false);
            var bmpOptions = new BmpOptions() { Source = source, BitsPerPixel = 24 };
            using (Aspose.Imaging.Image canvas = Aspose.Imaging.Image.Create(bmpOptions, 500, 500))
            {
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(canvas);
                graphics.Clear(Aspose.Imaging.Color.White);
                graphics.TranslateTransform(50f, 50f);
                graphics.DrawRectangle(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Blue, 2),
                    new Aspose.Imaging.Rectangle(0, 0, 150, 100));
                graphics.DrawEllipse(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Red, 2),
                    new Aspose.Imaging.Rectangle(200, 0, 100, 100));
                using (SolidBrush brush = new SolidBrush())
                {
                    brush.Color = Aspose.Imaging.Color.Green;
                    brush.Opacity = 100;
                    graphics.FillRectangle(brush, new Aspose.Imaging.Rectangle(0, 150, 200, 80));
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
 * 1. When you need to create a BMP image with multiple shapes positioned relative to a custom origin point.
 * 2. When you want to generate a report graphic that requires offsetting the coordinate system before drawing rectangles, ellipses, and filled areas.
 * 3. When you are building a thumbnail generator that must place watermarks or overlays at a specific offset on a 500 × 500 bitmap.
 * 4. When you need to programmatically produce a printable layout where all drawing commands share a common translation for consistent margins.
 * 5. When you are automating UI mock‑ups and need to shift the canvas origin to simplify the placement of vector shapes in C# using Aspose.Imaging.
 */
