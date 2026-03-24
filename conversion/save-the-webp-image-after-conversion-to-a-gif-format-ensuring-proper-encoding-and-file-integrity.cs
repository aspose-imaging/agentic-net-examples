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
        string inputPath = "c:\\temp\\input.webp";
        string outputPath = "c:\\temp\\output.gif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the WebP image
        using (WebPImage webPImage = new WebPImage(inputPath))
        {
            // Configure GIF saving options
            GifOptions gifOptions = new GifOptions
            {
                DoPaletteCorrection = true // improve palette quality
            };

            // Save the image as GIF
            webPImage.Save(outputPath, gifOptions);
        }

        Console.WriteLine("WebP image successfully converted to GIF.");
    }
}