using System;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        const string sourcePath = "base.png";
        const string outputPath = "animation.apng";

        const int animationDurationMs = 2000;
        const int frameDurationMs = 100;

        using (Aspose.Imaging.RasterImage sourceImage = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(sourcePath))
        {
            ApngOptions apngOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                DefaultFrameTime = (uint)frameDurationMs,
                ColorType = PngColorType.TruecolorWithAlpha
            };

            using (ApngImage apngImage = (ApngImage)Aspose.Imaging.Image.Create(apngOptions, sourceImage.Width, sourceImage.Height))
            {
                apngImage.RemoveAllFrames();

                int totalFrames = animationDurationMs / frameDurationMs;

                apngImage.AddFrame(sourceImage);

                for (int i = 1; i < totalFrames - 1; i++)
                {
                    apngImage.AddFrame(sourceImage);
                    ApngFrame frame = (ApngFrame)apngImage.Pages[apngImage.PageCount - 1];

                    float gamma = 0.5f + (float)i / totalFrames;
                    frame.AdjustGamma(gamma);

                    int brightness = (i % 2 == 0) ? 10 : -10;
                    frame.AdjustBrightness(brightness);
                    float contrast = 1.0f + (i % 3) * 0.1f;
                    frame.AdjustContrast(contrast);
                }

                apngImage.AddFrame(sourceImage);
                apngImage.Save();
            }
        }
    }
}