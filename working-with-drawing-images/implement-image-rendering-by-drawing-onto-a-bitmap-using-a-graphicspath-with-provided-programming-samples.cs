using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = @"C:\temp\output.png";

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        PngOptions pngOptions = new PngOptions();
        pngOptions.Source = new FileCreateSource(outputPath, false);

        using (Image image = Image.Create(pngOptions, 500, 500))
        {
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.Wheat);

            GraphicsPath path = new GraphicsPath();
            Figure figure = new Figure();

            figure.AddShape(new RectangleShape(new RectangleF(10f, 10f, 300f, 300f)));
            figure.AddShape(new EllipseShape(new RectangleF(50f, 50f, 300f, 300f)));
            figure.AddShape(new PieShape(new RectangleF(new PointF(250f, 250f), new SizeF(200f, 200f)), 0f, 45f));

            path.AddFigure(figure);

            graphics.DrawPath(new Pen(Color.Black, 2), path);

            image.Save();
        }
    }
}