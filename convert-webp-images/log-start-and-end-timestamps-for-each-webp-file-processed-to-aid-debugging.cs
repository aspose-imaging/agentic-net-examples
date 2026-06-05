using System;
using System.IO;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\test.webp";
        string outputPath = @"c:\temp\test.output.png";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Log start timestamp
            Console.WriteLine($"Processing started: {DateTime.Now:O}");

            // Load WebP image from file
            using (WebPImage webPImage = new WebPImage(inputPath))
            {
                // Save as PNG using default options
                webPImage.Save(outputPath, new PngOptions());
            }

            // Log end timestamp
            Console.WriteLine($"Processing finished: {DateTime.Now:O}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}