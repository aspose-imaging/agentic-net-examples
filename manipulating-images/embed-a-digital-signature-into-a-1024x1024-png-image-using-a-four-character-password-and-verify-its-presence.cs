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
            string inputPath = "input.png";
            string outputPath = "output/signed.png";
            string password = "ABCD";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                raster.EmbedDigitalSignature(password);
                raster.Save(outputPath);
            }

            using (Image signedImage = Image.Load(outputPath))
            {
                RasterImage signedRaster = (RasterImage)signedImage;
                bool isSigned = signedRaster.IsDigitalSigned(password);
                Console.WriteLine(isSigned ? "Signature verified." : "Signature not found.");
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
 * 1. When you need to protect a PNG asset from unauthorized modifications by embedding a password‑protected digital signature.
 * 2. When an application must confirm that a delivered PNG file has not been altered by verifying the embedded signature at runtime.
 * 3. When you want to add tamper‑evidence to product logos or QR code images before distributing them to partners.
 * 4. When a compliance system requires proof of image integrity for audit logs by storing a signed PNG in a secure folder.
 * 5. When integrating Aspose.Imaging in a C# service that signs medical imaging thumbnails and later validates them before display.
 */
