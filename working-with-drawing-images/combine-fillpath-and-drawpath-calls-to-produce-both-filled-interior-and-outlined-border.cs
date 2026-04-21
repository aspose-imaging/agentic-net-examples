using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        string outputPath = @"c:\temp\filled_and_outlined.png";

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        PngOptions pngOptions = new PngOptions
        {
            Source = new FileCreateSource(outputPath, false)
        };

        using (Image image = Image.Create(pngOptions, 500, 500))
        {
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.White);

            GraphicsPath path = new GraphicsPath();
            Figure figure = new Figure();

            figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 300f, 200f)));
            figure.AddShape(new EllipseShape(new RectangleF(150f, 150f, 200f, 150f)));

            path.AddFigure(figure);

            Pen outlinePen = new Pen(Color.Black, 2);
            using (SolidBrush fillBrush = new SolidBrush(Color.LightBlue))
            {
                graphics.FillPath(fillBrush, path);
            }

            graphics.DrawPath(outlinePen, path);

            image.Save();
        }
    }
}