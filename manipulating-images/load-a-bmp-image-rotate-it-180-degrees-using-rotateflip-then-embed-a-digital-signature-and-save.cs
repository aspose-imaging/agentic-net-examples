using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\input.bmp";
        string outputPath = @"C:\temp\output_rotated_signed.bmp";

        // Ensure any runtime exception is reported cleanly
        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Rotate the image 180 degrees (no flip)
                image.RotateFlip(RotateFlipType.Rotate180FlipNone);

                // Embed a digital signature using a password
                // The EmbedDigitalSignature method is defined on RasterCachedImage,
                // which is a base class for raster images such as BMP.
                if (image is RasterCachedImage rasterImage)
                {
                    rasterImage.EmbedDigitalSignature("myPassword");
                }

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

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
 * 1. When an industrial automation system captures BMP screenshots of machine panels and needs to rotate them 180 degrees and embed a password‑protected digital signature before archiving for compliance.
 * 2. When a medical imaging application receives BMP scans from legacy devices, must correct the orientation by rotating 180°, and securely sign the image to guarantee patient data integrity.
 * 3. When a document management workflow processes scanned BMP forms, rotates them to match the original page layout, and adds a digital signature to verify that the file has not been altered.
 * 4. When a game development tool exports BMP textures, flips them upside down for the engine’s coordinate system and embeds a signature to prevent unauthorized modification of assets.
 * 5. When a security‑focused desktop utility batch‑processes BMP screenshots, rotates each image 180°, applies a password‑protected digital signature, and saves the result for tamper‑evident storage.
 */