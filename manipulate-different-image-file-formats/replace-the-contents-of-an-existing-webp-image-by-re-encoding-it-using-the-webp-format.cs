using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class ReencodeWebP
{
    static void Main()
    {
        // Path to the existing WebP image
        string inputPath = @"C:\Images\original.webp";

        // Path where the re‑encoded WebP image will be saved
        string outputPath = @"C:\Images\reencoded.webp";

        // Load the existing WebP image using the dedicated constructor
        using (WebPImage webPImage = new WebPImage(inputPath))
        {
            // Optional: clear any existing animation blocks to ensure a fresh encoding
            webPImage.ClearBlocks();

            // Configure WebP save options (adjust as needed)
            WebPOptions saveOptions = new WebPOptions
            {
                // Example: use lossy compression with a quality factor of 80
                Lossless = false,
                Quality = 80f
            };

            // Re‑encode and save the image in WebP format
            webPImage.Save(outputPath, saveOptions);
        }
    }
}