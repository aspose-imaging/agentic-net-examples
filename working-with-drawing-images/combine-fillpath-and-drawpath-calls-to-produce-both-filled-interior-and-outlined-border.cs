using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (var pngOptions = new PngOptions())
        {
            pngOptions.Source = new FileCreateSource(outputPath, false);
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(pngOptions, 500, 500))
            {
                var graphics = new Aspose.Imaging.Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                var path = new Aspose.Imaging.GraphicsPath();
                var figure = new Aspose.Imaging.Figure();

                figure.AddShape(new RectangleShape(new Aspose.Imaging.RectangleF(50f, 50f, 200f, 200f)));
                figure.AddShape(new EllipseShape(new Aspose.Imaging.RectangleF(100f, 100f, 200f, 200f)));

                path.AddFigure(figure);

                using (var brush = new SolidBrush(Aspose.Imaging.Color.LightBlue))
                {
                    graphics.FillPath(brush, path);
                }

                graphics.DrawPath(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Red, 3), path);

                image.Save();
            }
        }
    }
}