using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Temp\input.eps";
        string outputPath = @"C:\Temp\output.psd";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load EPS image and save as PSD
        using (Image image = Image.Load(inputPath))
        {
            var psdOptions = new PsdOptions
            {
                CompressionMethod = CompressionMethod.RLE,
                ColorMode = ColorModes.Rgb
            };

            image.Save(outputPath, psdOptions);
        }
    }
}