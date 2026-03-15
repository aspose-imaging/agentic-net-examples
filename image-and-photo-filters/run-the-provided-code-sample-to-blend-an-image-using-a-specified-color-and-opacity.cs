using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output.jpg";

        using (RasterImage background = (RasterImage)Image.Load(inputPath))
        {
            string overlayTempPath = Path.GetTempFileName();
            Source overlaySource = new FileCreateSource(overlayTempPath, false);
            JpegOptions overlayOptions = new JpegOptions() { Source = overlaySource, Quality = 100 };
            using (RasterImage overlay = (RasterImage)Image.Create(overlayOptions, background.Width, background.Height))
            {
                Graphics graphics = new Graphics(overlay);
                graphics.Clear(Color.Red);
                background.Blend(new Point(0, 0), overlay, 128);
            }

            JpegOptions saveOptions = new JpegOptions() { Quality = 90 };
            background.Save(outputPath, saveOptions);
        }
    }
}