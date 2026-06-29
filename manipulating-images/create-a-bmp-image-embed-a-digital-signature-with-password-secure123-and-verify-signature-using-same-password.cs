using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded output path
            string outputPath = "output.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a file source bound to the output path
            Source source = new FileCreateSource(outputPath, false);

            // BMP save options with the source
            BmpOptions options = new BmpOptions() { Source = source };

            // Create a 200x200 BMP canvas (minimum size requirement)
            using (RasterImage canvas = (RasterImage)Image.Create(options, 200, 200))
            {
                // Embed digital signature with the specified password
                canvas.EmbedDigitalSignature("Secure123");

                // Save the bound image
                canvas.Save();

                // Verify the digital signature using the same password
                bool isSigned = canvas.IsDigitalSigned("Secure123");
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
 * 1. When a developer must generate a BMP thumbnail for a document management system and ensure its authenticity by embedding a password‑protected digital signature.
 * 2. When an application needs to create a secure BMP watermark for legal contracts, embedding a signature that can be later verified with the same password.
 * 3. When a C# service produces BMP icons for software installers and wants to prevent tampering by signing the image with a known passphrase.
 * 4. When a forensic tool requires generating a BMP evidence image and embedding a digital signature to guarantee chain‑of‑custody integrity.
 * 5. When a desktop utility saves user‑drawn BMP graphics and needs to later confirm that the file has not been altered by checking the embedded signature with the original password.
 */