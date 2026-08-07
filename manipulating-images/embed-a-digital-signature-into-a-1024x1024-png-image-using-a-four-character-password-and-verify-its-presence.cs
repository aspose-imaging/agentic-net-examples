using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output_signed.png";

            // Four‑character password for the digital signature
            string password = "ABCD";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists (creates if missing)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Work with raster images (PNG is raster)
                if (image is RasterImage rasterImage)
                {
                    // Embed the digital signature using the password
                    rasterImage.EmbedDigitalSignature(password);

                    // Save the signed image
                    rasterImage.Save(outputPath);

                    // Verify the signature on the saved image
                    using (Image verifyImage = Image.Load(outputPath))
                    {
                        if (verifyImage is RasterImage verifyRaster)
                        {
                            bool isSigned = verifyRaster.IsDigitalSigned(password);
                            Console.WriteLine($"Signature verification result: {isSigned}");
                        }
                        else
                        {
                            Console.Error.WriteLine("Verification image is not a raster image.");
                        }
                    }
                }
                else
                {
                    Console.Error.WriteLine("Loaded image is not a raster image.");
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
 * 1. When a developer needs to protect a PNG logo with a four‑character password before distributing it to partners, they can embed a digital signature and later verify it to ensure authenticity.
 * 2. When an e‑commerce platform wants to embed a hidden password‑protected signature into product thumbnail images to detect unauthorized copying, this code can sign and validate the PNG files.
 * 3. When a document management system stores scanned PNG pages and must confirm that each page has not been altered, developers can use this routine to embed and later check a digital signature with a simple password.
 * 4. When a mobile app generates user‑created PNG avatars and requires a lightweight method to verify the source before uploading, the code can embed a short password signature and verify it on the server.
 * 5. When a compliance audit requires proof that a specific PNG diagram was approved at a certain time, developers can embed a four‑character password signature into the image and later validate its presence during the audit.
 */