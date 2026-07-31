using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input\\sample.png";
        string outputPath = "output\\result.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                Graphics graphics = new Graphics(raster);

                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();
                figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 150f)));
                path.AddFigure(figure);

                Pen widenPen = new Pen(Color.Blue, 3);
                path.Widen(widenPen);

                Pen drawPen = new Pen(Color.Red, 1);
                graphics.DrawPath(drawPen, path);

                PngOptions pngOptions = new PngOptions();
                raster.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to increase the clickable area of a rectangular UI element in a PNG image by three pixels for more forgiving hit testing, they can use the Widen method with a thick Pen as shown.
 * 2. When a developer wants to generate a visual guide that highlights the expanded boundary of a shape in a raster image for debugging layout issues, they can widen the GraphicsPath and draw it with a contrasting pen.
 * 3. When a developer is preparing a PNG asset for a game and must ensure that touch targets are at least three pixels larger than the original shape to meet accessibility guidelines, the code can widen the path before saving.
 * 4. When a developer needs to create a mask image where the stroke width of a rectangle is increased for later compositing or clipping operations, using Widen with a Pen of width 3 achieves the required thickness.
 * 5. When a developer is implementing custom image annotation tools that require a thicker selection outline for better visibility on high‑resolution screenshots, the Widen method expands the path and the result is saved as a PNG file.
 */