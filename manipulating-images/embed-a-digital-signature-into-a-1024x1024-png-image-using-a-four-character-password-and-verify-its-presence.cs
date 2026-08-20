// HOW-TO: Embed and Verify Digital Signature in PNG Image Using C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Path safety wrapper
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Images\source.png";
            string outputPath = @"C:\Images\signed.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access digital signature methods
                if (image is RasterImage rasterImage)
                {
                    // Four‑character password for the signature
                    string password = "ABCD";

                    // Embed the digital signature
                    rasterImage.EmbedDigitalSignature(password);

                    // Save the signed image
                    rasterImage.Save(outputPath);
                    
                    // Verify the signature
                    bool isSigned = rasterImage.IsDigitalSigned(password);
                    Console.WriteLine(isSigned
                        ? "Digital signature successfully embedded and verified."
                        : "Digital signature verification failed.");
                }
                else
                {
                    Console.Error.WriteLine("The loaded file is not a raster image.");
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
 * 1. When you need to protect a PNG asset from tampering by embedding a password‑protected digital signature before sending it to a client.
 * 2. When an application must confirm that a received PNG file has not been altered by checking its embedded digital signature during import.
 * 3. When you want to add a lightweight security layer to product screenshots or marketing graphics that are distributed via email or download portals.
 * 4. When a document management system stores PNG diagrams and requires automated verification of their authenticity using a known password.
 * 5. When you are building a C# service that signs and validates PNG images to comply with internal audit or regulatory requirements.
 */
