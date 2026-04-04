using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main()
    {
        string outputPath = @"c:\temp\output.bmp";
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.BitsPerPixel = 24;
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        using (Image canvas = Image.Create(bmpOptions, 500, 500))
        {
            Graphics graphics = new Graphics(canvas);
            graphics.Clear(Color.White);

            Pen rectPen = new Pen(Color.Blue, 5);
            graphics.DrawRectangle(rectPen, new Rectangle(50, 50, 200, 150));

            graphics.Clip = new Region(new Rectangle(60, 60, 180, 130));

            using (SolidBrush redBrush = new SolidBrush(Color.Red))
            {
                graphics.FillRectangle(redBrush, new Rectangle(0, 0, 500, 500));
            }

            canvas.Save();
        }
    }
}