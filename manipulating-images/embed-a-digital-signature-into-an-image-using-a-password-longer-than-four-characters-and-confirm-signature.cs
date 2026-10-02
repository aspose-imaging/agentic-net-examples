// HOW-TO: Embed and Verify Password Protected Digital Signature in Image Using C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats;

class Program
{
    static void Main()
    {
        string inputPath = "input.jpg";
        string outputPath = "output.png";
        string password = "StrongPass123";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                image.EmbedDigitalSignature(password);
                image.Save(outputPath);
            }

            using (RasterImage signedImage = (RasterImage)Image.Load(outputPath))
            {
                bool isSigned = signedImage.IsDigitalSigned(password);
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
 * 1. When a developer needs to protect a JPEG or PNG file from tampering by embedding a password‑protected digital signature before distributing it.
 * 2. When an application must confirm that an image received from a client has not been altered by verifying the embedded signature with the original password.
 * 3. When a workflow requires converting a signed JPEG to a lossless PNG while preserving the embedded signature for archival purposes.
 * 4. When a security‑focused system stores product photos and wants to embed a strong password‑based signature to ensure authenticity during later audits.
 * 5. When a developer builds a document management solution that signs scanned images with a secret passphrase and later validates them during retrieval.
 */
