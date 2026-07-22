using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = @"c:\temp\output.psd";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            PsdOptions psdOptions = new PsdOptions();
            psdOptions.ColorMode = ColorModes.Indexed;
            psdOptions.CompressionMethod = CompressionMethod.RLE;
            psdOptions.ChannelBitsCount = 8;
            psdOptions.ChannelsCount = 1;
            psdOptions.Palette = new ColorPalette(new Color[]
            {
                Color.Red,
                Color.Green,
                Color.Blue,
                Color.White,
                Color.Black
            });
            psdOptions.Source = new FileCreateSource(outputPath, false);

            int width = 800;
            int height = 600;

            using (Image image = Image.Create(psdOptions, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.Red);

                Pen blackPen = new Pen(Color.Black, 2);

                graphics.DrawRectangle(blackPen, new Rectangle(50, 50, 300, 200));
                graphics.DrawEllipse(blackPen, new Rectangle(400, 50, 200, 150));
                graphics.DrawLine(blackPen, new Point(100, 300), new Point(700, 300));
                graphics.DrawArc(blackPen, new Rectangle(200, 350, 200, 200), 0, 180);
                graphics.DrawPie(blackPen, new Rectangle(450, 350, 200, 200), 45, 90);
                Point[] polygonPoints = new Point[]
                {
                    new Point(600, 100),
                    new Point(750, 150),
                    new Point(700, 250),
                    new Point(550, 200)
                };
                graphics.DrawPolygon(blackPen, polygonPoints);

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
 * 1. When a developer needs to generate a PSD file with an indexed color palette for a web‑based design tool that overlays basic geometric shapes on a background.
 * 2. When creating thumbnail previews of Photoshop documents in a batch process, using Aspose.Imaging to draw rectangles, ellipses and lines on an indexed canvas before saving as a compressed PSD.
 * 3. When building a C# application that programmatically adds vector‑style annotations (borders, circles, arrows) to a PSD template for automated report generation.
 * 4. When exporting diagrammatic illustrations (flowcharts, UI mockups) directly to a PSD file with RLE compression and a limited palette to keep file size low.
 * 5. When integrating a graphics engine that needs to render simple shapes onto a PSD layer for later editing in Photoshop, using Aspose.Imaging’s Graphics API with indexed colors.
 */