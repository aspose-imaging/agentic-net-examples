using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        string inputPath = "C:\\Images\\sample.cdr";
        string outputPath = "C:\\Images\\sample.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
        {
            var pngOptions = new PngOptions
            {
                PngCompressionLevel = PngCompressionLevel.ZipLevel9,
                ColorType = PngColorType.TruecolorWithAlpha,
                Progressive = true,
                VectorRasterizationOptions = new CdrRasterizationOptions
                {
                    PageWidth = cdr.Width,
                    PageHeight = cdr.Height
                }
            };

            cdr.Save(outputPath, pngOptions);
        }
    }
}