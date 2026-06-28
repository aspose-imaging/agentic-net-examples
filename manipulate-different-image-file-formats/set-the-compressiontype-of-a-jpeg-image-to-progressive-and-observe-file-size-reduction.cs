using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.bmp";
        string outputPath = @"C:\Images\sample_progressive.jpg";

        try
        {
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
                // Configure JPEG save options with progressive compression
                JpegOptions saveOptions = new JpegOptions
                {
                    // Set progressive compression mode
                    CompressionType = JpegCompressionMode.Progressive,
                    // Optional: set quality (1-100)
                    Quality = 90,
                    // Preserve resolution
                    ResolutionSettings = new ResolutionSetting(96.0, 96.0),
                    ResolutionUnit = ResolutionUnit.Inch
                };

                // Save the image using the configured options
                image.Save(outputPath, saveOptions);
            }

            // Report file sizes to observe reduction
            FileInfo originalInfo = new FileInfo(inputPath);
            FileInfo compressedInfo = new FileInfo(outputPath);
            Console.WriteLine($"Original size: {originalInfo.Length} bytes");
            Console.WriteLine($"Compressed (progressive) size: {compressedInfo.Length} bytes");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When generating web‑optimized product photos, a developer can convert high‑resolution BMPs to progressive JPEGs with Aspose.Imaging to reduce download size while preserving visual quality.
 * 2. When building an email‑attachment service, a developer may need to shrink image payloads by saving attachments as progressive JPEGs to meet size limits.
 * 3. When creating a digital asset pipeline for a publishing platform, a developer can use progressive JPEG compression to lower storage costs and improve page‑load speed.
 * 4. When implementing a mobile app that uploads user‑generated screenshots, a developer can convert BMP screenshots to progressive JPEGs to minimize bandwidth usage.
 * 5. When preparing archival images for an online gallery, a developer can apply progressive JPEG compression to achieve smaller file sizes without sacrificing resolution and then compare original and compressed sizes programmatically.
 */