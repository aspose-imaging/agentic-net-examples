// HOW-TO: Create 800x600 BMP Canvas and Draw Red Ellipse in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            Source source = new FileCreateSource(outputPath, false);
            BmpOptions options = new BmpOptions { Source = source };

            using (RasterImage canvas = (RasterImage)Image.Create(options, 800, 600))
            {
                Graphics graphics = new Graphics(canvas);
                Pen pen = new Pen(Color.Red);
                graphics.DrawEllipse(pen, new Rectangle(0, 0, 800, 600));
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
 * 1. When you need to programmatically generate an 800 × 600 BMP image with a red ellipse for a placeholder or watermark in a C# application.
 * 2. When creating dynamic graphics for reports or dashboards that require a simple red ellipse drawn on a bitmap canvas using Aspose.Imaging.
 * 3. When automating test image production to verify image‑processing pipelines that expect a BMP file containing a known red ellipse shape.
 * 4. When building a custom UI component in a .NET desktop app that draws a red ellipse on a canvas for visual feedback or branding.
 * 5. When exporting a programmatically drawn shape to BMP format for compatibility with legacy systems that only accept BMP files.
 */
