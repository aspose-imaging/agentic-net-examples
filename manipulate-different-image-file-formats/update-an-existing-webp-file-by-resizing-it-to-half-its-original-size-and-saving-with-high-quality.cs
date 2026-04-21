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
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\input.webp";
        string outputPath = @"C:\temp\output_resized.webp";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the WebP image from the file
            using (WebPImage webPImage = new WebPImage(inputPath))
            {
                // Resize to half of the original dimensions using bilinear resampling
                int newWidth = webPImage.Width / 2;
                int newHeight = webPImage.Height / 2;
                webPImage.Resize(newWidth, newHeight, ResizeType.BilinearResample);

                // Prepare high‑quality WebP save options
                var saveOptions = new WebPOptions
                {
                    Lossless = false,      // lossy compression
                    Quality = 100f         // maximum quality
                };

                // Save the resized image with the specified options
                webPImage.Save(outputPath, saveOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}