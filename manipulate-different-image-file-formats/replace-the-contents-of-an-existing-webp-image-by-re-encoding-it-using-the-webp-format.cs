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

        // Load the existing WebP image from file
        using (WebPImage webPImage = new WebPImage(inputPath))
        {
            // Create WebP save options (adjust as needed)
            WebPOptions saveOptions = new WebPOptions
            {
                // Example: use lossless compression with maximum quality
                Lossless = true,
                Quality = 100f
            };

            // Re‑encode and save the image using the specified WebP options
            webPImage.Save(outputPath, saveOptions);
        }
    }
}