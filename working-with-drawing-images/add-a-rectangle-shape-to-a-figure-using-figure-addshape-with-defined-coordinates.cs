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
        string outputPath = @"c:\temp\output.png";
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        PngOptions pngOptions = new PngOptions();
        pngOptions.Source = new FileCreateSource(outputPath, false);

        using (Image image = Image.Create(pngOptions, 500, 500))
        {
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.White);

            GraphicsPath graphicsPath = new GraphicsPath();

            Figure figure = new Figure();
            RectangleF rect = new RectangleF(100f, 100f, 300f, 200f);
            figure.AddShape(new RectangleShape(rect));

            graphicsPath.AddFigure(figure);

            Pen pen = new Pen(Color.Black, 2);
            graphics.DrawPath(pen, graphicsPath);

            image.Save();
        }
    }
}