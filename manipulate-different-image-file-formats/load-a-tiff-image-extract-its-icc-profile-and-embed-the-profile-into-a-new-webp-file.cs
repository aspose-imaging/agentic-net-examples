using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/sample.tif";
            string outputPath = "Output/output.webp";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TIFF image
            using (Image tiffImage = Image.Load(inputPath))
            {
                // Configure WebP options to keep metadata (including ICC profile)
                WebPOptions webpOptions = new WebPOptions
                {
                    KeepMetadata = true
                };

                // Save as WebP with embedded ICC profile
                tiffImage.Save(outputPath, webpOptions);
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
 * 1. When a developer needs to convert high‑resolution scanned TIFF documents to web‑friendly WebP images while preserving accurate colors through the embedded ICC profile.
 * 2. When an e‑commerce platform wants to generate lightweight product thumbnails from TIFF assets and ensure the thumbnails display the same color fidelity on browsers that support WebP.
 * 3. When a digital asset management system must batch‑process archival TIFF photos, embed their embedded color profiles into WebP files, and store them for fast online delivery.
 * 4. When a mobile app requires on‑the‑fly conversion of user‑uploaded TIFF images to WebP format with retained color management metadata for consistent rendering across devices.
 * 5. When a printing workflow needs to preview TIFF proofs as WebP images in a web viewer while keeping the original ICC profile to match the final printed colors.
 */