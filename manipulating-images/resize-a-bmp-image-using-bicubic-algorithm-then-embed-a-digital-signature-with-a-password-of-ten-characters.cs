using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.bmp";
        string outputPath = "output/resized_signed.bmp";

        // Check input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load BMP image as RasterImage
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Resize using Bicubic (CubicConvolution) algorithm
                int newWidth = image.Width / 2;   // example new size
                int newHeight = image.Height / 2;
                image.Resize(newWidth, newHeight, ResizeType.CubicConvolution);

                // Embed digital signature with a 10‑character password
                image.EmbedDigitalSignature("TenCharPwd");

                // Save the processed image as BMP
                image.Save(outputPath, new BmpOptions());
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
 * 1. When a desktop application needs to generate smaller BMP thumbnails for faster preview while protecting the image with a password‑protected digital signature.
 * 2. When an automated batch job processes scanned BMP documents, halves their dimensions using Bicubic interpolation, and embeds a ten‑character password to ensure authenticity.
 * 3. When a medical imaging system must reduce the size of BMP X‑ray images for storage efficiency and embed a secure signature to comply with data integrity regulations.
 * 4. When a game development pipeline resizes BMP textures to fit lower‑resolution assets and adds a digital signature to prevent tampering.
 * 5. When a document management system converts high‑resolution BMP scans to smaller, signed BMP files before uploading them to a secure server.
 */