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
            string inputPath = @"C:\temp\input.jpg";
            string outputPath = @"C:\temp\output_high_compression.jpg";

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
                    // Use progressive compression (optional)
                    CompressionType = JpegCompressionMode.Progressive,
                    // Set a low quality value to increase compression
                    Quality = 10,
                    // Keep other defaults (bits per channel, resolution, etc.)
                };

                // Save the image with the specified options
                image.Save(outputPath, saveOptions);

                // Output the quality setting used for saving
                Console.WriteLine($"Image saved with JPEG quality setting: {saveOptions.Quality}");
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
 * 1. When a web application needs to generate thumbnail previews for a photo gallery and must reduce bandwidth by saving JPEGs with very low quality using Aspose.Imaging in C#.
 * 2. When an e‑commerce platform wants to create lightweight product images for mobile devices by applying high JPEG compression and wants to log the quality setting used.
 * 3. When a digital archiving system must store scanned documents as high‑compression JPEGs to save storage space while still being able to report the compression level applied.
 * 4. When a batch‑processing tool for email newsletters compresses user‑uploaded photos to meet size limits and needs to verify the JPEG quality parameter set via JpegOptions.
 * 5. When a C# desktop utility prepares images for upload to a cloud service that enforces strict file‑size quotas, using Aspose.Imaging to save the images with progressive JPEG compression at a quality of 10.
 */