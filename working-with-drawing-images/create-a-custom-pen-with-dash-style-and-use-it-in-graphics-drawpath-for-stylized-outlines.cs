// HOW-TO: Draw Dashed Rectangle Outline with Custom Pen in C# Using Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);
            using (Image image = Image.Create(bmpOptions, 400, 300))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                Pen pen = new Pen(Color.Blue, 3);
                pen.DashStyle = DashStyle.Dash;

                RectangleShape rectShape = new RectangleShape(new RectangleF(50, 50, 300, 200));

                Figure figure = new Figure();
                figure.AddShape(rectShape);

                GraphicsPath path = new GraphicsPath();
                path.AddFigure(figure);

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

/*
 * Real-World Use Cases:
 * 1. Use this code to generate a PNG image with a blue dashed rectangle border to highlight a region in automated reports.
 * 2. Use it when you need to draw custom‑styled outlines on shapes in a server‑side C# image processing workflow without relying on GDI+.
 * 3. Use it to create diagram illustrations where rectangles are rendered with a specific dash pattern and line thickness using Aspose.Imaging.
 * 4. Use it to produce thumbnails that include a visible, customizable dashed frame indicating selection or focus.
 * 5. Use it in a web API that returns images with dynamically drawn dashed borders around user‑uploaded pictures.
 */
