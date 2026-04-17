using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/sample.cdr";
        string outputPath = "Output/sample.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
        {
            var pngOptions = new PngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha,
                BitDepth = 8,
                VectorRasterizationOptions = new CdrRasterizationOptions
                {
                    BackgroundColor = Aspose.Imaging.Color.Transparent,
                    PageWidth = image.Width,
                    PageHeight = image.Height
                }
            };

            image.Save(outputPath, pngOptions);
        }
    }
}