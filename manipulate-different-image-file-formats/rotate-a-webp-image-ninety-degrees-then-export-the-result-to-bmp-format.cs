using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.webp";
        string outputPath = "output.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load WebP image, rotate 90 degrees, and save as BMP
        using (WebPImage webpImage = new WebPImage(inputPath))
        {
            webpImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
            webpImage.Save(outputPath, new BmpOptions());
        }
    }
}