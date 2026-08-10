// HOW-TO: Check If JPEG Is Digitally Signed and Add Signature in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.jpg";
            string outputPath = "output.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists (null‑safe)
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for digital signature operations
                RasterImage raster = (RasterImage)image;

                // Passwords as per requirements
                string validPassword = "secure123";
                string invalidPassword = "123";

                // Check if already signed with a valid password
                bool alreadySigned = raster.IsDigitalSigned(validPassword);

                if (!alreadySigned)
                {
                    // Embed a new digital signature using the valid password
                    raster.EmbedDigitalSignature(validPassword);
                }

                // Save the (potentially) signed image
                raster.Save(outputPath);
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
 * 1. When you need to ensure a JPEG file hasn't been tampered with before adding a new digital signature in a C# application.
 * 2. When an automated workflow must verify existing digital signatures on images using a password before embedding additional security metadata.
 * 3. When a document management system stores scanned photos and must sign only unsigned images to avoid duplicate signatures.
 * 4. When a compliance tool checks for a valid digital signature on product images and signs them if the required password is missing.
 * 5. When a batch processing script processes a folder of images, validates each image's signature status, and applies a secure signature to unsigned files.
 */
