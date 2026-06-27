using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.jpg";
        string outputPath = "output.jpg";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            // Load image from a memory stream
            byte[] imageData = File.ReadAllBytes(inputPath);
            using (var stream = new MemoryStream(imageData))
            {
                using (var image = Image.Load(stream))
                {
                    // Cast to RasterImage to access digital signature methods
                    var raster = (RasterImage)image;

                    // Embed digital signature with a valid password
                    string password = "secure123";
                    raster.EmbedDigitalSignature(password);

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the signed image
                    image.Save(outputPath);

                    // Verify the signature
                    bool isSigned = raster.IsDigitalSigned(password);
                    Console.WriteLine($"Digital signature verification: {(isSigned ? "Success" : "Failure")}");
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
 * 1. When a C# web service receives a JPEG upload via a memory stream and must embed a password‑protected digital signature before storing the file for compliance auditing.
 * 2. When an enterprise document management system needs to programmatically sign scanned JPEG invoices with a secure password and verify the signature to prevent tampering.
 * 3. When a desktop application processes user‑selected JPEG photos, adds a digital signature for copyright protection, saves the signed image, and confirms the signature integrity in one workflow.
 * 4. When a batch processing script reads JPEG images from a network share, embeds a digital signature using a shared secret, writes the signed files to an output folder, and logs verification results for quality control.
 * 5. When a secure messaging platform encrypts JPEG attachments, applies a password‑protected digital signature to ensure authenticity, and validates the signature before delivering the image to the recipient.
 */