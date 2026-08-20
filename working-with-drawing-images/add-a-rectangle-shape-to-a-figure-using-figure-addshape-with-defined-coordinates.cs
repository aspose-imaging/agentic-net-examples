// HOW-TO: Add a Rectangle Shape to a BMP Image Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = "output/output.bmp";

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(bmpOptions, 500, 500))
            {
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.Wheat);

                Aspose.Imaging.GraphicsPath graphicPath = new Aspose.Imaging.GraphicsPath();
                Aspose.Imaging.Figure figure = new Aspose.Imaging.Figure();

                figure.AddShape(new RectangleShape(new Aspose.Imaging.RectangleF(50f, 50f, 300f, 200f)));

                graphicPath.AddFigure(figure);
                graphics.DrawPath(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 2), graphicPath);

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
 * 1. When you need to programmatically generate a BMP diagram with a highlighted rectangular region for a technical report.
 * 2. When creating a custom thumbnail that includes a bordered rectangle overlay to indicate a selection area in a C# desktop application.
 * 3. When automating the production of printable forms where a rectangle marks a field boundary on a 500×500 pixel image.
 * 4. When building a simple image‑based UI mockup that requires drawing geometric shapes like rectangles on a solid‑color background.
 * 5. When preprocessing images for computer‑vision tests and you must add a known rectangle shape as a reference marker.
 */
