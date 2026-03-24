using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main()
    {
        string outputPath = @"c:\temp\custom_shapes.bmp";

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        BmpOptions bmpOptions = new BmpOptions
        {
            BitsPerPixel = 24,
            Source = new FileCreateSource(outputPath, false)
        };

        using (Image image = Image.Create(bmpOptions, 500, 500))
        {
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.LightGray);

            GraphicsPath graphicPath = new GraphicsPath();

            Figure figure1 = new Figure();
            figure1.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 150f)));
            figure1.AddShape(new EllipseShape(new RectangleF(300f, 50f, 150f, 150f)));
            graphicPath.AddFigure(figure1);

            Figure figure2 = new Figure();
            figure2.AddShape(new PolygonShape(
                new PointF[]
                {
                    new PointF(100f, 300f),
                    new PointF(200f, 350f),
                    new PointF(150f, 400f),
                    new PointF(80f, 380f)
                },
                true));
            figure2.AddShape(new PieShape(new RectangleF(300f, 300f, 150f, 150f), 0f, 120f));
            graphicPath.AddFigure(figure2);

            using (SolidBrush fillBrush = new SolidBrush(Color.LightBlue))
            {
                graphics.FillPath(fillBrush, graphicPath);
            }

            graphics.DrawPath(new Pen(Color.Black, 2), graphicPath);

            image.Save();
        }
    }
}