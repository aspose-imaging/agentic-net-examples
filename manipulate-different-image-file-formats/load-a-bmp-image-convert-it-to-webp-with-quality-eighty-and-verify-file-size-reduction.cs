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
            string inputPath = @"C:\Images\sample.bmp";
            string outputPath = @"C:\Images\sample_converted.webp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Save as WebP with quality 80 (lossy)
                var webpOptions = new WebPOptions
                {
                    Lossless = false,
                    Quality = 80f
                };
                image.Save(outputPath, webpOptions);
            }

            // Compare file sizes
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
 * 1. When a developer needs to reduce storage costs by converting legacy BMP assets to smaller WebP files with controlled quality in a .NET application.
 * 2. When an e‑commerce platform must generate web‑optimized product images from high‑resolution BMP scans to improve page load speed while verifying that the conversion actually shrinks the file size.
 * 3. When a Windows desktop utility automates batch processing of scanned documents, converting each BMP to lossy WebP at 80 % quality and logging the size savings for audit purposes.
 * 4. When a game developer wants to replace uncompressed BMP textures with compressed WebP equivalents in a C# pipeline and ensure the new assets are lighter than the originals.
 * 5. When a content management system integrates Aspose.Imaging to migrate legacy BMP graphics to modern WebP format, using C# code to confirm that the conversion yields a smaller file before publishing.
 */