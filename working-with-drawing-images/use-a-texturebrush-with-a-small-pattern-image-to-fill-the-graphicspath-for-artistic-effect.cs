// HOW-TO: Apply a Small Pattern Texture to a Shape with Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseImagePath = "base.png";
            string patternImagePath = "pattern.png";
            string outputPath = "output.png";

            if (!File.Exists(baseImagePath))
            {
                Console.Error.WriteLine($"File not found: {baseImagePath}");
                return;
            }
            if (!File.Exists(patternImagePath))
            {
                Console.Error.WriteLine($"File not found: {patternImagePath}");
                return;
            }

            using (RasterImage baseImage = (RasterImage)Image.Load(baseImagePath))
            using (RasterImage patternImage = (RasterImage)Image.Load(patternImagePath))
            {
                Graphics graphics = new Graphics(baseImage);

                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();
                RectangleShape rectShape = new RectangleShape(new RectangleF(50, 50, 200, 200));
                figure.AddShape(rectShape);
                path.AddFigure(figure);

                using (TextureBrush textureBrush = new TextureBrush(patternImage))
                {
                    graphics.FillPath(textureBrush, path);
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                using (PngOptions options = new PngOptions())
                {
                    baseImage.Save(outputPath, options);
                }
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
 * 1. When you need to overlay a decorative pattern onto a specific region of a PNG image, such as adding a tiled background to a logo area.
 * 2. When creating custom UI skins or game assets where a small texture must fill a larger geometric shape without stretching.
 * 3. When generating printable marketing materials that require a repeated watermark or texture inside a defined rectangle.
 * 4. When programmatically applying a fabric or wood‑grain texture to a shape in an image‑processing pipeline using C# and Aspose.Imaging.
 * 5. When building an automated tool that composites multiple images and uses a pattern image as a fill for vector shapes to achieve artistic effects.
 */
