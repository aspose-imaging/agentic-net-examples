// HOW-TO: Fill Combined Rectangle and Ellipse Path on Image Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.jpg";
            string outputPath = "output.png";

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

                RectangleShape rectShape = new RectangleShape(new RectangleF(50, 50, 200, 150));
                figure.AddShape(rectShape);

                EllipseShape ellipseShape = new EllipseShape(new RectangleF(300, 100, 150, 100));
                figure.AddShape(ellipseShape);

                path.AddFigure(figure);

                using (SolidBrush solidBrush = new SolidBrush(Color.Blue))
                {
                    graphics.FillPath(solidBrush, path);
                }

                PngOptions options = new PngOptions();
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
 * 1. When you need to overlay solid colored shapes such as a rectangle and an ellipse onto a JPEG and save the result as a PNG for web graphics.
 * 2. When generating custom watermarks or badges by programmatically drawing combined geometric paths on product photos using C#.
 * 3. When creating composite graphics for reports, like highlighting regions of interest with filled shapes on scanned images.
 * 4. When building a batch image processing tool that adds colored annotations to images before archiving them in loss‑less PNG format.
 * 5. When developing a C# application that requires drawing multiple shapes as a single GraphicsPath to ensure consistent fill rendering across different image formats.
 */
