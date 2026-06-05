using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = @"c:\temp\clipped_output.png";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(pngOptions, 400, 400))
            {
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                graphics.DrawRectangle(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Red, 5), new Aspose.Imaging.Rectangle(0, 0, 400, 400));

                using (SolidBrush brush = new SolidBrush())
                {
                    brush.Color = Aspose.Imaging.Color.Blue;
                    brush.Opacity = 100;
                    graphics.FillEllipse(brush, new Aspose.Imaging.Rectangle(100, 100, 200, 200));
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
 * 1. When a developer needs to generate a PNG thumbnail that shows only a circular portion of a larger image, they can use Graphics.SetClip with a circular GraphicsPath to restrict drawing to that area.
 * 2. When creating a PDF report that includes a watermark but the watermark must not overlap the header region, a rectangular GraphicsPath applied via SetClip ensures the watermark is drawn only within the allowed bounds.
 * 3. When rendering a map tile in a web‑mapping application and only a polygonal region of interest should be filled with a semi‑transparent brush, SetClip with a polygon GraphicsPath keeps the fill confined to the tile’s shape.
 * 4. When producing a product label image where a barcode must stay inside a predefined rectangular zone, using Graphics.SetClip prevents the barcode drawing code from spilling into adjacent label sections.
 * 5. When implementing a custom chart control that draws data series only inside the plot area while leaving axis labels untouched, a clipping region created with GraphicsPath and applied via SetClip keeps all series rendering within the chart’s plot rectangle.
 */