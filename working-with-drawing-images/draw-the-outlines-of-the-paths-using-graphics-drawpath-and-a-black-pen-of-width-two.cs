// HOW-TO: Draw Rectangle and Ellipse Outlines on BMP with Aspose.Imaging C# (Aspose.Imaging for .NET)
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
            string outputPath = "output.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            int width = 400;
            int height = 300;

            using (Image image = Image.Create(new BmpOptions(), width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();

                RectangleShape rectShape = new RectangleShape(new RectangleF(50, 50, 200, 100));
                figure.AddShape(rectShape);

                EllipseShape ellipseShape = new EllipseShape(new RectangleF(100, 150, 150, 100));
                figure.AddShape(ellipseShape);

                path.AddFigure(figure);

                Pen pen = new Pen(Color.Black, 2);
                graphics.DrawPath(pen, path);

                BmpOptions saveOptions = new BmpOptions();
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
 * 1. When you need to generate a BMP thumbnail that highlights specific regions with black outlines for a reporting dashboard.
 * 2. When you want to programmatically add rectangle and ellipse borders to an image for a CAD preview in a .NET application.
 * 3. When creating printable forms where shape outlines must be drawn on a white background using Aspose.Imaging.
 * 4. When building a batch process that adds simple vector outlines to existing images before archiving them as BMP files.
 * 5. When developing a custom UI component that visualizes geometric shapes by rendering their outlines with a 2‑pixel black pen.
 */
