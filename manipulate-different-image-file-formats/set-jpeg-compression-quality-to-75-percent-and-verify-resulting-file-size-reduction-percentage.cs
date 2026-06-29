using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.bmp";
        string outputPath = @"C:\temp\sample_compressed.jpg";

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

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Configure JPEG save options with 75% quality
                JpegOptions saveOptions = new JpegOptions
                {
                    Quality = 75
                };

                // Save the image using the configured options
                image.Save(outputPath, saveOptions);
            }

            // Calculate size reduction
            long originalSize = new FileInfo(inputPath).Length;
            long compressedSize = new FileInfo(outputPath).Length;
            double reductionPercent = (originalSize - compressedSize) * 100.0 / originalSize;

            // Output results
            Console.WriteLine($"Original size: {originalSize} bytes");
            Console.WriteLine($"Compressed size: {compressedSize} bytes");
            Console.WriteLine($"Size reduction: {reductionPercent:F2}%");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to reduce the storage footprint of high‑resolution BMP assets by converting them to JPEG with a 75 % quality setting for web delivery.
 * 2. When an application must generate thumbnails for a photo gallery and wants to verify the percentage of file‑size reduction after compression.
 * 3. When a batch‑processing service compresses scanned documents to meet email attachment size limits while preserving acceptable visual quality.
 * 4. When a mobile app prepares user‑uploaded images for upload by saving them as JPEG with a specific quality level and confirming the size savings.
 * 5. When a content‑management system migrates legacy bitmap images to a more bandwidth‑efficient format and needs to log the compression ratio for audit purposes.
 */