// HOW-TO: Resize WebP Image to Half Size with High Quality in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
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
                // Compute half of the original dimensions
                int newWidth = webPImage.Width / 2;
                int newHeight = webPImage.Height / 2;

                // Resize using bilinear resampling (good quality)
                webPImage.Resize(newWidth, newHeight, ResizeType.BilinearResample);

                // Prepare high‑quality WebP save options
                var saveOptions = new WebPOptions
                {
                    Lossless = false,   // lossy compression with high quality
                    Quality = 100f      // maximum quality
                };

                // Save the resized image
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
 * 1. When you need to generate smaller thumbnail versions of WebP photos for faster web page loading while preserving visual quality.
 * 2. When an e‑commerce platform must reduce the dimensions of product WebP images to meet a mobile‑friendly size limit without noticeable loss.
 * 3. When a content management system automatically creates optimized WebP previews for uploaded high‑resolution pictures.
 * 4. When a mobile app processes user‑captured WebP files to halve their resolution before uploading to conserve bandwidth.
 * 5. When a batch‑processing script updates existing WebP assets to a consistent half‑size for uniform display across a website.
 */
