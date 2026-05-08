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
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.webp";
        string outputPath = @"C:\temp\output_resized.webp";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the WebP image from a byte array
            byte[] imageData = File.ReadAllBytes(inputPath);
            using (var memoryStream = new MemoryStream(imageData))
            using (var webPImage = new WebPImage(memoryStream))
            {
                // Resize to 1024x768 using bilinear resampling
                webPImage.Resize(1024, 768, ResizeType.BilinearResample);

                // Prepare lossless WebP save options
                var saveOptions = new WebPOptions
                {
                    Lossless = true
                };

                // Save the resized image with lossless compression
                webPImage.Save(outputPath, saveOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}