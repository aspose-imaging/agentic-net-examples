using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/sample.bmp";
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        string outputPath = "Output/sample.png";
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image image = Image.Load(inputPath))
        {
            using (PngOptions pngOptions = new PngOptions())
            {
                image.Save(outputPath, pngOptions);
            }
        }

        Console.WriteLine($"Image saved to {outputPath}");
    }
}