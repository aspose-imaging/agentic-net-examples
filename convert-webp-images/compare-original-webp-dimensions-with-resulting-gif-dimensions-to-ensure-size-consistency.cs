using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.ImageOptions;

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

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the WebP image
        using (WebPImage webPImage = new WebPImage(inputPath))
        {
            int originalWidth = webPImage.Width;
            int originalHeight = webPImage.Height;

            // Convert and save as GIF
            webPImage.Save(outputPath, new GifOptions());

            // Load the resulting GIF to compare dimensions
            using (GifImage gifImage = (GifImage)Image.Load(outputPath))
            {
                int gifWidth = gifImage.Width;
                int gifHeight = gifImage.Height;

                bool sizeMatches = originalWidth == gifWidth && originalHeight == gifHeight;

                Console.WriteLine($"Original WebP size: {originalWidth}x{originalHeight}");
                Console.WriteLine($"Resulting GIF size: {gifWidth}x{gifHeight}");
                Console.WriteLine($"Size consistency: {(sizeMatches ? "PASS" : "FAIL")}");
            }
        }
    }
}