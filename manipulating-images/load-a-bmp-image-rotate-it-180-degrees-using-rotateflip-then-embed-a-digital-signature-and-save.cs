// HOW-TO: Rotate BMP 180 Degrees And Embed Digital Signature In C# (Aspose.Imaging for .NET)
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
            string inputPath = @"C:\temp\input.bmp";
            string outputPath = @"C:\temp\output_rotated_signed.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Rotate the image 180 degrees (no flip)
                image.RotateFlip(RotateFlipType.Rotate180FlipNone);

                // Embed a digital signature using a password
                // The method is defined on RasterCachedImage and RasterCachedMultipageImage
                if (image is RasterCachedImage rasterImage)
                {
                    rasterImage.EmbedDigitalSignature("myPassword123");
                }
                else if (image is RasterCachedMultipageImage multiPageImage)
                {
                    multiPageImage.EmbedDigitalSignature("myPassword123");
                }

                // Save the processed image
                image.Save(outputPath);
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
 * 1. When you need to rotate a scanned BMP file 180° and protect it with a password‑based digital signature before storing it in an archive.
 * 2. When a medical imaging system must flip BMP X‑ray images upside down and embed a signature to verify that the image has not been altered.
 * 3. When an e‑commerce platform prepares product photos in BMP format for printing, rotates them to match packaging orientation, and signs them to guarantee authenticity.
 * 4. When a compliance‑driven application signs BMP screenshots after rotating them to meet regulatory requirements for tamper‑evidence.
 * 5. When a document management workflow automatically processes BMP scans, rotates them for correct viewing, and embeds a digital signature to ensure traceability.
 */
