using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "Input\\sample.webp";
        string outputPath = "Output\\sample.png";

        // Verify that the input WebP file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the WebP image and save it as PNG
        using (WebPImage webPImage = new WebPImage(inputPath))
        {
            webPImage.Save(outputPath, new PngOptions());
        }
    }
}