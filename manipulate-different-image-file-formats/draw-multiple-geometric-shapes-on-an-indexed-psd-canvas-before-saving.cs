// HOW-TO: Create Indexed PSD with Shapes Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.psd";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int width = 800;
            int height = 600;

            Aspose.Imaging.Color[] paletteColors = new Aspose.Imaging.Color[256];
            for (int i = 0; i < 256; i++)
            {
                byte v = (byte)i;
                paletteColors[i] = Aspose.Imaging.Color.FromArgb(255, v, v, v);
            }
            var palette = new ColorPalette(paletteColors);

            PsdOptions options = new PsdOptions();
            options.Source = new FileCreateSource(outputPath, false);
            options.ColorMode = ColorModes.Indexed;
            options.Palette = palette;
            options.ChannelsCount = (short)1;
            options.ChannelBitsCount = (short)8;
            options.Version = 5;

            using (var psd = Image.Create(options, width, height) as RasterImage)
            {
                Graphics graphics = new Graphics(psd);
                graphics.Clear(Aspose.Imaging.Color.White);

                Pen penRect = new Pen(Aspose.Imaging.Color.Red, 3);
                graphics.DrawRectangle(penRect, new Rectangle(50, 50, 200, 150));

                using (var brushEllipse = new SolidBrush(Aspose.Imaging.Color.Blue))
                {
                    graphics.FillEllipse(brushEllipse, new Rectangle(300, 100, 200, 150));
                }

                Pen penLine = new Pen(Aspose.Imaging.Color.Green, 2);
                graphics.DrawLine(penLine, new Point(100, 300), new Point(700, 500));

                Point[] polygonPoints = new Point[]
                {
                    new Point(400, 300),
                    new Point(500, 350),
                    new Point(450, 450),
                    new Point(350, 450),
                    new Point(300, 350)
                };
                Pen penPoly = new Pen(Aspose.Imaging.Color.Yellow, 2);
                graphics.DrawPolygon(penPoly, polygonPoints);

                psd.Save();
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
 * 1. When you need to generate a PSD file with a limited color palette for web‑compatible mockups that include rectangles, ellipses and lines.
 * 2. When you want to programmatically add vector‑style graphics to an indexed Photoshop document for automated report generation.
 * 3. When a batch process must create thumbnail previews with simple geometric annotations inside a PSD that uses 8‑bit indexed colors.
 * 4. When integrating a design workflow that requires drawing shapes on a PSD canvas before exporting to other Adobe tools.
 * 5. When building a C# application that produces layered PSD assets with custom palettes for game UI assets or marketing banners.
 */
