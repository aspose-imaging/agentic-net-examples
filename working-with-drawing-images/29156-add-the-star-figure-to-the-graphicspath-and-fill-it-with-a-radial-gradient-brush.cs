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
        string outputPath = @"c:\temp\star.png";
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        var pngOptions = new PngOptions();
        pngOptions.Source = new FileCreateSource(outputPath, false);

        using (Image image = Image.Create(pngOptions, 500, 500))
        {
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.White);

            PointF[] starPoints = new PointF[]
            {
                new PointF(250f,  50f),
                new PointF(300f, 200f),
                new PointF(450f, 200f),
                new PointF(330f, 300f),
                new PointF(380f, 450f),
                new PointF(250f, 350f),
                new PointF(120f, 450f),
                new PointF(170f, 300f),
                new PointF( 50f, 200f),
                new PointF(200f, 200f)
            };

            Figure figure = new Figure();
            figure.AddShape(new PolygonShape(starPoints, true));

            GraphicsPath path = new GraphicsPath();
            path.AddFigure(figure);

            using (SolidBrush brush = new SolidBrush(Color.Yellow))
            {
                graphics.FillPath(brush, path);
            }

            graphics.DrawPath(new Pen(Color.Black, 2), path);

            image.Save();
        }
    }
}