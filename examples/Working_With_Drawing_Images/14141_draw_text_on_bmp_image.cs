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
        string outputPath = "output.bmp";

        using (FileStream stream = new FileStream(outputPath, FileMode.Create))
        {
            BmpOptions bmpOptions = new BmpOptions
            {
                Source = new StreamSource(stream)
            };

            using (Image image = Image.Create(bmpOptions, 400, 200))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                using (SolidBrush brush = new SolidBrush(Color.Blue))
                {
                    graphics.DrawString(
                        "Hello Aspose.Imaging!",
                        new Font("Arial", 24),
                        brush,
                        new PointF(20, 80));
                }

                image.Save();
            }
        }
    }
}