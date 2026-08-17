// HOW-TO: Create High Resolution 300 DPI TIFF with Digital Signature in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output file path
            string outputPath = "output\\highres.tif";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure TIFF options
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
            {
                BitsPerSample = new ushort[] { 8, 8, 8 },
                Compression = TiffCompressions.Lzw,
                Photometric = TiffPhotometrics.Rgb,
                PlanarConfiguration = TiffPlanarConfigs.Contiguous
            };

            int width = 1000;
            int height = 1000;

            // Create a new TIFF image
            using (Image image = Image.Create(tiffOptions, width, height))
            {
                // Set resolution to 300 DPI
                ((RasterImage)image).SetResolution(300, 300);

                // Fill the canvas with white
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Embed a digital signature with a valid password
                ((RasterCachedImage)image).EmbedDigitalSignature("secure123");

                // Save the image
                image.Save(outputPath);
            }

            // Verify the digital signature
            string inputPath = outputPath;
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (Image loadedImage = Image.Load(inputPath))
            {
                bool isSigned = ((RasterCachedImage)loadedImage).IsDigitalSigned("secure123", 80);
                Console.WriteLine($"Signature verification (valid password): {isSigned}");

                bool isSignedInvalid = ((RasterCachedImage)loadedImage).IsDigitalSigned("123", 80);
                Console.WriteLine($"Signature verification (invalid password): {isSignedInvalid}");
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
 * 1. When you need to generate a printable 300 DPI TIFF for archival documents and ensure its authenticity with a password‑protected digital signature.
 * 2. When a medical imaging system must produce high‑resolution TIFF scans and embed a signature to comply with regulatory audit trails.
 * 3. When a publishing workflow requires creating large TIFF images for print and later verifying that the files have not been tampered with.
 * 4. When a legal document management app creates TIFF evidence files and needs to embed and later confirm a digital signature for court admissibility.
 * 5. When an automated batch process generates high‑quality TIFF assets and must programmatically check the embedded signature before distribution.
 */
