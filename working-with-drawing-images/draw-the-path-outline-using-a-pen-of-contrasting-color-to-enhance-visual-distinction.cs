// HOW-TO: Draw Rectangle Outline With Red Pen On PNG Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.png";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            var pngOptions = new PngOptions();
            using (Image image = Image.Create(pngOptions, 400, 300))
            {
                var graphics = new Graphics(image);
                graphics.Clear(Color.White);

                var path = new GraphicsPath();
                var figure = new Figure();

                var rect = new RectangleF(50, 50, 300, 200);
                var rectangleShape = new RectangleShape(rect);
                figure.AddShape(rectangleShape);
                path.AddFigure(figure);

                var pen = new Pen(Color.Red, 5);
                graphics.DrawPath(pen, path);

                image.Save(outputPath, pngOptions);
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
 * 1. When you need to generate a PNG image with a red rectangle border to highlight a specific area in a UI overlay, this code creates the outline using Aspose.Imaging in C#.
 * 2. When producing printable reports that require a colored frame around charts or diagrams, the example draws a red rectangular outline on a PNG canvas.
 * 3. When building a web API that returns images with a highlighted selection region, the code shows how to draw a red pen outline around a rectangle using Aspose.Imaging.
 * 4. When automating marketing asset creation where a product must be emphasized with a contrasting border, this snippet adds a red rectangle outline to a PNG file.
 * 5. When developing a computer‑vision debugging tool that visualizes detected objects, the example draws a red rectangle outline around the area of interest on a PNG image.
 */
