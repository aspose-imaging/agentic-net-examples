using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "C:\\temp\\source.jpg";
            string outputPath = "C:\\temp\\output.webp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the JPEG image
            using (Image image = Image.Load(inputPath))
            {
                // Set WebP options: quality 75, enable alpha channel (preserved if present)
                var webpOptions = new WebPOptions
                {
                    Lossless = false,   // lossy compression
                    Quality = 75f       // quality level
                };

                // Save the image as WebP with the specified options
                image.Save(outputPath, webpOptions);
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
 * 1. When a web developer wants to reduce page load times by converting high‑resolution JPEG photos to smaller WebP files with a quality setting of 75 while preserving any existing transparency.
 * 2. When a mobile app needs to generate optimized WebP thumbnails from user‑uploaded JPEG images on the server using C# and Aspose.Imaging to balance visual quality and bandwidth usage.
 * 3. When an e‑commerce platform must batch‑process product photos stored as JPEGs into WebP format with lossy compression at 75 % quality to improve SEO‑friendly image delivery.
 * 4. When a digital asset management system requires on‑the‑fly conversion of JPEG assets to WebP with a specific quality level and optional alpha channel support for downstream editing tools.
 * 5. When a content management system automates image optimization by saving uploaded JPEGs as WebP using Aspose.Imaging’s WebPOptions to achieve consistent compression across browsers.
 */