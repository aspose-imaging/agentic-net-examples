// HOW-TO: Create Indexed PSD With Shapes Using Aspose.Imaging In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = @"C:\temp\output.psd";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure PSD options for an indexed image
            PsdOptions psdOptions = new PsdOptions();
            psdOptions.Source = new FileCreateSource(outputPath, false);
            psdOptions.ColorMode = ColorModes.Indexed;
            psdOptions.CompressionMethod = CompressionMethod.RLE;
            psdOptions.Version = 5;

            // Define a simple palette (max 256 colors)
            Color[] paletteColors = new Color[]
            {
                Color.Black,
                Color.White,
                Color.Red,
                Color.Green,
                Color.Blue,
                Color.Yellow,
                Color.Cyan,
                Color.Magenta
            };
            psdOptions.Palette = new ColorPalette(paletteColors);

            // Create the PSD canvas
            using (Image image = Image.Create(psdOptions, 500, 500))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.Wheat);

                // Rectangle outline
                graphics.DrawRectangle(new Pen(Color.Red, 2), new Rectangle(50, 50, 200, 150));

                // Filled ellipse
                using (SolidBrush brush = new SolidBrush(Color.Blue))
                {
                    graphics.FillEllipse(brush, new Rectangle(300, 50, 150, 100));
                }

                // Diagonal line
                graphics.DrawLine(new Pen(Color.Green, 3), new Point(100, 300), new Point(400, 300));

                // Polygon
                Point[] polygonPoints = new Point[]
                {
                    new Point(250, 350),
                    new Point(300, 400),
                    new Point(350, 350),
                    new Point(300, 300)
                };
                graphics.DrawPolygon(new Pen(Color.Purple, 2), polygonPoints);

                // Filled rectangle
                using (SolidBrush fillBrush = new SolidBrush(Color.Orange))
                {
                    graphics.FillRectangle(fillBrush, new Rectangle(50, 350, 100, 100));
                }

                // Save the PSD (output path already bound)
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
 * 1. When you need to generate a PSD file with a limited 256‑color palette for a web‑based design tool that draws rectangles, ellipses, lines, and polygons programmatically in C#.
 * 2. When an automated report generator must embed simple vector graphics into an indexed Photoshop document for consistent branding across multiple pages.
 * 3. When a game asset pipeline requires creating thumbnail PSDs with basic shapes while keeping file size low using RLE compression and indexed colors.
 * 4. When a batch‑processing script has to add geometric annotations to existing PSD layers without converting the image to full‑color mode.
 * 5. When a digital publishing system needs to produce PSD templates with predefined shapes that can later be edited by designers in Photoshop.
 */
