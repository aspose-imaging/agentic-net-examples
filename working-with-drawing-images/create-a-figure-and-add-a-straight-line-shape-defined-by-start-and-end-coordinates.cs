using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = @"c:\temp\line_figure.png";
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        PngOptions pngOptions = new PngOptions();
        pngOptions.Source = new FileCreateSource(outputPath, false);

        using (Image image = Image.Create(pngOptions, 200, 200))
        {
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.White);

            Pen pen = new Pen(Color.Black, 2);
            graphics.DrawLine(pen, new PointF(10f, 10f), new PointF(190f, 190f));

            image.Save();
        }
    }
}