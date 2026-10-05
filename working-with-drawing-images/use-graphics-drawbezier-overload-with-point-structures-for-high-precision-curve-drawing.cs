// HOW-TO: Draw a Bezier Curve on BMP Image Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
        string outputPath = "output\\bezier.bmp";
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
        try
        {
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);
            int width = 400;
            int height = 400;
            using (Image image = Image.Create(bmpOptions, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);
                Pen pen = new Pen(Color.Blue, 2);
                graphics.DrawBezier(pen,
                    new Point(50, 300),
                    new Point(150, 50),
                    new Point(250, 350),
                    new Point(350, 100));
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
 * 1. When you need to generate a high‑resolution BMP file with a smooth custom curve for a technical diagram or illustration.
 * 2. When you want to programmatically add a decorative blue Bezier line to a white background for a branding watermark.
 * 3. When creating dynamic chart graphics where control points define a curve that must be rendered precisely in a bitmap format.
 * 4. When exporting vector‑style paths as raster images for legacy systems that only accept BMP files.
 * 5. When building a CAD‑like preview in a .NET application that requires drawing precise curves using point coordinates.
 */
