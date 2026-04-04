using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        string outputPath = "output\\output.bmp";

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        BmpOptions bmpOptions = new BmpOptions
        {
            BitsPerPixel = 24
        };

        using (Image image = Image.Create(bmpOptions, 200, 200))
        {
            Graphics graphics = new Graphics(image);
            Pen pen = new Pen(Color.Blue, 1);
            graphics.DrawLine(pen, 10.5f, 20.5f, 180.3f, 150.7f);
            image.Save(outputPath, bmpOptions);
        }
    }
}