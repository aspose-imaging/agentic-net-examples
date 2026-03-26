using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "source.png";
        string outputPath = "animation.apng";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
        {
            using (ApngOptions createOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                DefaultFrameTime = 70,
                ColorType = PngColorType.TruecolorWithAlpha
            })
            {
                using (Image apngImage = Image.Create(createOptions, sourceImage.Width, sourceImage.Height))
                {
                    var apng = (Aspose.Imaging.FileFormats.Apng.ApngImage)apngImage;
                    apng.RemoveAllFrames();

                    int frameCount = 5;
                    for (int i = 0; i < frameCount; i++)
                    {
                        apng.AddFrame(sourceImage);
                    }

                    apng.Save();
                }
            }
        }
    }
}