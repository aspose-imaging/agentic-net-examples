// HOW-TO: Embed and Verify Password Protected Digital Signature in JPEG with C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output_signed.jpg";
            string password = "mySecret";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outDir = Path.GetDirectoryName(outputPath) ?? ".";
            Directory.CreateDirectory(outDir);

            using (FileStream fs = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
            {
                using (RasterImage image = (RasterImage)Image.Load(fs))
                {
                    image.EmbedDigitalSignature(password);
                    image.Save(outputPath);
                }
            }

            using (RasterImage signedImage = (RasterImage)Image.Load(outputPath))
            {
                bool isSigned = signedImage.IsDigitalSigned(password);
                Console.WriteLine(isSigned ? "Signature verified." : "Signature verification failed.");
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
 * 1. When you need to protect a JPEG photo from unauthorized changes by embedding a password‑protected digital signature before sending it to clients.
 * 2. When your application must confirm that an uploaded JPEG has not been altered by verifying its embedded digital signature using a known password.
 * 3. When you want to store confidential branding or watermark information inside a JPEG file without visible changes, using a password‑secured signature for later validation.
 * 4. When integrating Aspose.Imaging into a C# workflow that archives medical or legal images, ensuring each file is signed and can be programmatically verified for integrity.
 * 5. When building a secure image‑sharing service that signs JPEGs on upload and checks the signature on download to prevent tampering.
 */
