using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Psd;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = Path.Combine("Input", "sample.eps");
        string outputPath = Path.Combine("Output", "sample.psd");

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (EpsImage epsImage = (EpsImage)Aspose.Imaging.Image.Load(inputPath))
        {
            PsdOptions psdOptions = new PsdOptions
            {
                CompressionMethod = CompressionMethod.RLE,
                ColorMode = ColorModes.Rgb
            };

            epsImage.Save(outputPath, psdOptions);
        }
    }
}