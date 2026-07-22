using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\temp\large.jpg";
        string outputPath = @"C:\temp\large_optimized.jpg";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the JPEG image with a memory‑usage hint (e.g., 50 MB)
            using (Image image = Image.Load(
                inputPath,
                new LoadOptions { BufferSizeHint = 50 }))
            {
                // Configure JPEG save options to reduce file size
                JpegOptions saveOptions = new JpegOptions
                {
                    // Use progressive compression for better size/quality trade‑off
                    CompressionType = JpegCompressionMode.Progressive,
                    // Lower quality (1‑100) to shrink the file; adjust as needed
                    Quality = 60,
                    // Optional: convert to grayscale to further reduce size
                    // ColorType = JpegCompressionColorMode.Grayscale,
                    // Optional: use an 8‑bit grayscale palette
                    // Palette = ColorPaletteHelper.Create8BitGrayscale(false)
                };

                // Save the optimized JPEG image
                image.Save(outputPath, saveOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web application must upload high‑resolution JPEG photos from users but needs to limit server memory usage and store smaller files for faster delivery.
 * 2. When a desktop batch‑processing tool processes thousands of large JPEG images and wants to avoid out‑of‑memory exceptions by providing a BufferSizeHint while compressing them to a lower quality.
 * 3. When an e‑commerce platform generates product thumbnails from original large JPEGs and wants to use progressive JPEG compression to improve perceived loading speed on browsers.
 * 4. When a mobile backend service receives camera‑captured JPEGs, converts them to grayscale and reduces file size to save bandwidth and storage on cloud servers.
 * 5. When a digital asset management system archives legacy high‑resolution JPEG files and needs to re‑encode them with optimized memory usage and configurable JPEG quality settings.
 */