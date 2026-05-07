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
        try
        {
            string outputPath = @"c:\temp\star.png";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                PointF[] starPoints = new PointF[]
                {
                    new PointF(250, 50),
                    new PointF(280, 180),
                    new PointF(400, 180),
                    new PointF(300, 250),
                    new PointF(340, 380),
                    new PointF(250, 300),
                    new PointF(160, 380),
                    new PointF(200, 250),
                    new PointF(100, 180),
                    new PointF(220, 180)
                };

                Figure starFigure = new Figure();
                starFigure.AddShape(new PolygonShape(starPoints, true));

                GraphicsPath path = new GraphicsPath();
                path.AddFigure(starFigure);

                using (SolidBrush brush = new SolidBrush())
                {
                    brush.Color = Color.Yellow;
                    brush.Opacity = 100;
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