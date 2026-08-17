// HOW-TO: Embed Digital Signature in JPEG Only When Image Exceeds Minimum Pixels in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.jpg";
        string outputPath = "output_signed.jpg";

        // Password for the digital signature
        string password = "mySecretPassword";

        // Minimum pixel count requirement (e.g., 1024 * 768)
        const long MinPixelCount = 1024 * 768;

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the image
            using (Image img = Image.Load(inputPath))
            {
                // Ensure the loaded image is a raster image (supports digital signature)
                if (img is RasterImage rasterImage)
                {
                    // Check pixel count requirement
                    long pixelCount = (long)rasterImage.Width * rasterImage.Height;
                    if (pixelCount < MinPixelCount)
                    {
                        Console.Error.WriteLine("Image does not meet the minimum pixel count requirement.");
                        return;
                    }

                    // Embed the digital signature
                    rasterImage.EmbedDigitalSignature(password);

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the signed image
                    rasterImage.Save(outputPath);
                }
                else
                {
                    Console.Error.WriteLine("The loaded image type does not support digital signatures.");
                }
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
 * 1. When you need to protect high‑resolution product photos by embedding a password‑protected digital signature only if they meet a 1024×768 pixel threshold.
 * 2. When a web service must reject low‑resolution uploads and sign only qualifying images before storing them in a secure archive.
 * 3. When generating legally binding scanned documents in C# and you want to embed a digital signature only on images large enough to retain signature quality.
 * 4. When automating a workflow that adds a tamper‑evident signature to JPEG assets for a marketing campaign, but only for images that satisfy a minimum pixel count.
 * 5. When implementing compliance checks that sign raster images with Aspose.Imaging in .NET, ensuring the signature is applied only to images that meet size requirements.
 */
