// HOW-TO: Rotate BMP Image 180 Degrees and Add Digital Signature in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats;

class Program
{
    static void Main()
    {
        string inputPath = "input.bmp";
        string outputPath = "output.bmp";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                string password = "Secret123";
                image.EmbedDigitalSignature(password);
                image.Save(outputPath);
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
 * 1. When you need to flip a scanned BMP document upside‑down and embed a password‑protected signature to verify its authenticity before archiving.
 * 2. When a medical imaging system must rotate BMP X‑ray images by 180° and add a digital signature to ensure tamper‑evidence for compliance.
 * 3. When a game asset pipeline requires rotating legacy BMP textures and signing them to prevent unauthorized modifications.
 * 4. When a document management workflow needs to re‑orient BMP receipts and embed a secure signature so downstream users can confirm the source.
 * 5. When an automated batch process must rotate BMP screenshots and apply a digital signature to protect them during transmission.
 */
