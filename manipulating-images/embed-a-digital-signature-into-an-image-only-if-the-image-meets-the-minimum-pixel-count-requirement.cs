// HOW-TO: Embed Digital Signature in Image Only If Minimum Pixels Met in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded paths and password
            string inputPath = "input.jpg";
            string outputPath = "output.png";
            string password = "secret";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load image
            using (Image image = Image.Load(inputPath))
            {
                // Ensure we have a RasterImage
                if (image is RasterImage rasterImage)
                {
                    // Check minimum pixel count (16,384 total pixels)
                    if (rasterImage.Width * rasterImage.Height < 16384)
                    {
                        Console.Error.WriteLine("Image does not meet minimum pixel count requirement.");
                        return;
                    }

                    // Validate password length
                    if (password.Length < 4)
                    {
                        Console.Error.WriteLine("Password must be at least 4 characters long.");
                        return;
                    }

                    // Embed digital signature
                    rasterImage.EmbedDigitalSignature(password);

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

                    // Save the signed image
                    rasterImage.Save(outputPath);
                }
                else
                {
                    Console.Error.WriteLine("Loaded image is not a RasterImage.");
                    return;
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
 * 1. When a developer needs to protect high‑resolution product photos by embedding a password‑protected digital signature, but wants to skip low‑resolution images that don’t meet a 16,384‑pixel threshold.
 * 2. When an application processes user‑uploaded JPEG files and must add a secure signature before converting them to PNG for archival, ensuring only images large enough are signed.
 * 3. When a document management system validates image size before applying a digital watermark using Aspose.Imaging to guarantee the signature is applied only to sufficiently detailed raster images.
 * 4. When a C# service automates compliance checks by embedding a digital signature into scanned images, rejecting any image smaller than the required pixel count to avoid weak signatures.
 * 5. When a developer builds a batch‑processing tool that reads images, verifies a minimum pixel count, embeds a password‑protected signature, and saves the signed output in a different format for secure distribution.
 */
