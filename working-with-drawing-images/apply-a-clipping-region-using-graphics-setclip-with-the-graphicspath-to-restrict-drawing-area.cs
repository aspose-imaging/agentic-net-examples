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
        string inputPath = @"c:\temp\input.png";
        string outputPath = @"c:\temp\output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                GraphicsPath clipPath = new GraphicsPath();
                Figure clipFigure = new Figure();
                clipFigure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 200f)));
                clipPath.AddFigure(clipFigure);

                Region clipRegion = new Region(clipPath);
                graphics.Clip = clipRegion;

                using (SolidBrush brush = new SolidBrush())
                {
                    brush.Color = Color.Red;
                    brush.Opacity = 100;
                    graphics.FillRectangle(brush, new Rectangle(0, 0, 300, 300));
                }

                PngOptions pngOptions = new PngOptions();
                pngOptions.Source = new FileCreateSource(outputPath, false);
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
 * 1. When a developer needs to generate a PNG thumbnail where only a specific rectangular area of the source image is filled with a solid color, they can use Graphics.SetClip with a GraphicsPath to limit the drawing to that region.
 * 2. When creating a watermark that should appear only inside a defined shape (e.g., a rectangle) on a PNG file, the clipping region ensures the watermark paint does not spill outside the intended bounds.
 * 3. When preparing a printable image where background fill must be confined to a custom region to meet branding guidelines, the code demonstrates how to restrict the fill operation using a Region built from a GraphicsPath.
 * 4. When implementing a custom cropping tool that fills the selected area with a preview color before the user confirms the crop, the SetClip method can be used to apply the fill only inside the selected rectangle.
 * 5. When developing an image‑processing pipeline that needs to overlay a solid red rectangle on top of an existing PNG but only within a specific area to highlight a region of interest, the clipping region created by GraphicsPath provides precise control over the overlay.
 */