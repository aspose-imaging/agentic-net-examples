// HOW-TO: Embed and Verify Password Protected Digital Signature in JPEG Using C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.jpg";
        string outputPath = "output.jpg";
        string password = "mySecretPassword";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load JPEG image from a file stream
            using (FileStream inputStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
            using (Image image = Image.Load(inputStream))
            {
                // Ensure the loaded image is a raster image
                RasterImage raster = image as RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("The loaded image is not a raster image.");
                    return;
                }

                // Embed digital signature using the provided password
                raster.EmbedDigitalSignature(password);

                // Verify that the image is digitally signed
                bool isSigned = raster.IsDigitalSigned(password);
                Console.WriteLine($"Digital signature embedded. Verification result: {isSigned}");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

                // Save the signed image
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
 * 1. When a developer needs to add a tamper‑evident signature to a JPEG before sending it to a client.
 * 2. When a system must ensure that an image file has not been altered by verifying a password‑protected digital signature.
 * 3. When an application stores confidential photos and wants to embed authentication data without changing the visual content.
 * 4. When integrating image security into a workflow that reads JPEGs from streams and saves the signed version to disk.
 * 5. When building a compliance solution that requires proof of origin for raster images using Aspose.Imaging in .NET.
 */
