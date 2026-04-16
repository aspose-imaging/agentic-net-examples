using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.png";
        string outputPath = @"C:\temp\output.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load PNG, rotate 180°, and save as PDF (portrait orientation)
        using (PngImage pngImage = new PngImage(inputPath))
        {
            pngImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
            pngImage.Save(outputPath, new PdfOptions());
        }
    }
}