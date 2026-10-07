// HOW-TO: Draw a Circle Approximation with Bezier Curves in BMP using C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = "output.bmp";
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            BmpOptions bmpOptions = new BmpOptions();

            using (Image image = Image.Create(bmpOptions, 400, 400))
            {
                Pen pen = new Pen(Aspose.Imaging.Color.Blue, 2);
                Graphics graphics = new Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                float cx = 200f;
                float cy = 200f;
                float r = 150f;
                float k = 0.5522847498f * r;

                // Top-right quadrant
                graphics.DrawBezier(pen,
                    new PointF(cx + r, cy),
                    new PointF(cx + r, cy - k),
                    new PointF(cx + k, cy - r),
                    new PointF(cx, cy - r));

                // Top-left quadrant
                graphics.DrawBezier(pen,
                    new PointF(cx, cy - r),
                    new PointF(cx - k, cy - r),
                    new PointF(cx - r, cy - k),
                    new PointF(cx - r, cy));

                // Bottom-left quadrant
                graphics.DrawBezier(pen,
                    new PointF(cx - r, cy),
                    new PointF(cx - r, cy + k),
                    new PointF(cx - k, cy + r),
                    new PointF(cx, cy + r));

                // Bottom-right quadrant
                graphics.DrawBezier(pen,
                    new PointF(cx, cy + r),
                    new PointF(cx + k, cy + r),
                    new PointF(cx + r, cy + k),
                    new PointF(cx + r, cy));
                
                image.Save(outputPath, bmpOptions);
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
 * 1. When you need to programmatically generate a high‑resolution BMP file containing a smooth circular shape without using rasterized images.
 * 2. When you want to create vector‑like graphics in a bitmap by approximating circles with Bezier curves for precise control over stroke thickness.
 * 3. When you are building a reporting tool that embeds circular diagrams into BMP charts and requires deterministic rendering via Aspose.Imaging.
 * 4. When you need to export custom UI icons or symbols as BMP files and prefer drawing them with code rather than loading pre‑made assets.
 * 5. When you are testing graphic algorithms and need a reproducible BMP image of a circle drawn using the same control‑point math across platforms.
 */
