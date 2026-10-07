// HOW-TO: Draw Cubic Bezier Curve on BMP Image Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            var bmpOptions = new BmpOptions
            {
                BitsPerPixel = 32
            };

            using (var image = Aspose.Imaging.Image.Create(bmpOptions, 400, 400))
            {
                var graphics = new Aspose.Imaging.Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                var graphicsPath = new Aspose.Imaging.GraphicsPath();

                var figure = new Aspose.Imaging.Figure();

                var bezierShape = new BezierShape(new[]
                {
                    new Aspose.Imaging.PointF(50, 300),
                    new Aspose.Imaging.PointF(150, 100),
                    new Aspose.Imaging.PointF(250, 300),
                    new Aspose.Imaging.PointF(350, 100)
                });

                figure.AddShape(bezierShape);
                graphicsPath.AddFigure(figure);

                var pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Blue, 2);
                graphics.DrawPath(pen, graphicsPath);

                image.Save(outputPath);
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
 * 1. When you need to generate a BMP file with a custom smooth curve for a diagram or UI element in a C# application.
 * 2. When you want to programmatically add a cubic Bezier shape to an image for creating vector‑based graphics without using external design tools.
 * 3. When you need to render precise control‑point curves on a white background for testing rendering performance of Aspose.Imaging.
 * 4. When you are building a reporting tool that draws scalable curves onto bitmap charts or signatures in .NET.
 * 5. When you require automated creation of decorative wave patterns in BMP format for game assets or marketing banners using C#.
 */
