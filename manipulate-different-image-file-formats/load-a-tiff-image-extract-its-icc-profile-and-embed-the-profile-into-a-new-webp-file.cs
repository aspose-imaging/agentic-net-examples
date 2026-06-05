using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.tif";
            string outputPath = "output.webp";

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
                // Prepare WebP options and keep metadata (including ICC profile)
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
 * 1. When a developer needs to convert high‑resolution TIFF photographs to web‑friendly WebP while preserving the original color accuracy by embedding the embedded ICC profile.
 * 2. When an e‑commerce platform must generate lightweight product images from TIFF assets and ensure consistent colors across browsers by keeping the ICC profile in the WebP output.
 * 3. When a digital archiving system wants to migrate scanned documents stored as TIFF into WebP for storage savings, but still retain the embedded color profile for future printing.
 * 4. When a mobile app processes user‑uploaded TIFF images and creates WebP thumbnails that include the source ICC profile to maintain brand‑specific color standards.
 * 5. When a content management workflow automates batch conversion of TIFF graphics to WebP and requires the code to validate file existence, create output directories, and keep metadata such as ICC profiles.
 */