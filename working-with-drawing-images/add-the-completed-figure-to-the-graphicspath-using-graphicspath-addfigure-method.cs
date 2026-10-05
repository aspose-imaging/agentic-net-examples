// HOW-TO: Add a Figure to GraphicsPath and Draw Rectangle in BMP with C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = "output\\result.bmp";
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            int width = 400;
            int height = 300;

            using (var bmpOptions = new BmpOptions())
            {
                bmpOptions.Source = new FileCreateSource(outputPath, false);
                using (RasterImage image = (RasterImage)Image.Create(bmpOptions, width, height))
                {
                    Graphics graphics = new Graphics(image);
                    graphics.Clear(Color.White);

                    GraphicsPath path = new GraphicsPath();
                    Figure figure = new Figure();

                    RectangleF rect = new RectangleF(50, 50, 200, 150);
                    RectangleShape rectShape = new RectangleShape(rect);
                    figure.AddShape(rectShape);

                    path.AddFigure(figure);

                    Pen pen = new Pen(Color.Blue, 3);
                    graphics.DrawPath(pen, path);

                    image.Save();
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
 * 1. When you need to programmatically generate a BMP file with a custom rectangle outline using Aspose.Imaging in C#.
 * 2. When you want to add complex vector figures to a GraphicsPath before rendering them onto a raster image.
 * 3. When you must create a blank canvas, clear it to a solid background, and draw shapes with specific pen thickness and color.
 * 4. When you are building a server‑side service that produces diagrammatic images such as forms or schematics on the fly.
 * 5. When you require precise control over the placement and dimensions of shapes in a bitmap for automated report graphics.
 */
