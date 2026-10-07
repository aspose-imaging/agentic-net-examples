// HOW-TO: Create High DPI BMP With Custom Resolution And Draw Shapes In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output/high_dpi.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            BmpOptions options = new BmpOptions
            {
                Source = new FileCreateSource(outputPath, false)
            };

            using (RasterImage image = (RasterImage)Image.Create(options, 800, 600))
            {
                image.HorizontalResolution = 300;
                image.VerticalResolution = 300;

                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                Pen pen = new Pen(Color.Black, 5);
                graphics.DrawRectangle(pen, new Rectangle(100, 100, 200, 150));
                graphics.DrawEllipse(pen, new Rectangle(350, 100, 200, 150));

                using (SolidBrush brush = new SolidBrush(Color.LightBlue))
                {
                    graphics.FillRectangle(brush, new Rectangle(100, 300, 200, 150));
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
 * 1. When generating printable graphics for brochures, a developer can create a 300 dpi BMP and draw rectangles, ellipses, and filled areas programmatically.
 * 2. When preparing high‑resolution assets for a Windows desktop application, you can set the image’s horizontal and vertical resolution before saving it as BMP.
 * 3. When automating the production of engineering diagrams that require precise DPI settings, this code lets you define the resolution and render vector‑like shapes onto a raster bitmap.
 * 4. When converting design mockups into bitmap files for legacy systems that only accept BMP, you can control the DPI and add custom graphics using Aspose.Imaging.
 * 5. When building a server‑side service that generates custom high‑DPI BMP thumbnails with shapes for printing pipelines, this approach ensures the output meets the required resolution standards.
 */
