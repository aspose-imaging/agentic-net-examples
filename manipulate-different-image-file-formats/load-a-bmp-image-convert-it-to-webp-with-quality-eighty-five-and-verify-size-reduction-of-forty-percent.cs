using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

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

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Configure WebP options: lossy compression with quality 85
                var webpOptions = new WebPOptions
                {
                    Lossless = false,
                    Quality = 85f
                };

                // Save the image as WebP
                image.Save(outputPath, webpOptions);
            }

            // Verify size reduction (at least 40% smaller)
            long inputSize = new FileInfo(inputPath).Length;
            long outputSize = new FileInfo(outputPath).Length;

            if (outputSize <= inputSize * 0.6)
            {
                Console.WriteLine("Size reduction of at least 40% achieved.");
            }
            else
            {
                Console.WriteLine("Size reduction less than 40%.");
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
 * 1. When a developer needs to reduce the storage footprint of legacy BMP assets by converting them to lossy WebP with a quality setting of 85 and confirming at least a 40 % size reduction.
 * 2. When an e‑commerce platform wants to optimize product photos originally stored as BMP files for faster page loads by programmatically saving them as WebP using Aspose.Imaging in C#.
 * 3. When a mobile‑app backend must batch‑process user‑uploaded BMP screenshots into WebP format to meet bandwidth constraints while preserving acceptable visual quality.
 * 4. When a content‑management system requires automated verification that each converted image is at least 40 % smaller before publishing, using file‑size checks in .NET.
 * 5. When a game developer wants to convert high‑resolution BMP textures to WebP with a specific quality level to shrink download size without manually inspecting each file.
 */