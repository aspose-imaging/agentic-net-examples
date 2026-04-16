using System;
using System.IO;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.webp";
        string outputPath = @"C:\temp\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Log start timestamp
        Console.WriteLine($"Processing started: {DateTime.Now:O}");

        // Load WebP image and save as PNG
        using (WebPImage webPImage = new WebPImage(inputPath))
        {
            webPImage.Save(outputPath, new PngOptions());
        }

        // Log end timestamp
        Console.WriteLine($"Processing finished: {DateTime.Now:O}");
    }
}