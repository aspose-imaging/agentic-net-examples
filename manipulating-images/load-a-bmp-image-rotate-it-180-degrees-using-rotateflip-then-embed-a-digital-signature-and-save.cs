using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.bmp";
        string outputPath = "output.bmp";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image image = Image.Load(inputPath))
        {
            image.RotateFlip(RotateFlipType.Rotate180FlipNone);
            BmpOptions options = new BmpOptions();
            image.Save(outputPath, options);
        }
    }
}