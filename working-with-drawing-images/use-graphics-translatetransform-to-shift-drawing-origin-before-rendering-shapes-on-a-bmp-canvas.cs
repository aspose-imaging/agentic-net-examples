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
        string outputPath = "output/output.bmp";

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            Source source = new FileCreateSource(outputPath, false);
            BmpOptions bmpOptions = new BmpOptions() { Source = source };
            int width = 400;
            int height = 300;

            using (RasterImage canvas = (RasterImage)Image.Create(bmpOptions, width, height))
            {
                Graphics graphics = new Graphics(canvas);
                graphics.Clear(Color.LightGray);
                graphics.TranslateTransform(50, 30);
                Pen rectPen = new Pen(Color.Blue, 2);
                graphics.DrawRectangle(rectPen, new Rectangle(0, 0, 200, 150));
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(128, Color.Red)))
                {
                    graphics.FillEllipse(brush, new Rectangle(0, 0, 200, 150));
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
 * 1. When a developer needs to create a BMP image with a consistent left‑top margin, they can use Graphics.TranslateTransform to shift the drawing origin before drawing rectangles and ellipses.
 * 2. When adding a semi‑transparent overlay (e.g., a red ellipse) to a BMP background and want to position it with an offset, TranslateTransform lets the code render the shape at the desired coordinates.
 * 3. When generating a simple diagram or badge on a BMP canvas and all elements must be placed 50 px right and 30 px down, using TranslateTransform simplifies the coordinate calculations.
 * 4. When producing a thumbnail preview of a larger design in BMP format and need to apply padding around the content, shifting the origin with TranslateTransform ensures the shapes are centered within the padded area.
 * 5. When building a BMP sprite sheet where each sprite is drawn with the same offset to align within a grid, TranslateTransform moves the origin so each sprite’s rectangle and ellipse are positioned correctly.
 */