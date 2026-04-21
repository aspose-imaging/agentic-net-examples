using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = @"C:\temp\sample.cdr";
        string outputPath = @"C:\temp\output.bmp";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image image = Image.Load(inputPath))
        {
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24
            };

            if (image is VectorImage)
            {
                bmpOptions.VectorRasterizationOptions = new CdrRasterizationOptions
                {
                    PageWidth = image.Width,
                    PageHeight = image.Height
                };
            }

            image.Save(outputPath, bmpOptions);
        }
    }
}