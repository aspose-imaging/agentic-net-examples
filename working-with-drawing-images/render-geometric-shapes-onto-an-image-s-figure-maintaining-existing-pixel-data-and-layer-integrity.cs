using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main()
    {
        string inputPath = @"C:\temp\input.png";
        string outputPath = @"C:\temp\output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
        {
            Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);

            Aspose.Imaging.GraphicsPath graphicPath = new Aspose.Imaging.GraphicsPath();
            Aspose.Imaging.Figure figure = new Aspose.Imaging.Figure();

            figure.AddShape(new RectangleShape(new Aspose.Imaging.RectangleF(50f, 50f, 200f, 150f)));
            figure.AddShape(new EllipseShape(new Aspose.Imaging.RectangleF(300f, 100f, 150f, 150f)));
            figure.AddShape(new PieShape(new Aspose.Imaging.RectangleF(200f, 250f, 200f, 200f), 0f, 120f));

            graphicPath.AddFigure(figure);

            graphics.DrawPath(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Blue, 3), graphicPath);

            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);
            image.Save(outputPath, pngOptions);
        }
    }
}