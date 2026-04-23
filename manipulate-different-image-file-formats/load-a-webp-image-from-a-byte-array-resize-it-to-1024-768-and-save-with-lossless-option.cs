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
        string inputPath = @"C:\Images\input.webp";
        string outputPath = @"C:\Images\output_resized.webp";

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
            byte[] imageBytes = File.ReadAllBytes(inputPath);
            using (MemoryStream ms = new MemoryStream(imageBytes))
            using (WebPImage webPImage = new WebPImage(ms))
            {
                // Resize to 1024 x 768 using bilinear resampling
                webPImage.Resize(1024, 768, ResizeType.BilinearResample);

                // Prepare lossless WebP save options
                WebPOptions saveOptions = new WebPOptions
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