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

                // Save the image with the specified JPEG options
                image.Save(outputPath, jpegOptions);
            }

            // Get compressed file size
            long compressedSize = new FileInfo(outputPath).Length;

            // Calculate reduction percentage
            double reductionPercent = 0;
            if (originalSize > 0)
            {
                reductionPercent = (double)(originalSize - compressedSize) * 100.0 / originalSize;
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
 * 1. When a web application needs to generate thumbnail previews from high‑resolution BMP files and wants to reduce bandwidth by saving them as JPEGs with 75 % quality while confirming the size savings.
 * 2. When an e‑commerce platform batch‑processes product photos, converting them to JPEG at a controlled quality level to meet a maximum file‑size limit and reporting the percentage reduction for quality‑control logs.
 * 3. When a digital asset management system archives scanned documents, it compresses BMP scans to JPEG with a 75 % quality setting and validates the compression ratio before moving files to long‑term storage.
 * 4. When a mobile app backend prepares user‑uploaded images for faster download, it re‑encodes the images to JPEG at 75 % quality and calculates the reduction percentage to monitor storage cost savings.
 * 5. When a reporting tool generates printable catalogs, it converts source images to JPEG with a specific quality setting and displays the size reduction to ensure the final PDF stays within size constraints.
 */