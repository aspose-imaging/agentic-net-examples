using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = @"c:\temp\output.png";

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();
                figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 200f)));
                figure.AddShape(new EllipseShape(new RectangleF(150f, 150f, 200f, 200f)));
                path.AddFigure(figure);

                using (SolidBrush brush = new SolidBrush(Color.LightBlue))
                {
                    graphics.FillPath(brush, path);
                }

                graphics.DrawPath(new Pen(Color.Green, 2), path);
                graphics.DrawPath(new Pen(Color.Red, 3), path);

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
 * 1. When a developer needs to generate a PNG badge in a C# application, using FillPath with a SolidBrush and DrawPath with Pens to create a colored shape with a contrasting outline for branding.
 * 2. When creating thumbnail images for PDF reports where a rectangle and ellipse are filled with LightBlue and outlined with Green and Red pens to highlight sections in the raster output.
 * 3. When building a game UI overlay in .NET that draws health‑bar icons using FillPath for the interior color and DrawPath for multi‑color borders to improve visual clarity.
 * 4. When producing printable marketing flyers in ASP.NET, filling vector shapes with brand colors via FillPath and adding precise stroke widths with DrawPath to meet print‑ready specifications.
 * 5. When rendering data‑visualization charts as PNG files, filling polygons with a SolidBrush and outlining them with different Pen widths to distinguish data series in the final image.
 */