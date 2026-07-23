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
            // Hardcoded input and output file paths
            string inputPath = "input.jpg";
            string outputPath = "output_signed.jpg";

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
                // Cast to RasterImage for digital signature operations
                RasterImage raster = (RasterImage)image;

                // Embed a digital signature using a password longer than four characters
                string validPassword = "secure123";
                raster.EmbedDigitalSignature(validPassword);

                // Confirm that the signature was embedded successfully
                bool isSigned = raster.IsDigitalSigned(validPassword);
                Console.WriteLine($"Signature embedded: {isSigned}");

                // Prepare save options with a bound file source
                Source source = new FileCreateSource(outputPath, false);
                JpegOptions options = new JpegOptions { Source = source, Quality = 100 };

                // Save the signed image
                raster.Save(outputPath, options);
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
 * 1. When a developer needs to embed a tamper‑detectable digital signature into a JPEG photo before sending it to a client, ensuring the signature is protected with a password longer than four characters.
 * 2. When an e‑commerce platform wants to sign product images to verify authenticity during download, using Aspose.Imaging’s RasterImage.EmbedDigitalSignature method with a secure password.
 * 3. When a medical imaging system must attach a password‑protected digital signature to scanned patient images (e.g., JPEG) to comply with data integrity regulations.
 * 4. When a document management workflow requires programmatically signing and later validating image attachments in C# before archiving them in a secure repository.
 * 5. When a mobile app backend processes user‑uploaded pictures and needs to embed and confirm a digital signature using a strong password to prevent unauthorized modifications.
 */