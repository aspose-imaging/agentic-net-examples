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
            string inputPath = @"c:\temp\sample.png";
            string outputPath = @"c:\temp\sample_compressed.png";

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
                    // Maximum compression level (0-9)
                    CompressionLevel = 9,
                    // Adaptive filter gives best compression for lossless PNG
                    FilterType = PngFilterType.Adaptive,
                    // Preserve progressive loading (optional)
                    Progressive = true,
                    // Keep truecolor with alpha (preserve original color depth)
                    ColorType = PngColorType.TruecolorWithAlpha,
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
 * 1. When a web application needs to serve PNG assets faster by reducing bandwidth, a developer can use this code to apply lossless compression and verify the size reduction.
 * 2. When an automated build pipeline processes UI screenshots, the code can compress each PNG and compare original versus compressed sizes to ensure storage efficiency.
 * 3. When a mobile app synchronizes image resources over limited data connections, developers can run this routine to shrink PNG files without losing quality and log the savings.
 * 4. When a digital asset management system archives large collections of PNG graphics, the snippet helps compress each file and record the size improvement for reporting.
 * 5. When a developer creates a batch‑processing tool to optimize PNGs before uploading to a CDN, this example demonstrates how to set the highest compression level, adaptive filter, and verify the resulting file size.
 */