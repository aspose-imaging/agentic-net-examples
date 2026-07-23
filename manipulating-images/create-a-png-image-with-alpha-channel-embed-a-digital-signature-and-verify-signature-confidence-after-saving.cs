using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "Output/output.png";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a PNG image with alpha channel (200x200)
            using (PngImage png = new PngImage(200, 200, PngColorType.TruecolorWithAlpha))
            {
                // Embed digital signature with a valid password
                png.EmbedDigitalSignature("secure123");

                // Save the image
                png.Save(outputPath);
            }

            // Load the saved image and verify the digital signature
            using (PngImage loaded = (PngImage)Image.Load(outputPath))
            {
                bool isSigned = loaded.IsDigitalSigned("secure123");
                Console.WriteLine($"Signature verified: {isSigned}");
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
 * 1. When a developer needs to generate a transparent PNG logo for a web application and ensure its authenticity by embedding a digital signature that can be verified later.
 * 2. When an e‑commerce platform wants to create product images with alpha channels and protect them from tampering by signing the PNG files with a password.
 * 3. When a document management system must store confidential diagrams as PNGs and later confirm their integrity by checking the embedded digital signature confidence.
 * 4. When a mobile app generates user‑customized stickers with transparency and requires a secure way to validate that the stickers have not been altered after download.
 * 5. When a compliance‑focused reporting tool exports charts as PNG images with alpha transparency and embeds a password‑protected digital signature to meet audit trail requirements.
 */