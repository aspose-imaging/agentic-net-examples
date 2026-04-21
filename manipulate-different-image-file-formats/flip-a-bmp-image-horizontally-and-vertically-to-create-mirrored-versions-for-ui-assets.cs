using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "sample.bmp";
        string outputPathHorizontal = "sample.horizontal.bmp";
        string outputPathVertical = "sample.vertical.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Create horizontal mirrored version
        using (Image image = Image.Load(inputPath))
        {
            image.RotateFlip(RotateFlipType.RotateNoneFlipX);
            Directory.CreateDirectory(Path.GetDirectoryName(outputPathHorizontal) ?? ".");
            image.Save(outputPathHorizontal);
        }

        // Create vertical mirrored version
        using (Image image = Image.Load(inputPath))
        {
            image.RotateFlip(RotateFlipType.RotateNoneFlipY);
            Directory.CreateDirectory(Path.GetDirectoryName(outputPathVertical) ?? ".");
            image.Save(outputPathVertical);
        }
    }
}