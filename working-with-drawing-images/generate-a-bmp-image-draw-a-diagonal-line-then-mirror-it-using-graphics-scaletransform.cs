using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        string outputPath = "output/output.bmp";

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        int width = 200;
        int height = 200;

        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        using (Image image = Image.Create(bmpOptions, width, height))
        {
            Graphics graphics = new Graphics(image);

            Pen pen = new Pen(Color.Black, 2);
            graphics.DrawLine(pen, new Point(0, 0), new Point(width - 1, height - 1));

            graphics.ScaleTransform(-1, 1);
            graphics.TranslateTransform(-width, 0);

            graphics.DrawLine(pen, new Point(0, 0), new Point(width - 1, height - 1));

            image.Save();
        }
    }
}