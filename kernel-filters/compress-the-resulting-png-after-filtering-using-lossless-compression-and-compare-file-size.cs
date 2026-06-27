using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.png";
            string outputPath = @"C:\temp\output_compressed.png";

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
                // Configure PNG options for lossless compression
                PngOptions options = new PngOptions
                {
                    CompressionLevel = 9,                         // Max compression
                    FilterType = PngFilterType.Adaptive,          // Best filter selection
                    Progressive = true,                           // Enable progressive loading
                    ColorType = PngColorType.TruecolorWithAlpha,  // Preserve alpha channel
                    BitDepth = 8
                };

                // Save the compressed PNG
                image.Save(outputPath, options);
            }

            // Compare file sizes
            long originalSize = new FileInfo(inputPath).Length;
            long compressedSize = new FileInfo(outputPath).Length;

            Console.WriteLine($"Original size:   {originalSize} bytes");
            Console.WriteLine($"Compressed size: {compressedSize} bytes");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to reduce the storage footprint of high‑resolution PNG assets for a web application while preserving exact visual quality, they can use this code to apply lossless compression and verify the size reduction.
 * 2. When preparing PNG graphics for mobile apps where bandwidth is limited, the snippet lets a C# developer compress the images with Aspose.Imaging and compare original versus compressed file sizes to ensure optimal download performance.
 * 3. When archiving scanned documents as PNG files, a developer can employ this example to apply adaptive filtering and maximum lossless compression, then check the saved file size to confirm storage savings.
 * 4. When generating PNG thumbnails in an automated pipeline, the code enables a .NET developer to compress each thumbnail without losing alpha transparency and to log the size difference for quality‑control reporting.
 * 5. When troubleshooting image‑processing workflows that unexpectedly inflate PNG sizes, a programmer can run this sample to compress the output, compare file sizes, and pinpoint whether the compression settings are effective.
 */