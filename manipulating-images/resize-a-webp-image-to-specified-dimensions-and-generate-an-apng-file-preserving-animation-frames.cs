using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\Images\input_animation.webp";
        string outputPath = @"C:\Images\output_animation.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Desired dimensions for resizing
        const int newWidth = 300;
        const int newHeight = 200;

        // Load the WebP image (may contain animation frames)
        using (WebPImage webPImage = (WebPImage)Image.Load(inputPath))
        {
            // Resize the image while preserving animation frames
            webPImage.Resize(newWidth, newHeight, ResizeType.BilinearResample);

            // Save as APNG, preserving the animation frames
            webPImage.Save(outputPath, new ApngOptions());
        }
    }
}