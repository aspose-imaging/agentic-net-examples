// HOW-TO: Create BMP with Rotated Rectangle and Ellipse in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

namespace ImagingNet
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string outputPath = "Output\\output.bmp";
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                BmpOptions options = new BmpOptions();
                options.Source = new FileCreateSource(outputPath, false);

                int width = 400;
                int height = 300;

                using (Image image = Image.Create(options, width, height))
                {
                    Graphics graphics = new Graphics(image);
                    graphics.Clear(Color.White);

                    Pen ellipsePen = new Pen(Color.Blue, 3);
                    Rectangle ellipseRect = new Rectangle(50, 50, 200, 150);
                    graphics.DrawEllipse(ellipsePen, ellipseRect);

                    graphics.RotateTransform(45f);

                    Pen rectPen = new Pen(Color.Red, 3);
                    Rectangle rect = new Rectangle(100, 100, 150, 100);
                    graphics.DrawRectangle(rectPen, rect);

                    image.Save();
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to programmatically generate a BMP diagram that includes an ellipse and a rotated rectangle for a technical report.
 * 2. When creating custom icons or UI assets where shapes must be drawn and rotated before saving as BMP using Aspose.Imaging in C#.
 * 3. When adding rotated annotations or highlights to scanned documents by drawing shapes on a bitmap image.
 * 4. When producing simple game sprites that require precise placement of geometric shapes with rotation applied.
 * 5. When automating the creation of printable graphics, such as labels or badges, that combine basic shapes with rotation in a BMP file.
 */
