// HOW-TO: How to Fill and Outline a Shape with Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
            string outputPath = "output.png";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            int width = 400;
            int height = 400;

            var options = new PngOptions();

            using (Image image = Image.Create(options, width, height))
            {
                Graphics graphics = new Graphics(image);

                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();

                var rect = new RectangleF(50, 50, 300, 300);
                RectangleShape rectangleShape = new RectangleShape(rect);
                figure.AddShape(rectangleShape);
                path.AddFigure(figure);

                using (var brush = new SolidBrush(Color.Yellow))
                {
                    graphics.FillPath(brush, path);
                }

                Pen pen = new Pen(Color.Red, 5);
                graphics.DrawPath(pen, path);

                image.Save(outputPath, options);
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
 * 1. When you need to generate a PNG thumbnail that shows a colored rectangle with a red border for a product catalog.
 * 2. When creating dynamic report graphics where a highlighted area must be both filled and outlined to emphasize data regions.
 * 3. When building a custom UI component that draws a yellow button with a thick red outline on the fly.
 * 4. When exporting diagram elements to PNG files and you require both interior fill and stroke for clear visual separation.
 * 5. When automating batch image processing to add colored overlays with borders to photographs for watermarking purposes.
 */
