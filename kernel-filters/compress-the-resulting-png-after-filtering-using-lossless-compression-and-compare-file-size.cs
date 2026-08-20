// HOW-TO: Compress PNG with Maximum Lossless Compression and Compare File Size in C# (Aspose.Imaging for .NET)
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
                var pngOptions = new PngOptions
                {
                    CompressionLevel = 9,                         // Max compression
                    FilterType = PngFilterType.Adaptive,          // Adaptive filter for best lossless result
                    Progressive = true,                           // Optional progressive loading
                    ColorType = PngColorType.TruecolorWithAlpha,  // Preserve color depth
                    BitDepth = 8
                };

                // Save the compressed PNG
                image.Save(outputPath, pngOptions);
            }

            // Compare file sizes
            long originalSize = new FileInfo(inputPath).Length;
            long compressedSize = new FileInfo(outputPath).Length;

            Console.WriteLine($"Original size: {originalSize} bytes");
            Console.WriteLine($"Compressed size: {compressedSize} bytes");
            Console.WriteLine($"Size reduction: {originalSize - compressedSize} bytes");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to reduce the storage footprint of PNG assets without losing image quality, such as optimizing web graphics before deployment.
 * 2. When you want to generate progressive PNG files that load gradually in browsers while keeping the original color depth.
 * 3. When you must compare the effectiveness of different PNG compression settings by measuring original and compressed file sizes.
 * 4. When you are building an automated image pipeline that validates that PNG files meet a maximum size threshold for mobile apps.
 * 5. When you need to ensure that a PNG image retains its alpha channel and true‑color data while applying the strongest lossless compression available in .NET.
 */
