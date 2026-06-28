using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded paths
        string outputPath = "output\\highres.tif";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Create TIFF options
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
            tiffOptions.Compression = TiffCompressions.Lzw;
            tiffOptions.Photometric = TiffPhotometrics.Rgb;
            tiffOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;
            tiffOptions.ByteOrder = TiffByteOrder.LittleEndian;

            // Define image size
            int width = 1000;
            int height = 1000;

            // Create a new TIFF image
            using (TiffImage tiffImage = (TiffImage)Image.Create(tiffOptions, width, height))
            {
                // Set resolution to 300 DPI
                tiffImage.SetResolution(300, 300);

                // Fill the image with a solid color
                Graphics graphics = new Graphics(tiffImage);
                graphics.Clear(Color.White);

                // Embed a digital signature with a valid password
                tiffImage.EmbedDigitalSignature("secure123");

                // Save the image
                tiffImage.Save(outputPath);

                // Verify the digital signature
                bool isSigned = tiffImage.IsDigitalSigned("secure123", 0);
                Console.WriteLine($"Signature verification result: {isSigned}");
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
 * 1. When a developer needs to generate a high‑resolution 300 DPI TIFF file for printing and ensure its authenticity by embedding a password‑protected digital signature.
 * 2. When a medical imaging application must create a losslessly compressed LZW TIFF image, set precise DPI, and later verify that the image has not been tampered with.
 * 3. When a document management system requires storing scanned documents as RGB TIFFs with a known resolution and a verifiable digital signature for compliance audits.
 * 4. When a GIS (geographic information system) tool needs to produce a 1000 × 1000 pixel TIFF map tile, embed a secure signature, and confirm the signature after saving.
 * 5. When an archival workflow automates the creation of white‑background TIFF assets, applies a 300 DPI resolution, and validates the embedded signature before archiving the file.
 */