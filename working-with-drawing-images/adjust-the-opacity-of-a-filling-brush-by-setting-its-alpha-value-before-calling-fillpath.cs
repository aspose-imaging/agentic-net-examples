using System;
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
        string outputPath = "output/output.png";

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        PngOptions pngOptions = new PngOptions();
        pngOptions.Source = new FileCreateSource(outputPath, false);

        using (Image image = Image.Create(pngOptions, 500, 500))
        {
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.White);

            GraphicsPath path = new GraphicsPath();
            Figure figure = new Figure();
            figure.AddShape(new RectangleShape(new RectangleF(100f, 100f, 300f, 200f)));
            path.AddFigure(figure);

            using (SolidBrush brush = new SolidBrush(Color.Blue))
            {
                brush.Opacity = 0.5f;
                graphics.FillPath(brush, path);
            }

            image.Save();
        }
    }
}