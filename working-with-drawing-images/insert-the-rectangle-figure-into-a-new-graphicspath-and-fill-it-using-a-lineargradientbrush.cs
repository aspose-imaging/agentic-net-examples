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
        string inputPath = "input.png";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image image = Image.Load(inputPath))
        {
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.White);

            GraphicsPath graphicsPath = new GraphicsPath();

            Figure figure = new Figure();
            figure.AddShape(new RectangleShape(new RectangleF(50f, 50f, 200f, 150f)));
            graphicsPath.AddFigure(figure);

            using (SolidBrush brush = new SolidBrush())
            {
                brush.Color = Color.LightBlue;
                brush.Opacity = 100;
                graphics.FillPath(brush, graphicsPath);
            }

            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);
            image.Save(outputPath, pngOptions);
        }
    }
}