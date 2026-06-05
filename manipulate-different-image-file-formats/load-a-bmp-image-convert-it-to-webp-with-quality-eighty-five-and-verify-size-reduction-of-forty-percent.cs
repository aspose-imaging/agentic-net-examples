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
            string inputPath = @"C:\Images\input.bmp";
            string outputPath = @"C:\Images\output.webp";

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
                // Set WebP conversion options with quality 85
                var webpOptions = new WebPOptions
                {
                    Lossless = false,
                    Quality = 85f
                };

                // Save as WebP
                bmpImage.Save(outputPath, webpOptions);
            }

            // Verify size reduction of at least 40%
            long inputSize = new FileInfo(inputPath).Length;
            long outputSize = new FileInfo(outputPath).Length;

            if (outputSize > inputSize * 0.6)
            {
                Console.WriteLine("Warning: Output file size reduction is less than 40%.");
            }
            else
            {
                Console.WriteLine("Success: Output file size reduced by at least 40%.");
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
 * 1. When a developer needs to reduce the storage footprint of legacy BMP assets by converting them to WebP with a quality setting of 85 and confirming at least a 40% size reduction.
 * 2. When an e‑commerce platform wants to optimize product photos stored as BMP files for faster page loads by programmatically converting them to WebP in a C# backend and verifying the compression savings.
 * 3. When a mobile app’s build pipeline must automatically transform high‑resolution BMP icons into WebP thumbnails while ensuring the output files are significantly smaller than the originals.
 * 4. When a content management system needs to batch‑process user‑uploaded BMP images, convert them to WebP with controlled quality, and alert developers if the compression does not meet the expected 40% reduction threshold.
 * 5. When a game developer wants to replace uncompressed BMP textures with WebP equivalents in a .NET tool, using Aspose.Imaging to handle the conversion and validate that the new assets occupy considerably less disk space.
 */