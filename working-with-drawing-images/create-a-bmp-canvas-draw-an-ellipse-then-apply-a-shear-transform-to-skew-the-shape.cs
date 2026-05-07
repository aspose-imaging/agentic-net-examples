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

            Source source = new FileCreateSource(outputPath, false);
            BmpOptions options = new BmpOptions() { Source = source, BitsPerPixel = 24 };

            using (Image image = Image.Create(options, 500, 500))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.Wheat);

                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();

                // Create an ellipse shape
                EllipseShape ellipse = new EllipseShape(new RectangleF(100, 100, 300, 200));

                // Apply shear transform (shear factor 0.5 in X direction)
                float shearFactor = 0.5f;
                Matrix shearMatrix = new Matrix(1, 0, shearFactor, 1, 0, 0);
                ellipse.Transform(shearMatrix);

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