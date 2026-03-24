using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = @"c:\temp\vector_on_raster.png";
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        PngOptions pngOptions = new PngOptions();
        pngOptions.Source = new FileCreateSource(outputPath, false);

        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(pngOptions, 500, 500))
        {
            Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);
            graphics.Clear(Aspose.Imaging.Color.White);

            Aspose.Imaging.GraphicsPath path = new Aspose.Imaging.GraphicsPath();
            Aspose.Imaging.Figure figure = new Aspose.Imaging.Figure();

            figure.AddShape(new RectangleShape(new Aspose.Imaging.RectangleF(50f, 50f, 300f, 200f)));
            figure.AddShape(new EllipseShape(new Aspose.Imaging.RectangleF(150f, 100f, 200f, 200f)));
            figure.AddShape(new PieShape(
                new Aspose.Imaging.RectangleF(new Aspose.Imaging.PointF(200f, 200f), new Aspose.Imaging.SizeF(150f, 150f)),
                0f,
                120f));

            path.AddFigure(figure);
            graphics.DrawPath(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 3), path);
            image.Save();
        }
    }
}