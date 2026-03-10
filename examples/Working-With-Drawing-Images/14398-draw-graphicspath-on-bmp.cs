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
        string outputPath = @"output.bmp";

        Aspose.Imaging.ImageOptions.BmpOptions bmpOptions = new Aspose.Imaging.ImageOptions.BmpOptions
        {
            BitsPerPixel = 24,
            Source = new FileCreateSource(outputPath, false)
        };

        using (Image image = Image.Create(bmpOptions, 500, 500))
        {
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.Wheat);

            GraphicsPath path = new GraphicsPath();

            Figure figure1 = new Figure();
            figure1.AddShape(new RectangleShape(new RectangleF(10f, 10f, 300f, 300f)));
            figure1.AddShape(new EllipseShape(new RectangleF(50f, 50f, 300f, 300f)));
            figure1.AddShape(new PieShape(new RectangleF(250f, 250f, 200f, 200f), 0f, 45f));

            path.AddFigure(figure1);

            graphics.DrawPath(new Pen(Color.Black, 2), path);

            image.Save();
        }
    }
}