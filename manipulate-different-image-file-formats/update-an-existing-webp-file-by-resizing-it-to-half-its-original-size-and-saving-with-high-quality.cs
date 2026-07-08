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
            string inputPath = @"C:\Images\input.webp";
            string outputPath = @"C:\Images\output_resized.webp";

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
                // Calculate half size
                int newWidth = webPImage.Width / 2;
                int newHeight = webPImage.Height / 2;

                // Resize using high-quality resampling (Bilinear)
                webPImage.Resize(newWidth, newHeight, ResizeType.BilinearResample);

                // Save with high quality settings
                var saveOptions = new WebPOptions
                {
                    Lossless = false,          // lossy compression
                    Quality = 100f             // maximum quality
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

/*
 * Real-World Use Cases:
 * 1. When a web developer needs to generate thumbnail previews of high‑resolution WebP photos for a responsive gallery, they can use this C# code to resize the images to half their original dimensions while preserving maximum visual quality.
 * 2. When an e‑commerce platform wants to reduce bandwidth by delivering smaller WebP product images on mobile devices, the code resizes each image to 50 % of its size and saves it with a quality setting of 100 % using Aspose.Imaging for .NET.
 * 3. When a content management system automatically creates optimized WebP assets for social media sharing, the snippet resizes the source file and applies lossless‑false, high‑quality compression to meet platform requirements.
 * 4. When a desktop application processes user‑uploaded WebP screenshots and needs to store a compact version for archival, the example demonstrates loading the WebPImage, halving its width and height, and saving it with high‑quality settings via WebPOptions.
 * 5. When a batch‑processing script must prepare WebP images for email newsletters by shrinking them to half size without noticeable degradation, this C# routine performs the resize with bilinear resampling and saves the result at maximum quality.
 */