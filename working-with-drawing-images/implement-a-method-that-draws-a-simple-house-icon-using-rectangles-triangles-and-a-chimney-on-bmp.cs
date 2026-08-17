// HOW-TO: Draw a Simple House BMP Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output file path
            string outputPath = @"C:\temp\house.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // BMP options with bound source
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create canvas
            using (Image image = Image.Create(bmpOptions, 200, 200))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                Pen blackPen = new Pen(Color.Black, 2);

                // House base
                Rectangle houseRect = new Rectangle(50, 80, 100, 80);
                graphics.DrawRectangle(blackPen, houseRect);
                using (SolidBrush houseBrush = new SolidBrush(Color.LightGray))
                {
                    graphics.FillRectangle(houseBrush, houseRect);
                }

                // Roof (triangle)
                PointF[] roofPoints = new PointF[]
                {
                    new PointF(50, 80),
                    new PointF(150, 80),
                    new PointF(100, 30)
                };
                using (SolidBrush roofBrush = new SolidBrush(Color.Brown))
                {
                    graphics.FillPolygon(roofBrush, roofPoints);
                }
                graphics.DrawPolygon(blackPen, roofPoints);

                // Chimney
                Rectangle chimneyRect = new Rectangle(115, 35, 15, 25);
                graphics.DrawRectangle(blackPen, chimneyRect);
                using (SolidBrush chimneyBrush = new SolidBrush(Color.DarkRed))
                {
                    graphics.FillRectangle(chimneyBrush, chimneyRect);
                }

                // Save the image (bound to source)
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
 * 1. When you need to generate a placeholder house illustration for a real‑estate web app without using external image files.
 * 2. When you want to programmatically create a BMP badge or icon that represents a building in a desktop inventory system.
 * 3. When you must produce a simple vector‑style graphic for PDF reports where the image must be a 24‑bit BMP.
 * 4. When you are testing drawing primitives such as rectangles, polygons, and fills in Aspose.Imaging before implementing more complex UI assets.
 * 5. When you need to embed a custom house symbol into a map tile generated on the server using C#.
 */
