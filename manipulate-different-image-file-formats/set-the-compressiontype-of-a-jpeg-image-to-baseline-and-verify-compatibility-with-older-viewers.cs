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
            string inputPath = @"C:\temp\sample.bmp";
            string outputPath = @"C:\temp\sample_baseline.jpg";

            // Verify input file exists
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
                // Set JPEG options with Baseline compression
                JpegOptions jpegOptions = new JpegOptions
                {
                    CompressionType = JpegCompressionMode.Baseline,
                    Quality = 90 // typical quality setting
                };

                // Save the image as JPEG using Baseline compression
                image.Save(outputPath, jpegOptions);
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
 * 1. When a developer needs to convert legacy BMP assets to JPEG files that can be opened by older web browsers or email clients that only support Baseline JPEG compression.
 * 2. When an application must generate thumbnail previews for a digital asset management system while ensuring the JPEG output complies with the Baseline standard for maximum compatibility across Windows Photo Viewer and older mobile devices.
 * 3. When a batch‑processing service prepares product images for an e‑commerce catalog and must guarantee that the saved JPEGs with a quality setting of 90 use Baseline compression so they render correctly in all shopper browsers.
 * 4. When a document‑generation tool embeds images into PDF/A‑1b files and needs to store the source pictures as Baseline JPEGs to satisfy the archival format’s strict image‑format requirements.
 * 5. When a migration script moves scanned documents from a legacy file server to a cloud storage solution and must re‑encode the BMP scans as Baseline JPEGs to maintain compatibility with legacy document‑viewing software.
 */