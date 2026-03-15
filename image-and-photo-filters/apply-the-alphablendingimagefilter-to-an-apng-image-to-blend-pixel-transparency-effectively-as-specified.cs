using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputApngPath = "input.png";
        string outputApngPath = "output.png";

        using (ApngImage apngImage = (ApngImage)Image.Load(inputApngPath))
        {
            using (RasterImage overlay = (RasterImage)Image.Create(
                new PngOptions { Source = new StreamSource(new MemoryStream()) },
                apngImage.Width,
                apngImage.Height))
            {
                Graphics graphics = new Graphics(overlay);
                graphics.Clear(Color.FromArgb(128, 255, 0, 0));

                for (int i = 0; i < apngImage.PageCount; i++)
                {
                    ApngFrame frame = (ApngFrame)apngImage.Pages[i];
                    frame.Blend(new Point(0, 0), overlay, 255);
                }
            }

            apngImage.Save(outputApngPath, new ApngOptions());
        }
    }
}