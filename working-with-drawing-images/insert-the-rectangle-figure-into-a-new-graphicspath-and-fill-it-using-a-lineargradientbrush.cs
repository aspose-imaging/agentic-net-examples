using System;
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
        string outputPath = @"c:\temp\output.png";
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        PngOptions pngOptions = new PngOptions();
        pngOptions.Source = new FileCreateSource(outputPath, false);

        using (Image image = Image.Create(pngOptions, 400, 400))
        {
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.White);

            GraphicsPath path = new GraphicsPath();
            Figure figure = new Figure();
            RectangleF rect = new RectangleF(50f, 50f, 300f, 300f);
            figure.AddShape(new RectangleShape(rect));
            path.AddFigure(figure);

            using (LinearGradientBrush brush = new LinearGradientBrush(rect, Color.Red, Color.Blue, 0f))
            {
                Pen pen = new Pen(Color.Black, 2);
                graphics.FillPath(brush, path);
                graphics.DrawPath(pen, path);
            }

            image.Save();
        }
    }
}