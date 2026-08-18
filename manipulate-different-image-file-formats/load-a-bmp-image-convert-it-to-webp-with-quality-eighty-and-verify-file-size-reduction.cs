// HOW-TO: Convert BMP to WebP with Quality 80 and Check Size Reduction in C# (Aspose.Imaging for .NET)
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
                // Prepare WebP options with quality 80 (lossy)
                var webpOptions = new WebPOptions
                {
                    Lossless = false,
                    Quality = 80f
                };

                // Save as WebP
                image.Save(outputPath, webpOptions);
            }

            // Verify file size reduction
            long bmpSize = new FileInfo(inputPath).Length;
            long webpSize = new FileInfo(outputPath).Length;

            if (webpSize < bmpSize)
            {
                Console.WriteLine($"Success: WebP file is smaller ({webpSize} bytes) than BMP ({bmpSize} bytes).");
            }
            else
            {
                Console.WriteLine($"Warning: WebP file ({webpSize} bytes) is not smaller than BMP ({bmpSize} bytes).");
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
 * 1. When you need to shrink large BMP assets for faster web page loading by converting them to lossy WebP with a specific quality setting.
 * 2. When you want to automate batch processing of legacy BMP files into modern WebP format while ensuring the new files are smaller than the originals.
 * 3. When you are building a C# image‑optimization pipeline that must verify each conversion actually reduces file size before publishing.
 * 4. When you need to store user‑uploaded BMP screenshots in a storage‑efficient format without losing too much visual fidelity.
 * 5. When you are comparing compression results between BMP and WebP to decide the best format for a mobile app’s image resources.
 */
