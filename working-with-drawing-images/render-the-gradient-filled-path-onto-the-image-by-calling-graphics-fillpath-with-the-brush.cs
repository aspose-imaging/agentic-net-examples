using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = "output\\output.png";
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
        PngOptions pngOptions = new PngOptions();
        pngOptions.Source = new FileCreateSource(outputPath, false);
        using (Image image = Image.Create(pngOptions, 500, 500))
        {
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.White);
            using (SolidBrush brush = new SolidBrush())
            {
                brush.Color = Color.LightBlue;
                brush.Opacity = 100;
                Figure figure = new Figure();
                figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 400f, 400f)));
                GraphicsPath path = new GraphicsPath();
                path.AddFigure(figure);
                graphics.FillPath(brush, path);
            }
            image.Save();
        }
    }
}