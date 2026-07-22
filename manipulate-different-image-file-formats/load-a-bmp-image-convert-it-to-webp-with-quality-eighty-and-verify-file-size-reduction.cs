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
            string inputPath = @"C:\Images\sample.bmp";
            string outputPath = @"C:\Images\Converted\sample.webp";

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
                // Save as WebP with quality 80 (lossy)
                var webpOptions = new WebPOptions
                {
                    Lossless = false,
                    Quality = 80f
                };
                bmpImage.Save(outputPath, webpOptions);
            }

            // Verify file size reduction
            long inputSize = new FileInfo(inputPath).Length;
            long outputSize = new FileInfo(outputPath).Length;

            Console.WriteLine($"Input BMP size:  {inputSize} bytes");
            Console.WriteLine($"Output WebP size: {outputSize} bytes");

            if (outputSize < inputSize)
            {
                Console.WriteLine("File size reduction verified.");
            }
            else
            {
                Console.WriteLine("No size reduction detected.");
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
 * 1. When a developer needs to reduce the storage footprint of legacy BMP assets by converting them to lossy WebP with a quality setting of 80 using C# and Aspose.Imaging.
 * 2. When an e‑commerce platform must generate web‑optimized product images from high‑resolution BMP files to improve page load speed while preserving acceptable visual quality.
 * 3. When a desktop application automates batch processing of scanned BMP documents and wants to verify that each conversion to WebP actually shrinks the file size before uploading.
 * 4. When a game developer wants to replace uncompressed BMP textures with smaller WebP equivalents in a .NET pipeline to meet mobile device memory constraints.
 * 5. When a content management system needs to validate that a newly uploaded BMP image can be safely stored as a WebP file with 80 % quality without increasing the file size.
 */