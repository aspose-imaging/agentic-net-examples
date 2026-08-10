// HOW-TO: Create BMP Progress Ring with Nested Arcs Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
            string outputPath = "output\\progress_ring.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            Source source = new FileCreateSource(outputPath, false);
            BmpOptions options = new BmpOptions() { Source = source };
            int width = 400;
            int height = 400;
            using (RasterImage canvas = (RasterImage)Image.Create(options, width, height))
            {
                Graphics graphics = new Graphics(canvas);
                graphics.Clear(Color.White);
                int centerX = width / 2;
                int centerY = height / 2;
                int maxRadius = Math.Min(width, height) / 2 - 10;
                int arcThickness = 20;
                int arcCount = 5;
                for (int i = 0; i < arcCount; i++)
                {
                    int radius = maxRadius - i * (arcThickness + 5);
                    if (radius <= 0) break;
                    Rectangle rect = new Rectangle(centerX - radius, centerY - radius, radius * 2, radius * 2);
                    Color penColor = Color.FromArgb(255, 255 - i * 40, i * 40);
                    Pen pen = new Pen(penColor, arcThickness);
                    graphics.DrawArc(pen, rect, 0, 270);
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
 * 1. When you need to generate a BMP file that visualizes download or processing progress as a multi‑layered ring in a desktop application.
 * 2. When you want to programmatically create custom progress indicators for dashboards without relying on external image assets.
 * 3. When you need to produce a series of concentric arcs with different colors for a status‑monitoring UI component in C#.
 * 4. When you are building a reporting tool that embeds a simple animated‑looking progress ring into generated BMP charts.
 * 5. When you require a lightweight way to draw vector‑style progress graphics directly onto a bitmap for printing or legacy systems.
 */
