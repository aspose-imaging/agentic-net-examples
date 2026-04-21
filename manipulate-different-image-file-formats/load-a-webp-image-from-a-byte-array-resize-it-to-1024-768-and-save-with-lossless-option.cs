using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"c:\temp\input.webp";
            string outputPath = @"c:\temp\output.webp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the WebP image from a byte array
            byte[] imageData = File.ReadAllBytes(inputPath);
            using (MemoryStream ms = new MemoryStream(imageData))
            using (WebPImage webPImage = new WebPImage(ms))
            {
                // Resize to 1024x768 using nearest neighbour resampling
                webPImage.Resize(1024, 768, ResizeType.NearestNeighbourResample);

                // Save with lossless compression
                var saveOptions = new WebPOptions
                {
                    Lossless = true
                };
                webPImage.Save(outputPath, saveOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}