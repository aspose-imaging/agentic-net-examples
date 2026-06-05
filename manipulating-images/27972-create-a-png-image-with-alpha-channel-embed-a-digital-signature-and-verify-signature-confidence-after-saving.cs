using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define output path (hardcoded)
            string outputPath = "Output/output.png";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Image dimensions (must be at least 200x200 for digital signature)
            int width = 200;
            int height = 200;

            // Create a source bound to the output file
            Source source = new FileCreateSource(outputPath, false);

            // Configure PNG options with alpha channel
            PngOptions pngOptions = new PngOptions
            {
                Source = source,
                ColorType = PngColorType.TruecolorWithAlpha
            };

            // Create a PNG canvas
            using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, width, height))
            {
                // Embed a digital signature with a valid password
                canvas.EmbedDigitalSignature("secure123");

                // Save the image (bound source, so no path needed)
                canvas.Save();
            }

            // Reload the saved image to verify the signature
            using (RasterImage loaded = (RasterImage)Image.Load(outputPath))
            {
                // Verify that the image is digitally signed (threshold 80)
                bool isSigned = loaded.IsDigitalSigned("secure123", 80);
                Console.WriteLine(isSigned
                    ? "Signature verification succeeded."
                    : "Signature verification failed.");
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
 * 1. When a developer needs to generate a PNG logo with transparency and embed a secure digital signature to protect brand assets before distributing them to partners.
 * 2. When a medical imaging application must create anonymized PNG scans with an alpha channel and sign them to ensure integrity and compliance during archival.
 * 3. When an e‑commerce platform wants to produce product thumbnail images that include a hidden watermark signature, then verify the signature confidence after upload to prevent tampering.
 * 4. When a government agency creates official PNG documents (e.g., certificates) that require an embedded digital signature and later needs to programmatically confirm the signature with a confidence threshold of 80%.
 * 5. When a mobile game developer generates PNG sprites with transparency, embeds a signature to guard against asset piracy, and validates the signature before loading the sprite at runtime.
 */