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

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the WebP image from a memory stream and save it as GIF
        using (FileStream inputStream = File.OpenRead(inputPath))
        using (WebPImage webPImage = new WebPImage(inputStream))
        {
            // Save directly to GIF format without creating intermediate files
            webPImage.Save(outputPath, new GifOptions());
        }
    }
}