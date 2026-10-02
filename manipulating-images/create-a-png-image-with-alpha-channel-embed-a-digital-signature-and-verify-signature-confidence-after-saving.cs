// HOW-TO: Create PNG with Alpha Channel and Digital Signature Verification in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "Output/output.png";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int width = 200;
            int height = 200;
            string password = "SecretPwd";

            using (PngImage png = new PngImage(width, height, PngColorType.TruecolorWithAlpha))
            {
                png.EmbedDigitalSignature(password);

                PngOptions options = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                png.Save(outputPath, options);
            }

            using (RasterImage loaded = (RasterImage)Image.Load(outputPath))
            {
                bool isSigned = loaded.IsDigitalSigned(password);
                Console.WriteLine($"Signature verification: {(isSigned ? "Valid" : "Invalid")}");
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
 * 1. When you need to generate a transparent PNG for a web UI and ensure its authenticity with a password‑protected digital signature.
 * 2. When you want to embed a secure watermark in PNG assets used in a mobile app and later verify that the image hasn't been tampered with.
 * 3. When you are building a document management system that stores PNG thumbnails and requires cryptographic proof of origin for each file.
 * 4. When you need to programmatically create PNG graphics for e‑commerce product images and guarantee they are signed before uploading to a CDN.
 * 5. When you are implementing compliance logging that saves PNG screenshots with an embedded signature and later checks the signature confidence during audits.
 */
