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
            string inputPath = @"C:\temp\input.webp";
            string outputPath = @"C:\temp\output_resized.webp";

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

                // Resize using bilinear resampling (good quality)
                webPImage.Resize(newWidth, newHeight, ResizeType.BilinearResample);

                // Save with high quality (lossy, quality 100)
                var saveOptions = new WebPOptions
                {
                    Lossless = false,
                    Quality = 100f
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
 * 1. When a web developer needs to generate thumbnail previews of user‑uploaded WebP photos for a responsive gallery, they can resize the image to half its original dimensions while preserving high visual quality.
 * 2. When an e‑commerce platform wants to reduce bandwidth for product images stored in WebP format without sacrificing detail, the code can shrink each image by 50 % and save it with a quality setting of 100.
 * 3. When a mobile app prepares offline assets and must downscale large WebP graphics to fit limited screen space, this routine resizes the image using bilinear resampling and outputs a high‑quality WebP file.
 * 4. When a content management system automates image optimization for SEO and needs to create smaller WebP versions of existing assets, the snippet resizes and re‑encodes the files with lossless = false and maximum quality.
 * 5. When a digital marketing team wants to batch‑process campaign banners in WebP format to meet email size restrictions, the code can halve the banner dimensions and retain crisp appearance by saving with high quality.
 */