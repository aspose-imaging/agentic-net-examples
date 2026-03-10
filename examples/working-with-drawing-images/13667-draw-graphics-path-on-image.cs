using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        using (FileStream stream = new FileStream("output.png", FileMode.Create))
        {
            PngOptions pngOptions = new PngOptions
            {
                Source = new StreamSource(stream)
            };

            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.Wheat);

                GraphicsPath graphicPath = new GraphicsPath();
                Figure figure = new Figure();

                figure.AddShape(new RectangleShape(new RectangleF(10f, 10f, 300f, 300f)));
                figure.AddShape(new EllipseShape(new RectangleF(50f, 50f, 300f, 300f)));
                figure.AddShape(new PieShape(
                    new RectangleF(new PointF(250f, 250f), new SizeF(200f, 200f)),
                    0f,
                    45f));

                graphicPath.AddFigure(figure);

                graphics.DrawPath(new Pen(Color.Black, 2), graphicPath);

                image.Save();
            }
        }
    }
}