using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main()
    {
        string outputPath = @"c:\temp\output.bmp";
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.BitsPerPixel = 24;
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(bmpOptions, 500, 500))
        {
            Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);
            graphics.Clear(Aspose.Imaging.Color.Wheat);

            Aspose.Imaging.GraphicsPath graphicspath = new Aspose.Imaging.GraphicsPath();

            Aspose.Imaging.Figure figure1 = new Aspose.Imaging.Figure();
            figure1.AddShape(new RectangleShape(new Aspose.Imaging.RectangleF(10f, 10f, 300f, 300f)));

            Aspose.Imaging.Figure figure2 = new Aspose.Imaging.Figure();
            figure2.AddShape(new EllipseShape(new Aspose.Imaging.RectangleF(50f, 50f, 300f, 300f)));

            graphicspath.AddFigures(new[] { figure1, figure2 });

            graphics.DrawPath(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 2), graphicspath);

            image.Save();
        }
    }
}