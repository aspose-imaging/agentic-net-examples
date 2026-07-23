using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded paths and password
            string inputPath = @"C:\Images\input.png";
            string outputPath = @"C:\Images\output_resized_signed.png";
            string password = "StrongPassword123!";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Resize to 1024x768 using Bicubic (CubicConvolution) resampling
                image.Resize(1024, 768, ResizeType.CubicConvolution);

                // Embed digital signature with the provided password
                // The method is available on RasterCachedImage, which PngImage inherits
                if (image is RasterCachedImage cachedImage)
                {
                    cachedImage.EmbedDigitalSignature(password);
                }

                // Save the processed image as PNG
                var pngOptions = new PngOptions();
                image.Save(outputPath, pngOptions);
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
 * 1. When preparing product screenshots for a web catalog, a developer can resize high‑resolution PNGs to a standard 1024×768 size with bicubic resampling and protect them with a password‑protected digital signature.
 * 2. When automating the generation of secure marketing assets, a C# service can downscale PNG logos to 1024×768 using CubicConvolution and embed a digital signature to verify authenticity.
 * 3. When delivering printable PDFs that include embedded PNG images, a developer may need to resize the PNGs to 1024×768 for consistent layout and sign them with a password to prevent tampering.
 * 4. When building a document management system that stores PNG thumbnails, the code can create 1024×768 thumbnails with high‑quality bicubic scaling and attach a digital signature for audit trails.
 * 5. When integrating PNG images into a regulated e‑learning platform, a developer can ensure each image meets the 1024×768 resolution requirement and is cryptographically signed with a secure password for compliance.
 */