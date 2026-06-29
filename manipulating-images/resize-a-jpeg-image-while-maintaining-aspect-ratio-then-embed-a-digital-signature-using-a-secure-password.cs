using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hardcoded input, output and password
        string inputPath = "input.jpg";
        string outputPath = "output.jpg";
        string password = "securePassword";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load JPEG image
            using (JpegImage image = new JpegImage(inputPath))
            {
                // Desired maximum dimension (maintain aspect ratio)
                const int maxDimension = 800;

                // Calculate new size preserving aspect ratio
                double aspectRatio = (double)image.Width / image.Height;
                int newWidth, newHeight;

                if (image.Width >= image.Height)
                {
                    newWidth = maxDimension;
                    newHeight = (int)(maxDimension / aspectRatio);
                }
                else
                {
                    newHeight = maxDimension;
                    newWidth = (int)(maxDimension * aspectRatio);
                }

                // Resize the image
                image.Resize(newWidth, newHeight);

                // Embed digital signature using the provided password
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
 * 1. When a web application needs to generate thumbnail previews of user‑uploaded JPEG photos that fit within an 800‑pixel box while preserving the original aspect ratio and also protect the files with a password‑protected digital signature.
 * 2. When an e‑commerce platform must automatically downsize product images to reduce bandwidth, keep the visual proportions, and embed a secure signature to verify that the images have not been tampered with before publishing them online.
 * 3. When a mobile app synchronizes photos to a cloud service, it can resize each JPEG to a maximum dimension of 800 pixels to save storage, then embed a digital signature using a secret password to ensure integrity during transmission.
 * 4. When a legal document management system stores scanned JPEG pages, it can resize them for faster indexing while maintaining aspect ratio and embed a password‑protected digital signature to certify authenticity.
 * 5. When a digital marketing agency prepares campaign assets, it can batch‑process JPEG banners by resizing them to a standard size and embedding a secure digital signature to guarantee that the final images are the approved versions.
 */