// HOW-TO: Compress JPEG to 75% Quality and Calculate Size Reduction in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.jpg";
            string outputPath = "Output\\sample_compressed.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            long originalSize = new FileInfo(inputPath).Length;

            using (Image image = Image.Load(inputPath))
            {
                using (JpegOptions options = new JpegOptions())
                {
                    options.Quality = 75;
                    image.Save(outputPath, options);
                }
            }

            long newSize = new FileInfo(outputPath).Length;
            double reduction = (originalSize - newSize) * 100.0 / originalSize;
            Console.WriteLine($"Original size: {originalSize} bytes");
            Console.WriteLine($"Compressed size: {newSize} bytes");
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
 * 1. When you need to reduce the storage footprint of high‑resolution JPEG photos before archiving them on a server.
 * 2. When preparing images for faster web page loading by compressing JPEGs to a specific quality level and verifying the size savings.
 * 3. When generating thumbnails for a mobile app and want to ensure the compressed JPEG meets a target file‑size reduction.
 * 4. When automating batch processing of user‑uploaded pictures to enforce a maximum quality setting and report compression metrics.
 * 5. When optimizing images for email attachments and need to calculate the percentage decrease to stay within size limits.
 */
