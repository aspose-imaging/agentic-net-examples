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
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();

                figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 150f)));
                figure.AddShape(new EllipseShape(new RectangleF(100f, 100f, 150f, 100f)));

                path.AddFigure(figure);

                using (SolidBrush brush = new SolidBrush(Color.Blue))
                {
                    brush.Opacity = 100;
                    graphics.FillPath(brush, path);
                }

                PngOptions pngOptions = new PngOptions();
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
 * 1. When a developer needs to programmatically add a blue rectangle and ellipse overlay to a PNG file for a marketing banner, they can use Aspose.Imaging Graphics.FillPath with a SolidBrush to render the shapes onto the image.
 * 2. When generating report thumbnails that require a consistent white background with highlighted regions, the code shows how to clear the canvas, draw a filled path, and save the result as a PNG using C# and Aspose.Imaging.
 * 3. When creating custom UI icons where a specific shape must be filled with a solid color and saved in lossless PNG format, developers can employ GraphicsPath, Figure, and FillPath to composite the graphics at runtime.
 * 4. When automating the addition of a colored watermark shape to a batch of images, this example demonstrates loading each input PNG, filling a path with a SolidBrush, and overwriting the file with the processed output.
 * 5. When building a server‑side image‑generation service that draws geometric shapes onto user‑uploaded images, the code illustrates the essential steps of loading the image, clearing it, filling a path, and saving the final PNG using Aspose.Imaging for .NET.
 */