// HOW-TO: Create BMP With Semi Transparent Shapes Using SourceOver In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            int width = 400;
            int height = 300;

            using (RasterImage image = (RasterImage)Image.Create(bmpOptions, width, height))
            {
                // Clear background to white
                int[] whitePixels = Enumerable.Repeat(Aspose.Imaging.Color.White.ToArgb(), width * height).ToArray();
                image.SaveArgb32Pixels(new Rectangle(0, 0, width, height), whitePixels);

                Graphics graphics = new Graphics(image);

                // Semi‑transparent rectangle
                Pen rectPen = new Pen(Aspose.Imaging.Color.FromArgb(128, 0, 0, 255), 3);
                graphics.DrawRectangle(rectPen, 50, 50, 200, 150);
                using (SolidBrush rectBrush = new SolidBrush(Aspose.Imaging.Color.FromArgb(64, 255, 0, 0)))
                {
                    graphics.FillRectangle(rectBrush, 50, 50, 200, 150);
                }

                // Semi‑transparent ellipse
                Pen ellipsePen = new Pen(Aspose.Imaging.Color.FromArgb(128, 0, 255, 0), 3);
                graphics.DrawEllipse(ellipsePen, 100, 100, 150, 100);
                using (SolidBrush ellipseBrush = new SolidBrush(Aspose.Imaging.Color.FromArgb(64, 0, 0, 255)))
                {
                    graphics.FillEllipse(ellipseBrush, 100, 100, 150, 100);
                }

                // Save the image (output file already bound)
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
 * 1. When you need to generate a BMP report thumbnail that overlays semi‑transparent annotations on a white background.
 * 2. When you want to programmatically add watermark rectangles or ellipses with adjustable opacity to BMP images in a .NET application.
 * 3. When you are building a custom UI component that renders layered graphics, such as progress indicators, directly into a BMP file using Aspose.Imaging.
 * 4. When you must create composite images for printing where the SourceOver mode preserves underlying pixel data while blending translucent shapes.
 * 5. When you are automating the creation of diagrammatic BMP assets, like flow‑chart symbols, that require partially see‑through shapes for visual emphasis.
 */
