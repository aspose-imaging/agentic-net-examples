using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "clipped_output.png";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);
            using (Image image = Image.Create(pngOptions, 400, 400))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.LightGray);
                GraphicsPath clipPath = new GraphicsPath();
                Figure clipFigure = new Figure();
                clipFigure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 300f, 300f)));
                clipPath.AddFigure(clipFigure);
                graphics.Clip = new Region(clipPath);
                graphics.DrawRectangle(new Pen(Color.Red, 5), new Rectangle(0, 0, 400, 400));
                using (SolidBrush brush = new SolidBrush(Color.Blue))
                {
                    graphics.FillEllipse(brush, new RectangleF(0f, 0f, 400f, 400f));
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
 * 1. When generating a PNG thumbnail where only a central square should contain the image content, a developer can use Graphics.SetClip with a GraphicsPath to limit drawing to that region and prevent overflow.
 * 2. When creating a custom badge or logo that requires a circular pattern confined inside a rectangular border, the clipping region ensures the ellipse is drawn only within the defined rectangle.
 * 3. When producing printable PDFs or raster images that need a watermark applied only to a specific area, the code demonstrates how to restrict the fill operation to a clipping path using Aspose.Imaging for .NET.
 * 4. When building a UI component that renders a progress ring but must not draw outside the component’s bounds, the SetClip method with a GraphicsPath can enforce the drawing limits in a 400×400 PNG canvas.
 * 5. When developing an image processing pipeline that overlays colored shapes on a background while preserving a transparent margin, the clipping region defined by a GraphicsPath guarantees that the overlay respects the margin.
 */