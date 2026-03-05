using System;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main(string[] args)
    {
        string inputApngPath = "input.png";
        string overlayImagePath = "overlay.png";
        string outputApngPath = "output.png";

        using (Aspose.Imaging.FileFormats.Apng.ApngImage apngImage = (Aspose.Imaging.FileFormats.Apng.ApngImage)Aspose.Imaging.Image.Load(inputApngPath))
        using (Aspose.Imaging.RasterImage overlay = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(overlayImagePath))
        {
            for (int i = 0; i < apngImage.PageCount; i++)
            {
                Aspose.Imaging.FileFormats.Apng.ApngFrame frame = (Aspose.Imaging.FileFormats.Apng.ApngFrame)apngImage.Pages[i];
                frame.Blend(new Aspose.Imaging.Point(0, 0), overlay, 128);
            }

            apngImage.Save(outputApngPath);
        }
    }
}