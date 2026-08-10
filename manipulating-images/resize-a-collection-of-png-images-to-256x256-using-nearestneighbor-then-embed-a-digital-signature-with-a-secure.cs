// HOW-TO: Resize Multiple PNG Images to 256x256 and Add Secure Digital Signature in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input and output directories
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            // Validate input directory
            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Get all PNG files in the input directory
            string[] files = Directory.GetFiles(inputDirectory, "*.png");

            foreach (string inputPath in files)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Prepare output file path
                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + "_resized.png");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load, resize, embed signature, and save
                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    // Resize to 256x256 using default NearestNeighbourResample
                    image.Resize(256, 256);

                    // Embed digital signature with a secure password
                    image.EmbedDigitalSignature("secure123");

                    // Save the processed image
                    image.Save(outputPath);
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
 * 1. When you need to batch‑process user‑uploaded avatars to a fixed 256×256 size while protecting them with a password‑protected digital signature.
 * 2. When a web service must generate thumbnail PNGs for a product catalog and ensure each thumbnail is cryptographically signed to prevent tampering.
 * 3. When an automated pipeline prepares PNG assets for a mobile app, resizing them uniformly and embedding a digital signature for integrity verification.
 * 4. When a document management system stores PNG scans and requires each file to be resized for storage efficiency and signed with a secure password for compliance.
 * 5. When a security‑focused application needs to resize a batch of PNG logos and embed a password‑protected signature before distributing them to partners.
 */
