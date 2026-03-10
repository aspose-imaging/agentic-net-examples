using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = "output.png";

        using (FileStream stream = new FileStream(outputPath, FileMode.Create))
        {
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new StreamSource(stream);

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(pngOptions, 500, 500))
            {
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);

                graphics.Clear(Aspose.Imaging.Color.Wheat);

                Aspose.Imaging.Pen blackPen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 2);
                graphics.DrawRectangle(blackPen, new Aspose.Imaging.Rectangle(50, 50, 400, 400));

                using (SolidBrush blueBrush = new SolidBrush())
                {
                    blueBrush.Color = Aspose.Imaging.Color.Blue;
                    blueBrush.Opacity = 100;
                    graphics.FillEllipse(blueBrush, new Aspose.Imaging.Rectangle(150, 150, 200, 200));
                }

                Aspose.Imaging.Pen redPen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Red, 3);
                graphics.DrawLine(redPen, new Aspose.Imaging.Point(50, 50), new Aspose.Imaging.Point(450, 450));

                Aspose.Imaging.Font font = new Aspose.Imaging.Font("Arial", 24);
                using (SolidBrush textBrush = new SolidBrush())
                {
                    textBrush.Color = Aspose.Imaging.Color.DarkGreen;
                    textBrush.Opacity = 100;
                    graphics.DrawString("Aspose.Imaging Demo", font, textBrush, new Aspose.Imaging.PointF(100, 420));
                }

                image.Save();
            }
        }
    }
}