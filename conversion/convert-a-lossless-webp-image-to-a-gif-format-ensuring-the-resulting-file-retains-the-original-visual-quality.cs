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
        string inputPath = @"C:\Images\input_lossless.webp";
        string outputPath = @"C:\Images\output.gif";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the WebP image (lossless)
        using (WebPImage webPImage = new WebPImage(inputPath))
        {
            // Configure GIF options to preserve visual quality
            GifOptions gifOptions = new GifOptions
            {
                DoPaletteCorrection = true, // Build optimal palette
                Interlaced = false,         // Standard GIF
                ColorResolution = 7         // Maximum color depth (8 bits per pixel)
            };

            // Save as GIF
            webPImage.Save(outputPath, gifOptions);
        }

        Console.WriteLine("Conversion completed successfully.");
    }
}