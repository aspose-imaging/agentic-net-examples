using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/sample.eps";
        string outputPath = "Output/sample.psd";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (EpsImage epsImage = (EpsImage)Image.Load(inputPath))
        {
            using (PsdOptions psdOptions = new PsdOptions())
            {
                psdOptions.CompressionMethod = CompressionMethod.RLE;
                psdOptions.ColorMode = ColorModes.Rgb;

                epsImage.Save(outputPath, psdOptions);
            }
        }
    }
}