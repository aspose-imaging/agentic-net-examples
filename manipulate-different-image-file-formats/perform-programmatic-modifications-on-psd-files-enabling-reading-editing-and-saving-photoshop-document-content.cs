using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.psd";
        string outputPath = "output\\output_modified.psd";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image image = Image.Load(inputPath))
        {
            PsdOptions options = new PsdOptions();
            options.CompressionMethod = CompressionMethod.RLE;
            options.ColorMode = ColorModes.Rgb;
            options.Version = 6;

            image.Save(outputPath, options);
        }
    }
}