using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"c:\temp\input.bmp";
        string outputPath = @"c:\temp\output.webp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the BMP image and save it as lossless WebP
        using (BmpImage bmpImage = new BmpImage(inputPath))
        {
            var webpOptions = new WebPOptions
            {
                Lossless = true
            };

            bmpImage.Save(outputPath, webpOptions);
        }
    }
}