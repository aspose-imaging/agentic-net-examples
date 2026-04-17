using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main()
    {
        string inputPath = "input.cdr";
        string outputPath = "output.jpg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
        {
            var jpegOptions = new JpegOptions
            {
                Quality = 90,
                VectorRasterizationOptions = new CdrRasterizationOptions
                {
                    PageWidth = cdr.Width,
                    PageHeight = cdr.Height
                }
            };

            cdr.Save(outputPath, jpegOptions);
        }
    }
}