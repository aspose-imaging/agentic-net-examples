using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.CoreExceptions;

class Program
{
    // Checks if the image at inputPath is digitally signed.
    // If not, embeds a digital signature using the provided password and saves to outputPath.
    static void CheckAndEmbedSignature(string inputPath, string outputPath, string password)
    {
        // Load the image (supports raster, cached, and multipage images)
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access digital signature methods
            RasterImage rasterImage = image as RasterImage;
            if (rasterImage == null)
            {
                Console.Error.WriteLine("Unsupported image format for digital signature.");
                return;
            }

            // Fast check whether the image is already signed
            bool isSigned = rasterImage.IsDigitalSigned(password);
            if (isSigned)
            {
                Console.WriteLine("Image is already digitally signed. No action taken.");
            }
            else
            {
                // Embed the digital signature
                rasterImage.EmbedDigitalSignature(password);
                Console.WriteLine("Digital signature embedded.");
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Save the (potentially modified) image
            rasterImage.Save(outputPath);
        }
    }

    static void Main()
    {
        // Hardcoded paths (modify as needed)
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output.png";
        string password = "mySecretPassword";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            CheckAndEmbedSignature(inputPath, outputPath, password);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a healthcare application needs to verify that a DICOM image hasn't been tampered with before adding a new digital signature for audit compliance.
 * 2. When a document management system processes PNG or JPEG files and must ensure they are unsigned before embedding a password‑protected signature to guarantee authenticity.
 * 3. When a batch image conversion tool loads cached or multipage TIFF files and checks for existing signatures to avoid duplicate signing and preserve file integrity.
 * 4. When a secure photo‑sharing service validates that uploaded images are not already signed before applying its own digital signature to enforce ownership rights.
 * 5. When a regulatory reporting solution programmatically loads raster images, checks for a digital signature using a password, and only embeds a new signature if none is present to meet legal signing requirements.
 */