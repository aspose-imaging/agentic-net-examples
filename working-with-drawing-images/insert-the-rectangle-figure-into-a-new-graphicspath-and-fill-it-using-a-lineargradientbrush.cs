// HOW-TO: Create Gradient Filled Rectangle in PNG Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
            string outputPath = "output/output.png";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            PngOptions options = new PngOptions();

            using (RasterImage image = (RasterImage)Image.Create(options, 400, 300))
            {
                Graphics graphics = new Graphics(image);

                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();
                RectangleShape rectShape = new RectangleShape(new RectangleF(50, 50, 300, 200));
                figure.AddShape(rectShape);
                path.AddFigure(figure);

                using (LinearGradientBrush brush = new LinearGradientBrush(new RectangleF(50, 50, 300, 200), Color.Blue, Color.Red, 0, false))
                {
                    graphics.FillPath(brush, path);
                }

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
 * 1. When you need to generate a PNG badge with a blue‑to‑red gradient rectangle using Aspose.Imaging in C#.
 * 2. When creating dynamic report graphics that require a gradient‑filled rectangular background drawn with a GraphicsPath.
 * 3. When producing custom UI icons where a LinearGradientBrush is used to fill a rectangle shape in a PNG file.
 * 4. When automating marketing banners that need a gradient rectangle overlay on a blank canvas via Aspose.Imaging.
 * 5. When building a server‑side image service that returns PNG images with gradient shapes for PDFs or email templates.
 */
