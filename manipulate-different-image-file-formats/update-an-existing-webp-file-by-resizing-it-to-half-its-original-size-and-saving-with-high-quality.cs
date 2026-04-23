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

            // Load the WebP image
            using (WebPImage image = new WebPImage(inputPath))
            {
                // Resize to half of original dimensions using bilinear resampling
                image.Resize(image.Width / 2, image.Height / 2, ResizeType.BilinearResample);

                // Prepare high‑quality save options
                var saveOptions = new WebPOptions
                {
                    Lossless = false,   // lossy compression with high quality
                    Quality = 100f      // maximum quality
                };

                // Save the resized image
                image.Save(outputPath, saveOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}