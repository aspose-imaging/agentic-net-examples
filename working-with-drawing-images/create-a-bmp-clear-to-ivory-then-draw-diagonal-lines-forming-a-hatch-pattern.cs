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

            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            int width = 500;
            int height = 500;

            using (RasterImage canvas = (RasterImage)Image.Create(bmpOptions, width, height))
            {
                Graphics graphics = new Graphics(canvas);
                graphics.Clear(Color.Ivory);

                Pen pen = new Pen(Color.Black, 1f);

                // Forward diagonal hatch
                for (int offset = -height; offset < width; offset += 20)
                {
                    int x1 = Math.Max(0, offset);
                    int y1 = Math.Max(0, -offset);
                    int x2 = Math.Min(width, offset + height);
                    int y2 = Math.Min(height, height + offset);
                    graphics.DrawLine(pen, new Point(x1, y1), new Point(x2, y2));
                }

                // Backward diagonal hatch
                for (int offset = 0; offset <= width + height; offset += 20)
                {
                    int x1 = Math.Max(0, offset - height);
                    int y1 = Math.Min(height, offset);
                    int x2 = Math.Min(width, offset);
                    int y2 = Math.Max(0, offset - width);
                    graphics.DrawLine(pen, new Point(x1, y1), new Point(x2, y2));
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
 * 1. When a developer needs to generate a 500 × 500 BMP background with an ivory fill and a diagonal hatch pattern for use as a printable watermark in a .NET reporting application.
 * 2. When a C# program must create a simple bitmap texture with black diagonal lines for tiling in a game engine that relies on BMP assets processed by Aspose.Imaging.
 * 3. When an automation script has to produce a high‑contrast hatch overlay on an ivory canvas to serve as a placeholder image in a document‑generation workflow.
 * 4. When a Windows desktop utility requires dynamically drawing a cross‑hatched pattern onto a BMP file to indicate a disabled or unavailable UI element.
 * 5. When a batch image‑processing tool needs to programmatically generate BMP files with a custom hatch pattern for use as background layers in architectural blueprint visualizations.
 */