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

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                Graphics graphics = new Graphics(image);

                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();
                figure.AddShape(new RectangleShape(new RectangleF(0, 0, image.Width, image.Height)));
                path.AddFigure(figure);

                using (SolidBrush brush = new SolidBrush(Color.Red))
                {
                    brush.Opacity = 0.5f;
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
 * 1. When a developer wants to highlight the entire area of a PNG image with a semi‑transparent red overlay to indicate an error region in a web‑based image viewer.
 * 2. When generating a PDF report that includes a raster image and the developer needs to apply a red tint with 50 % opacity to emphasize a selected region before embedding it.
 * 3. When creating a batch image‑processing tool that marks defective products in a manufacturing line by overlaying a translucent red color on the whole product photo.
 * 4. When building a medical imaging application that temporarily shades a diagnostic scan in red to draw attention to abnormal findings while preserving the original details.
 * 5. When designing a UI mock‑up where the background PNG must be dimmed with a red overlay to simulate a disabled state or modal dialog effect.
 */