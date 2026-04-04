using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = @"C:\temp\curved_line.bmp";

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        using (Image image = Image.Create(bmpOptions, 500, 500))
        {
            Graphics graphics = new Graphics(image);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Pen pen = new Pen(Color.Blue, 3);

            Point[] points = new Point[]
            {
                new Point(50, 250),
                new Point(150, 50),
                new Point(350, 450),
                new Point(450, 250)
            };

            graphics.DrawCurve(pen, points);

            image.Save();
        }
    }
}