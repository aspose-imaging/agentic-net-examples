using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"c:\temp\input.bmp";
            string outputPath = @"c:\temp\output.webp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load BMP image
            using (BmpImage bmpImage = new BmpImage(inputPath))
            {
                // Set WebP conversion options (lossy, quality 80)
                var webpOptions = new WebPOptions
                {
                    Lossless = false,
                    Quality = 80f
                };

                // Save as WebP
                bmpImage.Save(outputPath, webpOptions);
            }

            // Verify file size reduction
            long originalSize = new FileInfo(inputPath).Length;
            long webpSize = new FileInfo(outputPath).Length;

            Console.WriteLine($"Original BMP size: {originalSize} bytes");
            Console.WriteLine($"Converted WebP size: {webpSize} bytes");

            if (webpSize < originalSize)
                Console.WriteLine("File size reduced after conversion.");
            else
                Console.WriteLine("File size not reduced after conversion.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to reduce storage costs by converting large BMP assets to smaller WebP files with controlled quality in a .NET batch processing job.
 * 2. When a web application must serve faster‑loading images by programmatically converting uploaded BMP screenshots to lossy WebP format at 80% quality using Aspose.Imaging for .NET.
 * 3. When an e‑commerce platform wants to optimize product photos by converting legacy BMP images to WebP and verifying that the file size actually decreased before publishing.
 * 4. When a desktop utility needs to automate image format migration from BMP to WebP while ensuring the conversion respects a specific quality setting and reports the size difference to the user.
 * 5. When a CI/CD pipeline includes a step that validates image compression efficiency by converting BMP test assets to WebP with quality 80 and checking that the output is smaller than the source.
 */