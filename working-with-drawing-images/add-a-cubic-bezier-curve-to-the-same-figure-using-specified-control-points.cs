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
        string outputPath = @"C:\temp\output.png";
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        PngOptions pngOptions = new PngOptions();
        pngOptions.Source = new FileCreateSource(outputPath, false);

        using (Image image = Image.Create(pngOptions, 500, 500))
        {
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.White);

            GraphicsPath path = new GraphicsPath();
            Figure figure = new Figure();

            figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 150f)));

            figure.AddShape(new BezierShape(new PointF[]
            {
                new PointF(100f, 300f),
                new PointF(150f, 200f),
                new PointF(250f, 400f),
                new PointF(300f, 300f)
            }));

            path.AddFigure(figure);

            Pen pen = new Pen(Color.Black, 2);
            graphics.DrawPath(pen, path);

            image.Save();
        }
    }
}