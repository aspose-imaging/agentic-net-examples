using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.cdr";
        string outputPath = "output\\output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
        {
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = new CdrRasterizationOptions
                {
                    PageWidth = cdrImage.Width,
                    PageHeight = cdrImage.Height
                }
            };

            cdrImage.Save(outputPath, pngOptions);
            Console.WriteLine($"Converted {inputPath} to {outputPath}");
        }
    }
}