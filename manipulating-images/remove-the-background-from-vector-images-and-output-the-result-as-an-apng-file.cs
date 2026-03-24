using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output.apng";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
        {
            var vectorImage = image as Aspose.Imaging.VectorImage;
            if (vectorImage != null)
            {
                vectorImage.RemoveBackground(new Aspose.Imaging.RemoveBackgroundSettings());
            }

            var apngOptions = new ApngOptions
            {
                Source = new FileCreateSource(outputPath, false),
                ColorType = PngColorType.TruecolorWithAlpha,
                VectorRasterizationOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Aspose.Imaging.Color.Transparent,
                    PageSize = image.Size
                }
            };

            image.Save(outputPath, apngOptions);
        }
    }
}