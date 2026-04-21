using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = "output/output.bmp";

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.BitsPerPixel = 24;
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        using (Image canvas = Image.Create(bmpOptions, 500, 500))
        {
            Graphics graphics = new Graphics(canvas);
            graphics.Clear(Color.White);

            Pen pen = new Pen(Color.Black, 2);
            graphics.DrawEllipse(pen, new RectangleF(50, 50, 300, 300));

            Matrix shear = new Matrix(1, 0.5f, 0, 1, 0, 0);
            graphics.MultiplyTransform(shear);

            Pen penSkewed = new Pen(Color.Red, 2);
            graphics.DrawEllipse(penSkewed, new RectangleF(50, 50, 300, 300));

            canvas.Save();
        }
    }
}