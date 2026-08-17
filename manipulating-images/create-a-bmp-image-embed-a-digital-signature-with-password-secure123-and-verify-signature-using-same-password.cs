// HOW-TO: Embed and Verify Password Protected Digital Signature in BMP with C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        try
        {
            // Define paths
            string outputPath = "output.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Create a new BMP image (100x100 pixels)
            var bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24
            };
            using (Image image = Image.Create(bmpOptions, 100, 100))
            {
                // Cast to RasterImage to access digital signature methods
                var rasterImage = (RasterImage)image;

                // Embed digital signature with the specified password
                rasterImage.EmbedDigitalSignature("Secure123");

                // Save the signed image
                image.Save(outputPath);
            }

            // Load the saved image to verify the signature
            using (Image loadedImage = Image.Load(outputPath))
            {
                var rasterLoaded = (RasterImage)loadedImage;

                // Verify the digital signature using the same password
                bool isSigned = rasterLoaded.IsDigitalSigned("Secure123");

                Console.WriteLine($"Signature verification result: {isSigned}");
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
 * 1. When you need to protect a BMP file from unauthorized changes by adding a password‑protected digital signature in a C# application.
 * 2. When you must ensure the integrity of a generated image before sending it to a client, by embedding and later verifying a signature using Aspose.Imaging.
 * 3. When a document management system stores raster images and requires cryptographic verification of each BMP to meet compliance standards.
 * 4. When an automated reporting tool creates charts as BMPs and you want to embed a secret password signature to detect tampering later.
 * 5. When a security‑focused workflow signs images with a known password and later validates them during batch processing in .NET.
 */
