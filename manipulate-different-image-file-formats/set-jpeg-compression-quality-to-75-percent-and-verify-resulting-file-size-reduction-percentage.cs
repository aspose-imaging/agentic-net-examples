// HOW-TO: Compress BMP to JPEG With 75% Quality And Get Size Reduction In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.bmp";
            string outputPath = @"C:\Images\output_75.jpg";

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
                JpegOptions jpegOptions = new JpegOptions
                {
                    Quality = 75
                };

                // Save the image as JPEG with the specified quality
                image.Save(outputPath, jpegOptions);
            }

            // Calculate file sizes and reduction percentage
            long originalSize = new FileInfo(inputPath).Length;
            long compressedSize = new FileInfo(outputPath).Length;

            double reduction = 0;
            if (originalSize > 0)
            {
                reduction = ((double)(originalSize - compressedSize) / originalSize) * 100;
            }

            Console.WriteLine($"Original size: {originalSize} bytes");
            Console.WriteLine($"Compressed size: {compressedSize} bytes");
            Console.WriteLine($"Size reduction: {reduction:F2}%");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to reduce storage costs by converting large BMP files to smaller JPEGs with a specific 75% quality setting in a .NET application.
 * 2. When you want to generate web‑optimized images and need to verify how much the file size shrinks after applying JPEG compression.
 * 3. When building an automated batch‑processing pipeline that must save images as JPEG at a controlled quality level and log the compression savings.
 * 4. When creating a photo‑upload feature that enforces a maximum file size by compressing incoming BMPs to JPEG at 75% quality and checking the reduction percentage.
 * 5. When testing different JPEG quality values to compare visual quality versus file size, and you need a quick C# snippet to measure the results.
 */
