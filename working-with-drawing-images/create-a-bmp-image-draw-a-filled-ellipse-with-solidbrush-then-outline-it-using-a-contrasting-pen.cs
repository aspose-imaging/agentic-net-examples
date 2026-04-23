using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main()
    {
        string outputPath = @"c:\temp\ellipse.bmp";
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.BitsPerPixel = 24;
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        using (Image image = Image.Create(bmpOptions, 500, 500))
        {
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.White);

            Rectangle ellipseRect = new Rectangle(50, 50, 400, 400);

            using (SolidBrush fillBrush = new SolidBrush(Color.Blue))
            {
                graphics.FillEllipse(fillBrush, ellipseRect);
            }

            Pen outlinePen = new Pen(Color.Red, 5);
            graphics.DrawEllipse(outlinePen, ellipseRect);

            image.Save();
        }
    }
}