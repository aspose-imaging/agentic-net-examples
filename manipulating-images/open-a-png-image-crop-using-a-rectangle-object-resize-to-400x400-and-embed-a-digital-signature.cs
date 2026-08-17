// HOW-TO: Crop, Resize PNG And Embed Digital Signature In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/sample.png";
        string outputPath = "Output/processed.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (PngImage image = (PngImage)Image.Load(inputPath))
            {
                var cropRect = new Rectangle(0, 0, image.Width / 2, image.Height / 2);
                image.Crop(cropRect);
                image.Resize(400, 400);
                image.EmbedDigitalSignature("secure123");

                var saveOptions = new PngOptions();
                image.Save(outputPath, saveOptions);
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
 * 1. When you need to generate a thumbnail of a PNG by cropping the top‑left quadrant and resizing it to a fixed 400 × 400 size while adding a tamper‑evident digital signature.
 * 2. When an e‑commerce platform must prepare product images that are uniformly sized and securely signed before uploading to a CDN.
 * 3. When a document management system extracts a portion of a scanned PNG, standardizes its dimensions, and embeds a signature to verify authenticity.
 * 4. When a mobile app creates profile picture previews from user‑uploaded PNGs, ensuring the image is cropped, resized, and cryptographically signed for later validation.
 * 5. When a compliance tool processes PNG screenshots, crops sensitive areas, resizes them for storage efficiency, and embeds a digital signature to meet audit requirements.
 */
