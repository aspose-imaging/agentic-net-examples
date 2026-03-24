using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input\\Photo.jpg";
        string outputPath = "output\\ResizedPhoto_CatmullRom.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image, resize using CatmullRom interpolation, and save
        using (Image image = Image.Load(inputPath))
        {
            image.Resize(640, 480, ResizeType.CatmullRom);
            image.Save(outputPath);
        }

        // Second example: resize with BilinearResample
        string outputPath2 = "output\\ResizedPhoto_Bilinear.jpg";

        // Ensure output directory exists (same directory, call again as required)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath2));

        using (Image image = Image.Load(inputPath))
        {
            image.Resize(800, 600, ResizeType.BilinearResample);
            image.Save(outputPath2);
        }
    }
}