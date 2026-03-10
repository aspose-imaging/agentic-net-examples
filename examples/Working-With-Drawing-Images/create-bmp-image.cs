using System;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = "output.bmp";

        FileCreateSource source = new FileCreateSource(outputPath, false);

        BmpOptions options = new BmpOptions()
        {
            Source = source,
            BitsPerPixel = 24
        };

        using (BmpImage canvas = (BmpImage)Image.Create(options, 200, 200))
        {
            Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(canvas);
            SolidBrush brush = new SolidBrush(Aspose.Imaging.Color.Red);
            graphics.FillRectangle(brush, new Aspose.Imaging.Rectangle(0, 0, canvas.Width, canvas.Height));

            canvas.Save();
        }
    }
}