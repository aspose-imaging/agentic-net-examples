using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            string outputPath = @"c:\temp\output.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            FileCreateSource src = new FileCreateSource(outputPath, false);
            bmpOptions.Source = src;

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(bmpOptions, 500, 500))
            {
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.Wheat);

                Aspose.Imaging.Pen bluePen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Blue, 5);
                graphics.DrawRectangle(bluePen, new Aspose.Imaging.Rectangle(50, 50, 200, 200));

                graphics.Clip = new Aspose.Imaging.Region(new Aspose.Imaging.Rectangle(100, 100, 150, 150));

                Aspose.Imaging.Pen redPen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Red, 5);
                graphics.DrawRectangle(redPen, new Aspose.Imaging.Rectangle(80, 80, 300, 300));

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
 * 1. When a developer needs to generate a BMP file and draw a highlighted area while preventing drawing outside a specific region, such as creating a printable form template with a bounded signature box.
 * 2. When an application must overlay graphics on an existing bitmap and clip subsequent drawing to a defined rectangle, for example adding watermarks that should only appear within a logo area.
 * 3. When building a UI component that visualizes selection boundaries by drawing a rectangle and then restricting further drawing to the selected region, like a cropping tool preview in a photo editor.
 * 4. When generating diagnostic images that show both an outer boundary and an inner clipped region to illustrate clipping behavior for debugging graphics pipelines in C#.
 * 5. When creating a custom badge or label in BMP format where the outer frame is drawn first and inner decorative elements are confined to a specific area using Graphics.SetClip.
 */