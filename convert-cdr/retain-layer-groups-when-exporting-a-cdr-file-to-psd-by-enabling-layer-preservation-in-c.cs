using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = @"C:\Images\sample.cdr";
        string outputPath = @"C:\Images\sample_output.psd";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
        {
            PsdOptions psdOptions = new PsdOptions
            {
                CompressionMethod = CompressionMethod.RLE,
                ColorMode = ColorModes.Rgb,
                MultiPageOptions = new MultiPageOptions(new IntRange(0, cdr.PageCount))
            };

            if (cdr is VectorImage)
            {
                psdOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                {
                    PageWidth = cdr.Width,
                    PageHeight = cdr.Height
                };
            }

            cdr.Save(outputPath, psdOptions);
        }
    }
}