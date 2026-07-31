using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output/output.png";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int width = 400;
            int height = 300;

            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            using (Image image = Image.Create(pngOptions, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();
                figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 150f)));
                path.AddFigure(figure);

                using (SolidBrush brush = new SolidBrush(Color.Blue))
                {
                    graphics.FillPath(brush, path);
                }

                graphics.DrawPath(new Pen(Color.Black, 2), path);

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
 * 1. When a developer needs to generate a PNG badge with a gradient‑filled rectangle background for a web dashboard, they can use Aspose.Imaging to create a GraphicsPath, add a RectangleShape, and fill it with a LinearGradientBrush.
 * 2. When creating printable marketing flyers in C#, a programmer can draw a gradient‑filled rectangle as a highlighted call‑out area by inserting the figure into a GraphicsPath and applying a LinearGradientBrush before saving as PNG.
 * 3. When building a custom charting component that requires a gradient‑colored legend box, the code can be used to add a rectangle figure to a GraphicsPath and fill it with a LinearGradientBrush for consistent rendering across platforms.
 * 4. When automating the generation of UI mock‑ups where button backgrounds need a smooth color transition, developers can employ Aspose.Imaging’s LinearGradientBrush with a GraphicsPath rectangle to produce high‑quality PNG assets.
 * 5. When developing a reporting tool that overlays gradient‑filled rectangles on scanned documents to highlight sections, the code demonstrates how to insert the rectangle into a GraphicsPath and fill it using a LinearGradientBrush in C#.
 */