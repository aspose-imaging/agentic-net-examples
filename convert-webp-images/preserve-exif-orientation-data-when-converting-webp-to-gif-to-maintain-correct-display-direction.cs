using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
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

        // Load the WebP image, apply EXIF‑based auto‑rotation, and save as GIF
        using (WebPImage webPImage = new WebPImage(inputPath))
        {
            // Rotate according to EXIF orientation if present
            webPImage.AutoRotate();

            // Save to GIF while preserving metadata (including EXIF)
            GifOptions gifOptions = new GifOptions
            {
                // Keep original metadata such as EXIF orientation
                KeepMetadata = true
            };

            webPImage.Save(outputPath, gifOptions);
        }
    }
}