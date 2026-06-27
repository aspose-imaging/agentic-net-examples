using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output BMP file path
            string outputPath = "output.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a file source bound to the output path
            Source source = new FileCreateSource(outputPath, false);
            BmpOptions options = new BmpOptions() { Source = source };

            // Define canvas size (minimum 200x200 for digital signature)
            int width = 200;
            int height = 200;

            // Create BMP canvas
            using (BmpImage canvas = (BmpImage)Image.Create(options, width, height))
            {
                // Inset crop of 20 pixels on each side
                canvas.Crop(20, 20, 20, 20);

                // Rotate 90 degrees clockwise
                canvas.Rotate(90f, true, Color.White);

                // Embed digital signature with a valid password
                canvas.EmbedDigitalSignature("secure123");

                // Save the image (bound source, so just call Save)
                canvas.Save();
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
 * 1. When generating a printable ID badge in a Windows desktop app that must be saved as a BMP, trimmed to remove margins, rotated for landscape layout, and digitally signed for authenticity.
 * 2. When preparing a scanned engineering drawing for archival, cropping a 20‑pixel border, rotating it to match the standard orientation, and embedding a password‑protected digital signature to meet compliance regulations.
 * 3. When building a C# utility that creates thumbnail previews of legacy BMP assets, applying an inset crop to remove unwanted edges, rotating the image for UI display, and signing it to prevent tampering.
 * 4. When automating the production of secure QR‑code stickers where the BMP background is cropped, rotated to align with printing equipment, and digitally signed to verify the source before distribution.
 * 5. When developing a medical imaging workflow that outputs BMP scans, needs to remove a uniform border, rotate the image to the correct anatomical orientation, and embed a digital signature to ensure patient data integrity.
 */