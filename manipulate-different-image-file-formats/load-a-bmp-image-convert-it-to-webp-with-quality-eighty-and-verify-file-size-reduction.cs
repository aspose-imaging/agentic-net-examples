using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.bmp";
        string outputPath = @"C:\temp\output.webp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load BMP image
        using (BmpImage bmpImage = new BmpImage(inputPath))
        {
            // Save as WebP with quality 80
            var webpOptions = new WebPOptions
            {
                Quality = 80f,
                Lossless = false
            };
            bmpImage.Save(outputPath, webpOptions);
        }

        // Compare file sizes
        long originalSize = new FileInfo(inputPath).Length;
        long webpSize = new FileInfo(outputPath).Length;

        Console.WriteLine($"Original BMP size: {originalSize} bytes");
        Console.WriteLine($"Converted WebP size: {webpSize} bytes");

        if (webpSize < originalSize)
        {
            Console.WriteLine("File size reduced after conversion.");
        }
        else
        {
            Console.WriteLine("File size not reduced after conversion.");
        }
    }
}