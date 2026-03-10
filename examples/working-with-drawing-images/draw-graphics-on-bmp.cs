using System;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = "output.bmp";

        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(bmpOptions, 500, 500))
        {
            Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);

            graphics.Clear(Aspose.Imaging.Color.Wheat);

            graphics.DrawLine(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Blue, 3), new Aspose.Imaging.Point(50, 50), new Aspose.Imaging.Point(450, 50));

            graphics.DrawRectangle(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Green, 2), new Aspose.Imaging.Rectangle(100, 100, 300, 200));

            graphics.DrawEllipse(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Red, 2), new Aspose.Imaging.Rectangle(150, 150, 200, 100));

            using (SolidBrush fillBrush = new SolidBrush())
            {
                fillBrush.Color = Aspose.Imaging.Color.Yellow;
                fillBrush.Opacity = 100;
                graphics.FillRectangle(fillBrush, new Aspose.Imaging.Rectangle(120, 120, 260, 160));
            }

            Aspose.Imaging.Font font = new Aspose.Imaging.Font("Arial", 24);
            using (SolidBrush textBrush = new SolidBrush())
            {
                textBrush.Color = Aspose.Imaging.Color.Black;
                graphics.DrawString("Aspose.Imaging BMP", font, textBrush, 150, 350);
            }

            image.Save();
        }
    }
}