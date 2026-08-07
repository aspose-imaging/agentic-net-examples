using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Brushes;

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

            using (Image image = Image.Load(inputPath))
            {
                Graphics graphics = new Graphics(image);

                GraphicsPath path = new GraphicsPath();

                Figure figure = new Figure();
                figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 200f)));
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
 * 1. When a developer wants to highlight a region of a JPEG photograph by overlaying a semi‑transparent red rectangle and then save the result as a PNG for web display.
 * 2. When a C# application needs to create a red warning mask on top of an existing image, using a SolidBrush with 50 % opacity to preserve the underlying details.
 * 3. When generating a thumbnail that shows a selected area with a red translucent fill, the code can draw the overlay on the source image and export it with PngOptions.
 * 4. When building an image‑annotation tool that lets users mark suspect zones with a red semi‑transparent fill, the FillPath method with a SolidBrush provides the visual cue.
 * 5. When preparing a marketing banner that requires a red tinted overlay on a product photo to improve contrast while keeping the original colors visible, the developer can apply the brush and save the final PNG.
 */