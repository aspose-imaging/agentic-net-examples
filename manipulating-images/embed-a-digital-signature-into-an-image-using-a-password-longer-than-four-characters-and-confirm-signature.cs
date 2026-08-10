// HOW-TO: Embed and Verify Digital Signature in PNG Image Using C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\Images\input.png";
            string outputPath = @"C:\Images\output_signed.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access digital signature methods
                if (image is RasterImage rasterImage)
                {
                    // Password longer than four characters
                    string password = "StrongPass123";

                    // Embed the digital signature
                    rasterImage.EmbedDigitalSignature(password);

                    // Save the signed image
                    rasterImage.Save(outputPath);

                    // Verify the signature
                    bool isSigned = rasterImage.IsDigitalSigned(password);
                    Console.WriteLine(isSigned
                        ? "The image has been successfully signed and verified."
                        : "Signature verification failed.");
                }
                else
                {
                    Console.Error.WriteLine("The loaded image does not support digital signatures.");
                }
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
 * 1. When you need to protect a PNG product photo from unauthorized modifications by embedding a password‑protected digital signature before publishing it online.
 * 2. When a medical imaging system must ensure the integrity of scanned images by signing them with a strong password and later verifying the signature in C#.
 * 3. When a legal document workflow requires embedding a tamper‑evident signature into scanned evidence images to comply with audit regulations.
 * 4. When a cloud‑based asset management platform stores user‑uploaded images and wants to confirm they have not been altered by checking the embedded digital signature.
 * 5. When an e‑commerce application generates watermarked product images and needs to embed and validate a digital signature to guarantee authenticity across multiple devices.
 */
