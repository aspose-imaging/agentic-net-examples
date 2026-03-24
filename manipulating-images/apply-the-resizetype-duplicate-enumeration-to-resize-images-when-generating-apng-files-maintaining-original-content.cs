using System;
using System.IO;
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

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
        {
            int newWidth = sourceImage.Width * 2;
            int newHeight = sourceImage.Height * 2;
            sourceImage.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);

            ApngOptions createOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                DefaultFrameTime = 100,
                ColorType = PngColorType.TruecolorWithAlpha
            };

            using (ApngImage apngImage = (ApngImage)Image.Create(createOptions, sourceImage.Width, sourceImage.Height))
            {
                apngImage.RemoveAllFrames();

                for (int i = 0; i < 3; i++)
                {
                    apngImage.AddFrame(sourceImage);
                }

                apngImage.Save();
            }
        }
    }
}