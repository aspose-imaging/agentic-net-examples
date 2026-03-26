using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\input.webp";
        string outputPath = @"c:\temp\output.gif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load WebP image from a memory stream and save as GIF
        using (Stream inputStream = File.OpenRead(inputPath))
        using (WebPImage webPImage = new WebPImage(inputStream))
        {
            // Save the image to GIF format
            webPImage.Save(outputPath, new GifOptions());
        }
    }
}