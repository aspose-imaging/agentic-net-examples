using System;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = "output.jpg";

        FileCreateSource source = new FileCreateSource(outputPath, false);

        JpegOptions jpegOptions = new JpegOptions()
        {
            Source = source,
            Quality = 90
        };

        using (JpegImage canvas = (JpegImage)Aspose.Imaging.Image.Create(jpegOptions, 300, 200))
        {
            Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(canvas);

            Aspose.Imaging.Rectangle[] figures = new Aspose.Imaging.Rectangle[]
            {
                new Aspose.Imaging.Rectangle(10, 10, 100, 50),
                new Aspose.Imaging.Rectangle(150, 20, 80, 80)
            };

            Aspose.Imaging.Pen pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Blue, 3);
            SolidBrush brush = new SolidBrush(Aspose.Imaging.Color.Yellow);

            foreach (var rect in figures)
            {
                graphics.FillRectangle(brush, rect);
                graphics.DrawRectangle(pen, rect);
            }

            canvas.Save();
        }
    }
}