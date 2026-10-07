// HOW-TO: Create Anti-Aliased Bezier Curve on BMP Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
            string outputPath = "output/output.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            BmpOptions options = new BmpOptions();
            options.Source = new FileCreateSource(outputPath, false);
            int width = 200;
            int height = 150;

            using (Image image = Image.Create(options, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.SmoothingMode = SmoothingMode.AntiAlias;

                Pen pen = new Pen(Color.Blue, 2);
                graphics.DrawBezier(pen,
                    new Point(10, 10),
                    new Point(50, 0),
                    new Point(80, 100),
                    new Point(120, 50));

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
 * 1. When you need to generate a BMP image with a smooth curved line for a custom UI element or diagram in a .NET application.
 * 2. When you want to produce anti-aliased vector graphics for print-ready BMP files without using GDI+ directly.
 * 3. When you are creating thumbnail previews of hand-drawn signatures or sketches that require smooth Bezier curves.
 * 4. When you need to embed a high-quality curved line into a BMP asset for a game’s 2‑D sprite sheet.
 * 5. When you are automating the generation of technical illustrations (e.g., flow-chart connectors) that must retain smoothness after being saved as BMP.
 */
