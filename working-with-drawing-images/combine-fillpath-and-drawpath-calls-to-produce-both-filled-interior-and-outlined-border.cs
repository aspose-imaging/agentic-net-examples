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
        string outputPath = @"c:\temp\filled_and_outlined.png";

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure { IsClosed = true };
                figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 200f)));
                figure.AddShape(new EllipseShape(new RectangleF(150f, 150f, 200f, 200f)));
                path.AddFigure(figure);

                Pen outlinePen = new Pen(Color.Black, 2);
                using (SolidBrush fillBrush = new SolidBrush())
                {
                    fillBrush.Color = Color.Yellow;
                    fillBrush.Opacity = 100;

                    graphics.FillPath(fillBrush, path);
                    graphics.DrawPath(outlinePen, path);
                }

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
 * 1. When generating a PNG badge for a web dashboard that needs a colored shape with a crisp black outline, developers can use FillPath and DrawPath to create the filled interior and outlined border.
 * 2. When creating printable certificates in PNG format that highlight sections with a yellow fill and a defined border, this code lets developers emphasize important text.
 * 3. When rendering custom map markers in a GIS application, developers can combine a rectangle and ellipse shape, fill them with a specific color, and outline them for clear visibility on various map layers.
 * 4. When producing UI icons for a Windows Forms application, developers use FillPath and DrawPath to ensure the icon’s shape remains filled and stroked, preserving clarity at different DPI settings.
 * 5. When building an automated report that inserts annotated diagrams into PNG files, developers need this code to draw filled shapes with outlines that stand out against a white background.
 */