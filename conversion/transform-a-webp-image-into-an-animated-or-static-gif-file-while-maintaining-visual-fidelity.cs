using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\Images\input.webp";
        string outputPath = @"C:\Images\output.gif";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the WebP image (static or animated)
        using (WebPImage webPImage = new WebPImage(inputPath))
        {
            // Save as GIF while preserving all frames (if any)
            GifOptions gifOptions = new GifOptions();
            // No additional options are required for basic conversion;
            // Aspose.Imaging will handle multi‑frame images automatically.

            webPImage.Save(outputPath, gifOptions);
        }

        Console.WriteLine("Conversion completed successfully.");
    }
}