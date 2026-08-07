using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hard‑coded paths
        string inputPath = "input.jpg";
        string outputPath = "output/signed.jpg";
        string password = "mySecretPassword";

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

            // Load JPEG from a file stream
            using (FileStream fs = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
            using (RasterImage image = (RasterImage)Image.Load(fs))
            {
                // Embed digital signature using the provided password
                image.EmbedDigitalSignature(password);

                // Save the signed image
                image.Save(outputPath);

                // Verify that the image is digitally signed
                bool isSigned = image.IsDigitalSigned(password);
                Console.WriteLine($"Is image digitally signed? {isSigned}");
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
 * 1. When a web application needs to securely embed a password‑protected digital signature into user‑uploaded JPEG photos before storing them in a cloud repository.
 * 2. When a desktop utility must read a JPEG from a file stream, sign it with a secret key, and verify the signature to ensure image integrity for legal documentation.
 * 3. When an automated batch process has to add a tamper‑evident digital signature to marketing JPEG assets and confirm the signature before publishing them to a CDN.
 * 4. When a mobile backend service processes incoming JPEG images, embeds a password‑protected signature for copyright protection, and validates the signature before sending the image to clients.
 * 5. When a compliance‑focused system needs to load a JPEG via a stream, apply a digital signature using Aspose.Imaging, save the signed file, and programmatically check that the signature matches the provided password.
 */