// HOW-TO: Resize JPEG with Lanczos and Add Password Protected Signature in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output\\output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                int newWidth = image.Width / 2;
                int newHeight = image.Height / 2;
                image.Resize(newWidth, newHeight, ResizeType.LanczosResample);

                if (image is RasterImage raster)
                {
                    string password = "myPassword";
                    raster.EmbedDigitalSignature(password);
                }

                PngOptions pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
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
 * 1. When you need to create a smaller, high‑quality PNG preview of a large JPEG for a web gallery while ensuring the image cannot be altered without the correct password.
 * 2. When you must embed a tamper‑evident digital signature into a raster image before archiving it in a secure document management system.
 * 3. When an e‑commerce platform requires product photos to be resized using Lanczos resampling and saved as PNG with a password‑protected signature for brand protection.
 * 4. When a mobile app generates thumbnail PNGs from user‑uploaded JPEGs and wants to guarantee authenticity by adding a password‑protected digital signature.
 * 5. When a legal or medical workflow needs to downscale diagnostic JPEG scans, convert them to lossless PNG, and embed a password‑protected signature to comply with data integrity regulations.
 */
