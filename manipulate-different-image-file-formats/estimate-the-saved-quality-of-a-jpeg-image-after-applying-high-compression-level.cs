// HOW-TO: How to Estimate JPEG Quality Loss After High Compression in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

namespace ImagingNet
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "input.jpg";
                string outputPath = "output.jpg";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputDir = Path.GetDirectoryName(outputPath);
                Directory.CreateDirectory(outputDir ?? ".");

                long originalSize = new FileInfo(inputPath).Length;

                using (Image image = Image.Load(inputPath))
                {
                    JpegOptions jpegOptions = new JpegOptions
                    {
                        Quality = 10,
                        Source = new FileCreateSource(outputPath, false)
                    };

                    image.Save(outputPath, jpegOptions);
                }

                long compressedSize = new FileInfo(outputPath).Length;
                double reductionPercent = (originalSize - compressedSize) * 100.0 / originalSize;

                Console.WriteLine($"Original size: {originalSize} bytes");
                Console.WriteLine($"Compressed size: {compressedSize} bytes");
                Console.WriteLine($"Size reduction: {originalSize - compressedSize} bytes ({reductionPercent:0.##}% )");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to reduce JPEG file size for faster web page loading while measuring how much quality is lost.
 * 2. When you want to batch‑process photos before uploading to a cloud service and need to log the percentage of size reduction.
 * 3. When you are building a desktop app that lets users save images with a specific compression level and display the resulting file size.
 * 4. When you must verify that a high‑compression setting (quality = 10) meets storage‑budget constraints for a digital asset management system.
 * 5. When you are creating automated tests for image‑processing pipelines and need to compare original and compressed JPEG sizes using Aspose.Imaging in C#.
 */
