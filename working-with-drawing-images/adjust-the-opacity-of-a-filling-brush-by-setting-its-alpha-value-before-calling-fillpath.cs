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
        string inputPath = @"input\sample.png";
        string outputPath = @"output\result.png";

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
                path.AddFigure(figure);

                using (SolidBrush brush = new SolidBrush())
                {
                    brush.Color = Color.Blue;
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
 * 1. When you need to add a semi‑transparent blue overlay to a PNG image, such as highlighting a region in a web‑based photo editor, you can set the brush opacity before calling FillPath.
 * 2. When generating a watermark that should be partially see‑through on top of existing graphics, adjusting the brush’s Alpha value lets you render the watermark without completely obscuring the background.
 * 3. When creating UI mockups that require translucent buttons or panels drawn on a bitmap, you can use a SolidBrush with reduced opacity to simulate the final look before exporting to PNG.
 * 4. When producing a series of thumbnail images with a colored fade effect to indicate selection state, setting the brush opacity allows you to draw the fade consistently across all thumbnails.
 * 5. When preparing layered graphics for PDF or presentation slides where a colored shape must blend with underlying content, configuring the brush’s opacity ensures the shape renders with the desired transparency.
 */