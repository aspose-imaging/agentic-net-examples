using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output.apng";

        using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
        {
            ApngOptions createOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                DefaultFrameTime = 100,
                ColorType = PngColorType.TruecolorWithAlpha
            };

            using (ApngImage apngImage = (ApngImage)Image.Create(createOptions, sourceImage.Width, sourceImage.Height))
            {
                apngImage.RemoveAllFrames();

                int frameCount = 5;
                for (int i = 0; i < frameCount; i++)
                {
                    apngImage.AddFrame(sourceImage);
                }

                apngImage.Save();
            }
        }
    }
}