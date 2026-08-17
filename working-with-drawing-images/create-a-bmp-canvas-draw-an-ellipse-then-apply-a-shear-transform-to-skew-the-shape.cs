// HOW-TO: Create BMP Image With Skewed Ellipse Using Aspose.Imaging In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string outputPath = "Output/output.bmp";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            FileCreateSource source = new FileCreateSource(outputPath, false);
            BmpOptions options = new BmpOptions() { Source = source, BitsPerPixel = 24 };

            using (Aspose.Imaging.Image canvas = Aspose.Imaging.Image.Create(options, 500, 500))
            {
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(canvas);
                graphics.Clear(Aspose.Imaging.Color.Wheat);

                Aspose.Imaging.GraphicsPath path = new Aspose.Imaging.GraphicsPath();
                Aspose.Imaging.Figure figure = new Aspose.Imaging.Figure();

                Aspose.Imaging.Shapes.EllipseShape ellipse = new Aspose.Imaging.Shapes.EllipseShape(new Aspose.Imaging.RectangleF(50, 50, 300, 300));

                Aspose.Imaging.Matrix shear = new Aspose.Imaging.Matrix(1, 0, 0.5f, 1, 0, 0);
                ellipse.Transform(shear);

                figure.AddShape(ellipse);
                path.AddFigure(figure);

                graphics.DrawPath(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 2), path);

                canvas.Save();
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
 * 1. When you need to generate a BMP thumbnail that contains a skewed ellipse for a custom UI element or icon.
 * 2. When creating test images for computer‑vision algorithms that require geometric distortion such as shear‑skewed shapes.
 * 3. When producing a simple graphic overlay, like a slanted badge or watermark, on a BMP background in a reporting tool.
 * 4. When building procedural game assets where an ellipse must be transformed to simulate perspective on a bitmap texture.
 * 5. When automating the creation of printable forms that include a sheared ellipse as a decorative or alignment guide.
 */
