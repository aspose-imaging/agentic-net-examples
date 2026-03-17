using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.apng";
        string outputPath = "output.apng";

        using (ApngImage apng = (ApngImage)Image.Load(inputPath))
        {
            for (int i = 0; i < apng.PageCount; i++)
            {
                var frame = (RasterImage)apng.Pages[i];
                frame.RotateFlip(RotateFlipType.Rotate90FlipX);
            }

            ApngOptions saveOptions = new ApngOptions();
            apng.Save(outputPath, saveOptions);
        }
    }
}