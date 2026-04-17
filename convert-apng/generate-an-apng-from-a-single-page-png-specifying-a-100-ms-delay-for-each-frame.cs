using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        string inputPath = "input.png";
        string outputPath = "output\\animation.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
        {
            ApngOptions options = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                DefaultFrameTime = 100u,
                ColorType = PngColorType.TruecolorWithAlpha
            };

            using (ApngImage apng = (ApngImage)Image.Create(options, sourceImage.Width, sourceImage.Height))
            {
                apng.RemoveAllFrames();
                apng.AddFrame(sourceImage);
                apng.Save();
            }
        }
    }
}