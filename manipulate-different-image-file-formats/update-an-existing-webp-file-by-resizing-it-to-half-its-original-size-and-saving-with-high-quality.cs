using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"c:\temp\input.webp";
        string outputPath = @"c:\temp\output_resized.webp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the WebP image
        using (WebPImage image = (WebPImage)Image.Load(inputPath))
        {
            // Calculate half size
            int newWidth = image.Width / 2;
            int newHeight = image.Height / 2;

            // Resize using nearest neighbour resampling
            image.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);

            // Prepare high‑quality WebP save options
            var saveOptions = new WebPOptions
            {
                Quality = 100f,          // maximum quality
                Lossless = false        // lossy compression with high quality
            };

            // Save the resized image
            image.Save(outputPath, saveOptions);
        }
    }
}