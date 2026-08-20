// HOW-TO: Convert BMP Image to Lossless WebP in C# with Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "C:\\temp\\input.bmp";
            string outputPath = "C:\\temp\\output.webp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image
            using (BmpImage bmpImage = new BmpImage(inputPath))
            {
                // Set WebP options for lossless compression
                var webpOptions = new WebPOptions { Lossless = true };

                // Save the image as WebP
                bmpImage.Save(outputPath, webpOptions);
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
 * 1. When you need to reduce the file size of BMP graphics while preserving pixel‑perfect quality for web delivery.
 * 2. When an application must batch‑process legacy BMP assets and store them in the modern WebP format for faster page loads.
 * 3. When you want to generate lossless WebP thumbnails from BMP sources in a C# service without external tools.
 * 4. When integrating Aspose.Imaging into a .NET workflow to convert user‑uploaded BMP files to WebP for storage optimization.
 * 5. When preparing images for a mobile app that requires lossless WebP but receives BMP files from legacy systems.
 */
