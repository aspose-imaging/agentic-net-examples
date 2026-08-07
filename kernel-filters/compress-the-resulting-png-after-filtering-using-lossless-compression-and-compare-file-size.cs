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
            // Hardcoded input and output file paths
            string inputPath = @"C:\Images\input.png";
            string outputPath = @"C:\Images\output_compressed.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PNG options for lossless, maximum compression
                var pngOptions = new PngOptions
                {
                    CompressionLevel = 9,                     // Max compression (0-9)
                    FilterType = PngFilterType.Adaptive,      // Adaptive filter for best compression
                    Progressive = true,                       // Enable progressive loading
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
 * 1. When a web developer wants to reduce PNG asset size for faster page load without losing image quality, they can use this code to apply lossless compression and verify the size reduction.
 * 2. When a mobile app builds an offline image cache and needs to store PNGs in limited storage, the code can compress the images and compare original versus compressed sizes to ensure they fit.
 * 3. When a CI/CD pipeline processes generated screenshots and must archive them efficiently, the script can filter and compress PNGs and log the byte savings for reporting.
 * 4. When a digital asset management system imports high‑resolution PNG files and wants to standardize them with adaptive filters and progressive loading, this code compresses the images and confirms the new file size.
 * 5. When a game developer prepares texture atlases in PNG format and needs to guarantee that the final package stays within a size budget, they can run this code to apply maximum lossless compression and measure the reduction.
 */