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
        try
        {
            string outputPath = @"C:\temp\output.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            Source source = new FileCreateSource(outputPath, false);
            BmpOptions options = new BmpOptions() { Source = source };

            using (Image image = Image.Create(options, 400, 300))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.LightBlue);

                Pen borderPen = new Pen(Color.Black, 2);

                using (SolidBrush brush1 = new SolidBrush(Color.FromArgb(128, 255, 0, 0)))
                {
                    Rectangle rect1 = new Rectangle(50, 50, 200, 150);
                    graphics.FillRectangle(brush1, rect1);
                    graphics.DrawRectangle(borderPen, rect1);
                }

                using (SolidBrush brush2 = new SolidBrush(Color.FromArgb(128, 0, 255, 0)))
                {
                    Rectangle rect2 = new Rectangle(150, 100, 200, 150);
                    graphics.FillRectangle(brush2, rect2);
                    graphics.DrawRectangle(borderPen, rect2);
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
 * 1. When a developer needs to generate a BMP report background with a light‑blue canvas and overlay semi‑transparent colored zones to highlight data regions.
 * 2. When creating a simple map legend image in C# where overlapping translucent rectangles indicate different zones on a light‑blue BMP map.
 * 3. When producing a thumbnail for a UI component that requires a light‑blue placeholder with semi‑transparent red and green overlays to demonstrate layering effects.
 * 4. When building a test image for automated visual regression testing that must contain a known background color and overlapping alpha‑blended rectangles in BMP format.
 * 5. When designing a printable badge template in .NET where a light‑blue BMP base is cleared and semi‑transparent colored blocks are drawn to show where logos or text will be placed.
 */