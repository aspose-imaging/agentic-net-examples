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
                PointF[] points = new PointF[]
                {
                    new PointF(100f, 100f),
                    new PointF(400f, 100f),
                    new PointF(350f, 300f),
                    new PointF(150f, 300f)
                };
                figure.AddShape(new PolygonShape(points, true));

                path.AddFigure(figure);

                using (SolidBrush solidBrush = new SolidBrush(Color.LightGray))
                {
                    graphics.FillPath(solidBrush, path);
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