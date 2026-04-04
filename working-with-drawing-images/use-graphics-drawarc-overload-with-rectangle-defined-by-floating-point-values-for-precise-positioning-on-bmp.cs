using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = @"C:\temp\arc_output.bmp";
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.BitsPerPixel = 24;
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        using (Image image = Image.Create(bmpOptions, 400, 300))
        {
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.White);

            RectangleF rect = new RectangleF(50.5f, 30.5f, 200.75f, 150.25f);

            Pen pen = new Pen(Color.Blue, 2);
            graphics.DrawArc(pen, rect, 0f, 180f);

            image.Save();
        }
    }
}