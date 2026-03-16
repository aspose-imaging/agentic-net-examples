using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = @"output.png";

        using (FileStream stream = new FileStream(outputPath, FileMode.Create))
        {
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new StreamSource(stream);

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(pngOptions, 500, 500))
            {
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);

                graphics.Clear(Aspose.Imaging.Color.Wheat);

                Aspose.Imaging.Pen linePen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Blue, 3);
                graphics.DrawLine(linePen,
                    new Aspose.Imaging.Point(50, 50),
                    new Aspose.Imaging.Point(450, 450));

                Aspose.Imaging.Pen rectPen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Green, 2);
                graphics.DrawRectangle(rectPen,
                    new Aspose.Imaging.Rectangle(100, 100, 300, 200));

                Aspose.Imaging.Pen ellipsePen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Red, 2);
                graphics.DrawEllipse(ellipsePen,
                    new Aspose.Imaging.Rectangle(100, 100, 300, 200));

                using (SolidBrush brush = new SolidBrush(Aspose.Imaging.Color.Purple))
                {
                    brush.Opacity = 100;
                    Aspose.Imaging.Font font = new Aspose.Imaging.Font("Arial", 24);
                    graphics.DrawString("Aspose.Imaging Demo", font, brush,
                        new Aspose.Imaging.PointF(120, 320));
                }

                image.Save();
            }
        }
    }
}