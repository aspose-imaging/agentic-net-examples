using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Bmp; // Ensure BMP format support
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.bmp";
        string outputPath = @"C:\temp\output_rotated_signed.bmp";
        string password = "secret";

        try
        {
            // Verify input file exists
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

                // Embed a digital signature using the provided password
                // The loaded BMP image is a RasterCachedImage, so we can cast safely
                ((RasterCachedImage)image).EmbedDigitalSignature(password);

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
 * 1. When a desktop application needs to correct upside‑down scanned BMP documents and guarantee their integrity by embedding a digital signature before archiving.
 * 2. When an industrial automation system captures BMP images from a camera, rotates them 180° to match the physical orientation of the product, and signs them to prevent tampering during transmission.
 * 3. When a medical imaging workflow receives BMP scans that were stored inverted, rotates them for proper viewing and adds a password‑protected digital signature to comply with patient data security standards.
 * 4. When a game developer processes BMP sprite sheets that were exported upside down, rotates them and embeds a signature to verify that the assets have not been altered before packaging the game build.
 * 5. When a legal document management solution imports BMP scans of signed contracts, rotates them to the correct orientation and embeds a digital signature to ensure the files remain authentic in the repository.
 */