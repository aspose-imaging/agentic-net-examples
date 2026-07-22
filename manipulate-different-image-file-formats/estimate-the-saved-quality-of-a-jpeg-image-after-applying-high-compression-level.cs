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
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.jpg";
            string outputPath = @"C:\Images\output_high_compression.jpg";

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
                // Configure JPEG save options for high compression (low quality)
                JpegOptions saveOptions = new JpegOptions
                {
                    // Use progressive compression (optional, but common for high compression)
                    CompressionType = JpegCompressionMode.Progressive,
                    // Set a low quality value (1-100). Lower values increase compression.
                    Quality = 10,
                    // Keep other defaults (bits per channel, resolution, etc.)
                };

                // Save the image with the specified options
                image.Save(outputPath, saveOptions);
            }

            // Estimate: the saved quality corresponds to the Quality property we set (10 out of 100)
            Console.WriteLine($"Image saved with high compression. Estimated quality setting: 10/100.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to generate low‑size JPEG thumbnails for a web gallery, they can use this code to apply high compression (quality 10) and know the estimated quality setting.
 * 2. When building an email client that must attach images under a strict size limit, the code lets the developer compress JPEGs heavily and predict the resulting quality.
 * 3. When creating preview images for a mobile app that operates on limited bandwidth, a developer can use this snippet to produce progressive JPEGs with a known low quality factor.
 * 4. When archiving large batches of product photos to save storage space, the code enables a developer to compress each JPEG to a high compression level while estimating the saved quality.
 * 5. When implementing a document management system that automatically reduces the resolution of scanned JPEG documents, a developer can apply this high‑compression routine and rely on the quality property (10/100) as an estimate of visual fidelity.
 */