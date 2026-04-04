using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = @"C:\temp\output.bmp";
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        using (Image image = Image.Create(bmpOptions, 400, 300))
        {
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.White);

            using (SolidBrush redBrush = new SolidBrush(Color.Red))
            {
                redBrush.Opacity = 0.5f;
                graphics.FillRectangle(redBrush, new Rectangle(50, 50, 200, 150));
            }

            using (SolidBrush blueBrush = new SolidBrush(Color.Blue))
            {
                blueBrush.Opacity = 0.5f;
                graphics.FillEllipse(blueBrush, new Rectangle(150, 100, 200, 150));
            }

            image.Save();
        }
    }
}