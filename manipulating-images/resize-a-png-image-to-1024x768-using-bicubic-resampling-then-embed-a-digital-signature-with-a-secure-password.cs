// HOW-TO: Resize PNG to 1024x768 With Bicubic Resampling And Add Digital Signature In C# (Aspose.Imaging for .NET)
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
            // Hard‑coded input, output and password
            string inputPath = @"C:\Images\source.png";
            string outputPath = @"C:\Images\output\resized_signed.png";
            string password = "MySecurePassword!";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image img = Image.Load(inputPath))
            {
                // Work with the raster representation
                var raster = img as RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("Loaded image is not a raster image.");
                    return;
                }

                // Resize to 1024x768 using Bicubic (CubicConvolution) resampling
                raster.Resize(1024, 768, ResizeType.CubicConvolution);

                // Embed a digital signature with the provided password
                raster.EmbedDigitalSignature(password);

                // Save the processed image as PNG
                raster.Save(outputPath, new PngOptions());
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
 * 1. When preparing product screenshots for a web gallery that must fit a 1024x768 layout while ensuring the image cannot be altered without the correct password.
 * 2. When generating printable marketing assets from high‑resolution PNGs, resizing them to standard dimensions and protecting them with a digital signature for copyright enforcement.
 * 3. When automating a batch process that converts user‑uploaded PNG avatars to a uniform size for a mobile app and adds a secure signature to verify authenticity.
 * 4. When creating archival copies of PNG diagrams that need to be downscaled for faster viewing but still require tamper‑evidence via password‑protected digital signatures.
 * 5. When integrating image processing into a document management system that stores PNG files at a fixed resolution and uses a digital signature to guarantee integrity during transfer.
 */
