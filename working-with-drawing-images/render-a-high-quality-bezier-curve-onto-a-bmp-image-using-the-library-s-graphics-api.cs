using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        int width = 800;
        int height = 600;
        string outputPath = "bezier_curve.bmp";

        using (FileStream stream = new FileStream(outputPath, FileMode.Create))
        {
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new StreamSource(stream);

            using (Image image = Image.Create(bmpOptions, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.Clear(Color.White);

                Pen pen = new Pen(Color.Blue, 3);
                graphics.DrawBezier(pen,
                    new Point(100, 500),
                    new Point(200, 100),
                    new Point(600, 100),
                    new Point(700, 500));

                image.Save();
            }
        }
    }
}