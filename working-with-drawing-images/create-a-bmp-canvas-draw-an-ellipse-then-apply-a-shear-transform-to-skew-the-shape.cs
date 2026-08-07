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
            string outputPath = "output/output.bmp";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.Wheat);

                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();

                EllipseShape ellipse = new EllipseShape(new RectangleF(50, 50, 300, 300));

                figure.AddShape(ellipse);
                path.AddFigure(figure);

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
 * 1. When a developer needs to generate a 24‑bit BMP image with a custom background and a precise elliptical shape for a legacy Windows application UI.
 * 2. When a developer wants to programmatically create a bitmap canvas, draw an ellipse, and then apply a shear transformation to produce a skewed graphic for a scientific data visualization.
 * 3. When a developer must export a diagram containing an ellipse that is sheared to simulate perspective, using C# and Aspose.Imaging to ensure the output is a BMP file compatible with embedded systems.
 * 4. When a developer is building an automated report that includes a BMP chart where ellipses are distorted by a shear matrix to highlight trends, and needs to control pixel depth and file creation via FileCreateSource.
 * 5. When a developer is testing image processing pipelines and requires a reproducible BMP sample that contains a black‑outlined, sheared ellipse on a wheat‑colored background for regression testing of shape detection algorithms.
 */