using System;
using System.IO;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\input.webp";
        string outputPath = @"C:\temp\output.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (creates it if necessary)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Log start timestamp
        Console.WriteLine($"Processing started at {DateTime.Now:O} for {inputPath}");

        // Load the WebP image and save it as PNG
        using (WebPImage webPImage = new WebPImage(inputPath))
        {
            webPImage.Save(outputPath, new PngOptions());
        }

        // Log end timestamp
        Console.WriteLine($"Processing finished at {DateTime.Now:O} for {outputPath}");
    }
}