// HOW-TO: Shift Drawing Origin With TranslateTransform And Draw Shapes On BMP In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = "output.bmp";

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            BmpOptions options = new BmpOptions();
            options.Source = new FileCreateSource(outputPath, false);

            int width = 200;
            int height = 200;

            using (Image canvas = Image.Create(options, width, height))
            {
                Graphics graphics = new Graphics(canvas);
                graphics.TranslateTransform(50, 30);

                Pen pen = new Pen(Color.Blue, 3);
                graphics.DrawRectangle(pen, 0, 0, 100, 50);

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
 * 1. When you need to offset graphics on a bitmap so that all drawn elements start from a custom origin, such as placing a logo 50 pixels right and 30 pixels down.
 * 2. When generating programmatic reports that require precise positioning of rectangles or other shapes on a BMP image for layout consistency.
 * 3. When creating a simple UI mock‑up where controls are drawn on a canvas and you want to shift the whole coordinate system instead of adjusting each shape individually.
 * 4. When preprocessing images for printing and you must move the drawing area to accommodate printer margins on a BMP file.
 * 5. When building a game map tile where the tile graphics need to be drawn relative to an offset origin to align with a larger world grid.
 */
