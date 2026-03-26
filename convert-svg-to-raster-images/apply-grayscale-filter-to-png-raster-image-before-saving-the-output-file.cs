using System;
using System.IO;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\sample.png";
        string outputPath = @"c:\temp\sample.grayscale.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load PNG, apply grayscale, and save
        using (PngImage pngImage = new PngImage(inputPath))
        {
            pngImage.Grayscale();
            pngImage.Save(outputPath);
        }
    }
}