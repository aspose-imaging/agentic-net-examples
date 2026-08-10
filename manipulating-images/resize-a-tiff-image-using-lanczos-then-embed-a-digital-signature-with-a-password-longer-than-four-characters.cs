// HOW-TO: Resize TIFF with Lanczos and Add Password Protected Digital Signature in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output paths
            string inputPath = @"c:\temp\input.tif";
            string outputPath = @"c:\temp\output_resized_signed.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TIFF image
            using (TiffImage image = (TiffImage)Image.Load(inputPath))
            {
                // Resize using Lanczos (AdaptiveResample) – here we halve the dimensions
                int newWidth = image.Width / 2;
                int newHeight = image.Height / 2;
                image.Resize(newWidth, newHeight, ResizeType.AdaptiveResample);

                // Embed a digital signature with a password longer than four characters
                string password = "StrongPwd123";
                image.EmbedDigitalSignature(password);

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
 * 1. When a medical imaging system must reduce large TIFF scans for faster transmission while ensuring the file remains tamper‑evident with a password‑protected digital signature.
 * 2. When a publishing workflow needs to create smaller, high‑quality TIFF thumbnails for print previews and embed a signature to verify authorship.
 * 3. When a document management application archives scanned contracts as TIFFs, resizes them to save storage, and adds a secure digital signature to meet compliance requirements.
 * 4. When a GIS platform processes high‑resolution satellite TIFF layers, downsamples them using Lanczos for analysis and signs them to prevent unauthorized modifications.
 * 5. When an e‑commerce site generates product catalog TIFF images, halves their dimensions for web use and embeds a password‑protected signature to protect brand integrity.
 */
