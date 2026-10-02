// HOW-TO: Crop, Resize PNG to 400x400 and Add Digital Signature in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Crop using a rectangle
                Rectangle cropRect = new Rectangle(50, 50, 200, 200);
                image.Crop(cropRect);

                // Resize to 400x400
                image.Resize(400, 400, ResizeType.NearestNeighbourResample);

                // Embed digital signature
                image.EmbedDigitalSignature("myPassword");

                // Save as PNG
                PngOptions options = new PngOptions();
                image.Save(outputPath, options);
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
 * 1. When you need to extract a specific region from a PNG, scale it to a standard thumbnail size, and protect it with a digital signature for secure distribution.
 * 2. When generating product catalog images that must be uniformly 400 × 400 pixels and include a cryptographic signature to verify authenticity.
 * 3. When preparing user‑uploaded PNG avatars for a web application, cropping the face area, resizing it, and embedding a signature to prevent tampering.
 * 4. When creating compliance‑ready screenshots that require a defined crop, fixed dimensions, and a password‑protected signature for audit trails.
 * 5. When automating batch processing of PNG assets to enforce consistent size, remove unwanted borders, and embed a digital signature for copyright enforcement.
 */
