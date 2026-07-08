using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.jpg";
            string outputPath = "output_signed.jpg";
            // Password longer than four characters
            string password = "secure123";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load image, embed signature, save, and verify
            using (var image = Image.Load(inputPath))
            {
                var raster = (RasterImage)image;
                raster.EmbedDigitalSignature(password);
                raster.Save(outputPath);
                bool isSigned = raster.IsDigitalSigned(password);
                Console.WriteLine($"Signature valid: {isSigned}");
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
 * 1. When a developer needs to protect a JPEG photograph from unauthorized modifications by embedding a password‑protected digital signature using Aspose.Imaging for .NET.
 * 2. When an e‑commerce platform wants to ensure that product images uploaded by sellers remain authentic, they can embed and later verify a digital signature with a strong password.
 * 3. When a legal document management system stores scanned images as TIFF files and must confirm their integrity before archival, the code can embed a password‑based signature and validate it.
 * 4. When a mobile app generates user‑created PNG graphics and must guarantee that the images have not been tampered with during transmission, developers can use this routine to sign and verify them.
 * 5. When a healthcare application needs to comply with data‑integrity regulations for patient scan images (e.g., DICOM converted to JPEG), embedding a digital signature with a secure password provides a verifiable audit trail.
 */