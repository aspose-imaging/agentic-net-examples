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
        string inputPath = @"C:\temp\input.webp";
        string outputPath = @"C:\temp\output.gif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the WebP image (supports animated WebP)
        using (WebPImage webPImage = new WebPImage(inputPath))
        {
            // Configure GIF options to export all frames
            var gifOptions = new GifOptions
            {
                // Export each frame as a full image (required for proper animation)
                FullFrame = true
                // No MultiPageOptions needed; default exports all pages
            };

            // Save the image as an animated GIF
            webPImage.Save(outputPath, gifOptions);
        }
    }
}