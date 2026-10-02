// HOW-TO: Create PNG With Rectangle And Ellipse Using GraphicsPath In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = "output.png";
        string outputDir = Path.GetDirectoryName(outputPath);
        Directory.CreateDirectory(string.IsNullOrEmpty(outputDir) ? "." : outputDir);

        try
        {
            int width = 400;
            int height = 300;
            using (Image image = Image.Create(new PngOptions(), width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                GraphicsPath path = new GraphicsPath();

                Figure rectFigure = new Figure();
                RectangleF rectBounds = new RectangleF(50, 50, 200, 150);
                RectangleShape rectangleShape = new RectangleShape(rectBounds);
                rectFigure.AddShape(rectangleShape);
                path.AddFigure(rectFigure);

                Figure ellipseFigure = new Figure();
                RectangleF ellipseBounds = new RectangleF(100, 100, 150, 100);
                EllipseShape ellipseShape = new EllipseShape(ellipseBounds);
                ellipseFigure.AddShape(ellipseShape);
                path.AddFigure(ellipseFigure);

                Pen pen = new Pen(Color.Blue, 2);
                graphics.DrawPath(pen, path);

                image.Save(outputPath, new PngOptions());
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
 * 1. When you need to generate a PNG file that contains precise vector shapes such as rectangles and ellipses for diagramming or reporting purposes.
 * 2. When you want to programmatically draw custom UI icons or badges with geometric figures in a .NET application.
 * 3. When you need to add shape annotations like bounding boxes and ellipses to a blank canvas before converting it to another format such as PDF.
 * 4. When you are building a server‑side image service that creates placeholder images of specific dimensions with geometric overlays.
 * 5. When you require a reproducible method to export vector‑based graphics to a raster PNG for use in emails, web thumbnails, or documentation.
 */
