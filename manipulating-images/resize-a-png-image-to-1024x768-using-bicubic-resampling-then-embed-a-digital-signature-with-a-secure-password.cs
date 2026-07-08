using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.png";
            string outputPath = @"C:\Images\output_resized_signed.png";
            string password = "StrongPassword123!";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Resize to 1024x768 using Bicubic (CubicConvolution) resampling
                image.Resize(1024, 768, ResizeType.CubicConvolution);

                // Embed a digital signature with the provided password
                image.EmbedDigitalSignature(password);

                // Save the processed image as PNG
                image.Save(outputPath, new PngOptions());
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
 * 1. When a web application must generate thumbnail previews of user‑uploaded PNG files at a fixed 1024×768 resolution while preserving visual quality with Bicubic resampling.
 * 2. When an e‑commerce platform needs to standardize product images to 1024×768 PNG size and protect them from tampering by embedding a password‑protected digital signature.
 * 3. When a desktop utility processes scanned documents saved as PNG, resizing them for faster loading and adding a secure signature to verify authenticity.
 * 4. When a content management system automatically prepares PNG assets for print by resizing them to 1024×768 and ensuring they are signed with a strong password for compliance.
 * 5. When a batch‑processing script converts high‑resolution PNG graphics to a uniform size using Aspose.Imaging’s CubicConvolution filter and secures each file with an encrypted digital signature.
 */