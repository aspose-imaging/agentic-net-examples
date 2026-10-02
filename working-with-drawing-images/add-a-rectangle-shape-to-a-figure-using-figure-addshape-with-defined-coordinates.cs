// HOW-TO: Create BMP Image with Rectangle Shape Using Figure.AddShape in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

namespace ImagingNet
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string outputPath = "output\\rectangle.bmp";
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                BmpOptions bmpOptions = new BmpOptions();
                bmpOptions.Source = new FileCreateSource(outputPath, false);

                using (Image image = Image.Create(bmpOptions, 200, 200))
                {
                    Graphics graphics = new Graphics(image);
                    graphics.Clear(Color.White);

                    RectangleF rect = new RectangleF(50, 50, 100, 100);
                    RectangleShape rectShape = new RectangleShape(rect);

                    Figure figure = new Figure();
                    figure.AddShape(rectShape);

                    GraphicsPath path = new GraphicsPath();
                    path.AddFigure(figure);

                    Pen pen = new Pen(Color.Black);
                    graphics.DrawPath(pen, path);

                    image.Save();
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to generate a simple BMP thumbnail with a highlighted rectangular region for a document preview.
 * 2. When you want to programmatically add a border rectangle to a blank canvas for creating custom UI icons in C#.
 * 3. When you are building a report that requires drawing fixed‑size rectangles on images for layout validation using Aspose.Imaging.
 * 4. When you need to create test images with precise geometric shapes to verify image‑processing algorithms.
 * 5. When you are automating the production of placeholder graphics that include a rectangle placeholder for later content insertion.
 */
