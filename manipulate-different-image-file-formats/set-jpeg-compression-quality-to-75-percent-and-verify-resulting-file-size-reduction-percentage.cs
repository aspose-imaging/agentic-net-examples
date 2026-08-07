using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\sample.bmp";
            string outputPath = @"C:\temp\sample_75.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Get original file size
            long originalSize = new FileInfo(inputPath).Length;

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Configure JPEG options with 75% quality
                JpegOptions jpegOptions = new JpegOptions
                {
                    Quality = 75
                };

                // Save the image as JPEG with the specified quality
                image.Save(outputPath, jpegOptions);
            }

            // Get compressed file size
            long compressedSize = new FileInfo(outputPath).Length;

            // Calculate reduction percentage
            double reductionPercent = 0;
            if (originalSize > 0)
            {
                reductionPercent = (originalSize - compressedSize) * 100.0 / originalSize;
            }

            // Output the results
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
 * 1. When a developer needs to reduce storage costs by converting high‑resolution BMP files to JPEG with a specific quality setting (75 %) and wants to log the percentage of size reduction.
 * 2. When an image‑processing pipeline must generate web‑friendly JPEG thumbnails from source images while ensuring the compression level meets a quality threshold and reporting the saved bytes.
 * 3. When a batch‑conversion tool for legacy bitmap assets requires verifying that applying a 75 % JPEG quality actually shrinks the file size before uploading to a content delivery network.
 * 4. When a desktop application needs to let users compress scanned documents to JPEG at a known quality and display how much space was reclaimed on the local drive.
 * 5. When an automated build script compresses product screenshots to JPEG with 75 % quality and validates the compression ratio to enforce size limits for documentation PDFs.
 */