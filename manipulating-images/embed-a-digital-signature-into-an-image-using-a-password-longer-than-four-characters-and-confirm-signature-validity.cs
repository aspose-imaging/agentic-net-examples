using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png; // Adjust if using other formats

class Program
{
    static void Main()
    {
        // Hardcoded paths
        string inputPath = "input.png";
        string outputPath = "output.png";
        // Password longer than four characters
        string password = "StrongPass123";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Try to embed the digital signature based on the actual image type
                if (image is RasterImage rasterImage)
                {
                    rasterImage.EmbedDigitalSignature(password);
                    rasterImage.Save(outputPath);
                }
                else if (image is RasterCachedImage cachedImage)
                {
                    cachedImage.EmbedDigitalSignature(password);
                    cachedImage.Save(outputPath);
                }
                else if (image is RasterCachedMultipageImage multiPageImage)
                {
                    multiPageImage.EmbedDigitalSignature(password);
                    multiPageImage.Save(outputPath);
                }
                else
                {
                    Console.Error.WriteLine("Unsupported image type for digital signature embedding.");
                    return;
                }
            }

            // Load the saved image to verify the signature
            using (Image savedImage = Image.Load(outputPath))
            {
                bool isSigned = false;

                if (savedImage is RasterImage savedRaster)
                {
                    isSigned = savedRaster.IsDigitalSigned(password);
                }
                else if (savedImage is RasterCachedImage savedCached)
                {
                    isSigned = savedCached.IsDigitalSigned(password);
                }
                else if (savedImage is RasterCachedMultipageImage savedMulti)
                {
                    isSigned = savedMulti.IsDigitalSigned(password);
                }

                Console.WriteLine($"Signature valid: {isSigned}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}