using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/sample.cdr";
        string outputPath = "Output/sample.psd";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image image = Image.Load(inputPath))
        {
            CdrImage cdr = image as CdrImage;
            if (cdr == null)
            {
                Console.Error.WriteLine("Input file is not a CDR image.");
                return;
            }

            PsdOptions psdOptions = new PsdOptions
            {
                ChannelBitsCount = (short)16,
                ChannelsCount = (short)3,
                ColorMode = ColorModes.Rgb,
                CompressionMethod = CompressionMethod.Raw,
                VectorRasterizationOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Aspose.Imaging.Color.White,
                    PageWidth = cdr.Width,
                    PageHeight = cdr.Height
                }
            };

            cdr.Save(outputPath, psdOptions);
        }
    }
}