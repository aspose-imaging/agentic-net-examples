using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\Images\sample.bmp";
            string outputPath = @"C:\Images\sample_baseline.jpg";

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
                // Configure JPEG save options with Baseline compression
                JpegOptions saveOptions = new JpegOptions
                {
                    // Set baseline compression for compatibility with older viewers
                    CompressionType = JpegCompressionMode.Baseline,
                    // Optional: set quality (1-100). Here we use high quality.
                    Quality = 100,
                    // Preserve other defaults (bits per channel, resolution, etc.)
                };

                // Save the image as JPEG using the configured options
                image.Save(outputPath, saveOptions);
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
 * 1. When a developer needs to convert legacy BMP assets to JPEG files that can be opened by older web browsers or email clients that only support baseline JPEG.
 * 2. When a developer is preparing product catalog images for an e‑commerce platform that requires maximum compatibility with mobile devices running older operating systems.
 * 3. When a developer must generate thumbnail previews for a digital asset management system and ensure the thumbnails are viewable in any standard image viewer.
 * 4. When a developer is exporting scanned documents from a Windows desktop application to JPEG while preserving high quality and guaranteeing that the files can be printed from legacy office software.
 * 5. When a developer is automating batch processing of high‑resolution photographs for archival storage and needs to enforce baseline JPEG compression to avoid compatibility issues with third‑party archival tools.
 */