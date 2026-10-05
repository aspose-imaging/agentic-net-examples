// HOW-TO: Widen Graphics Path By 3 Pixels Using Pen For Hit Testing In C# (Aspose.Imaging for .NET)
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
        string inputPath = "input.png";
        string outputPath = "output/output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                Graphics graphics = new Graphics(image);

                GraphicsPath path = new GraphicsPath();

                Figure figure = new Figure();
                figure.AddShape(new RectangleShape(new RectangleF(50, 50, 100, 100)));
                path.AddFigure(figure);

                Pen pen = new Pen(Color.Black, 3);
                path.Widen(pen);

                using (var brush = new SolidBrush(Color.FromArgb(128, 255, 0, 0)))
                {
                    graphics.FillPath(brush, path);
                }

                var saveOptions = new PngOptions();
                image.Save(outputPath, saveOptions);
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
 * 1. When you need to increase the clickable area around a shape for accurate mouse hit testing in a PNG image.
 * 2. When you want to create a semi‑transparent colored overlay that follows a widened rectangle border in a raster image.
 * 3. When you must generate a thicker outline around a region to improve visual emphasis before saving as PNG.
 * 4. When you are building a custom UI component that requires expanding a path’s stroke width for better touch target detection.
 * 5. When you need to programmatically enlarge a shape’s boundary by a few pixels to accommodate anti‑aliasing or printing tolerances.
 */
