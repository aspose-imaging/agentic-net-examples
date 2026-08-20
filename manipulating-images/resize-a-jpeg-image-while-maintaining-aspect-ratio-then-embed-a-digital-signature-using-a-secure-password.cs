// HOW-TO: Resize JPEG and Add Password Protected Digital Signature in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.jpg";
            string outputPath = "output/resized_signed.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load JPEG image
            using (JpegImage image = (JpegImage)Image.Load(inputPath))
            {
                // Define maximum width while preserving aspect ratio
                int maxWidth = 800;
                int newWidth = image.Width;
                int newHeight = image.Height;

                if (image.Width > maxWidth)
                {
                    newWidth = maxWidth;
                    newHeight = (int)((double)image.Height * maxWidth / image.Width);
                }

                // Resize image
                image.Resize(newWidth, newHeight);

                // Embed digital signature with a secure password
                image.EmbedDigitalSignature("SecurePass123");

                // Save with JPEG options
                JpegOptions jpegOptions = new JpegOptions
                {
                    Quality = 90
                };
                image.Save(outputPath, jpegOptions);
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
 * 1. When you need to shrink large photos for web pages while keeping their original proportions and ensure the file cannot be altered without a password.
 * 2. When an e‑commerce platform must generate product thumbnails that are smaller than 800 px wide and embed a secure digital signature for authenticity.
 * 3. When a document management system processes uploaded JPEG scans, resizes them to a standard width and signs them to prevent tampering.
 * 4. When a mobile app prepares user‑taken pictures for cloud storage, reducing file size and adding a password‑protected signature for compliance.
 * 5. When a legal firm archives evidence images, automatically resizing them for storage efficiency and embedding a digital signature to verify integrity.
 */
