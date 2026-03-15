using System;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string backgroundPath = "background.png";
        string overlayPath = "overlay.png";
        string outputPath = "blended.jpg";

        using (Aspose.Imaging.RasterImage background = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(backgroundPath))
        {
            using (Aspose.Imaging.RasterImage overlay = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(overlayPath))
            {
                background.Blend(new Aspose.Imaging.Point(0, 0), overlay, 128);
            }

            var source = new FileCreateSource(outputPath, false);
            var jpegOptions = new JpegOptions { Source = source, Quality = 90 };
            background.Save(outputPath, jpegOptions);
        }
    }
}