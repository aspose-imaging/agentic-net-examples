using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output file path
            string outputPath = "Output\\signed.png";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a 1024x1024 PNG image with TruecolorWithAlpha
            using (PngImage png = new PngImage(1024, 1024, PngColorType.TruecolorWithAlpha))
            {
                // Fill the image with opaque white pixels
                int[] whitePixels = new int[1024 * 1024];
                for (int i = 0; i < whitePixels.Length; i++)
                {
                    whitePixels[i] = unchecked((int)0xFFFFFFFF); // ARGB white
                }
                png.SaveArgb32Pixels(new Rectangle(0, 0, 1024, 1024), whitePixels);

                // Embed a digital signature using a four‑character password
                string password = "ABCD";
                png.EmbedDigitalSignature(password);

                // Verify that the signature was embedded
                bool isSigned = png.IsDigitalSigned(password);
                Console.WriteLine($"Signature embedded: {isSigned}");

                // Save the signed image
                png.Save(outputPath);
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
 * 1. When a developer needs to protect a product logo PNG from unauthorized alteration by embedding a password‑protected digital signature before publishing it on a website.
 * 2. When an e‑commerce platform wants to embed a four‑character password signature into order confirmation PNG receipts to verify authenticity during customer support audits.
 * 3. When a medical imaging system must embed a digital signature into PNG scans of patient reports to ensure the images have not been tampered with when shared between clinics.
 * 4. When a government agency creates PNG maps with a password‑protected signature to confirm that the map files distributed to field agents are genuine and unmodified.
 * 5. When a developer builds a C# workflow that automatically signs and validates PNG thumbnails of confidential documents before storing them in a secure archive.
 */