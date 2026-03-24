using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main()
    {
        string inputPath = @"c:\temp\input.svg";
        string outputPath = @"c:\temp\output.svg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        int width = 600;
        int height = 400;

        using (Image image = Image.Create(new SvgOptions(), width, height))
        {
            Graphics graphics = new Graphics(image);

            GraphicsPath path = new GraphicsPath();
            Figure figure = new Figure();
            figure.AddShape(new RectangleShape(new RectangleF(100f, 100f, 200f, 150f)));
            figure.AddShape(new EllipseShape(new RectangleF(150f, 150f, 200f, 100f)));
            path.AddFigure(figure);

            graphics.DrawPath(new Pen(Color.Blue, 2), path);

            image.Save(outputPath);
        }
    }
}