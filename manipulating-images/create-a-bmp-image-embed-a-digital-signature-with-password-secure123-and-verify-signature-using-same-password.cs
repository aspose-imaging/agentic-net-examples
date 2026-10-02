// HOW-TO: Embed and Verify Password Protected Digital Signature in BMP with C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded paths
            string outputDirectory = "output";
            string bmpPath = Path.Combine(outputDirectory, "signed_image.bmp");

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(bmpPath));

            // Create a blank BMP image (100x100) with white background
            using (var image = Image.Create(
                new BmpOptions { BitsPerPixel = 24 },
                100, 100))
            {
                // Fill with white (optional, default is black)
                image.Save(bmpPath);
            }

            // Verify the created file exists
            if (!File.Exists(bmpPath))
            {
                Console.Error.WriteLine($"File not found: {bmpPath}");
                return;
            }

            // Load the image as RasterImage and embed digital signature
            using (var raster = (RasterImage)Image.Load(bmpPath))
            {
                string password = "Secure123";
                raster.EmbedDigitalSignature(password);
                raster.Save(bmpPath);
            }

            // Load again to verify the signature
            using (var raster = (RasterImage)Image.Load(bmpPath))
            {
                string password = "Secure123";
                bool isSigned = raster.IsDigitalSigned(password);
                Console.WriteLine(isSigned ? "Signature verified." : "Signature verification failed.");
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
 * 1. When you need to protect a BMP file from tampering by embedding a password‑protected digital signature before distributing it to clients.
 * 2. When an application must confirm the authenticity of a received BMP image by verifying its digital signature using the same password.
 * 3. When you want to automate the creation of blank BMP canvases and secure them with a signature as part of a document‑generation workflow.
 * 4. When regulatory compliance requires that raster images be signed and later validated without altering the visual content.
 * 5. When integrating Aspose.Imaging into a C# service that stores medical or legal BMP scans and needs to ensure they remain unchanged and traceable.
 */
