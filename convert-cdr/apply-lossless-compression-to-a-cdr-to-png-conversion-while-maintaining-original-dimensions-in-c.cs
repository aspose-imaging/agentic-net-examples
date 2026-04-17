using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        string inputPath = "Input/sample.cdr";
        string outputPath = "Output/sample.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (CdrImage cdr = (CdrImage)Aspose.Imaging.Image.Load(inputPath))
        {
            var pngOptions = new PngOptions
            {
                PngCompressionLevel = PngCompressionLevel.ZipLevel9,
                ColorType = PngColorType.TruecolorWithAlpha,
                VectorRasterizationOptions = new CdrRasterizationOptions
                {
                    BackgroundColor = Aspose.Imaging.Color.White,
                    PageWidth = cdr.Width,
                    PageHeight = cdr.Height
                }
            };

            cdr.Save(outputPath, pngOptions);
        }
    }
}