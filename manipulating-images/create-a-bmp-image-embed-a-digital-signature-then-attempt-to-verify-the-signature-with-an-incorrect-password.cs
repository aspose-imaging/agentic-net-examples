using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define paths
            string outputDir = "output";
            string signedPath = Path.Combine(outputDir, "signed.bmp");

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(signedPath));

            // Create a BMP image, fill with gradient, embed digital signature, and save
            using (BmpImage bmpImage = new BmpImage(200, 200))
            {
                int width = bmpImage.Width;
                int height = bmpImage.Height;
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        int hue = (255 * x) / width;
                        bmpImage.SetPixel(x, y, Color.FromArgb(255, hue, 0, 0));
                    }
                }

                // Embed digital signature with a valid password
                try
                {
                    bmpImage.EmbedDigitalSignature("secure123");
                }
                catch (Aspose.Imaging.CoreExceptions.ImageException ex)
                {
                    Console.Error.WriteLine($"Error embedding signature: {ex.Message}");
                }

                // Save the signed image
                bmpImage.Save(signedPath);
            }

            // Verify the signature with an incorrect password
            if (!File.Exists(signedPath))
            {
                Console.Error.WriteLine($"File not found: {signedPath}");
                return;
            }

            using (Image loadedImage = Image.Load(signedPath))
            {
                RasterImage raster = (RasterImage)loadedImage;
                bool isSigned = raster.IsDigitalSigned("123");
                Console.WriteLine($"Is image digitally signed with incorrect password? {isSigned}");
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
 * 1. When a developer needs to generate a BMP file with a custom gradient and protect it with a password‑protected digital signature to ensure authenticity.
 * 2. When an application must embed a digital signature into an image file (e.g., BMP) and later verify that the signature cannot be validated with an incorrect password, demonstrating tamper detection.
 * 3. When building a document‑management system that stores scanned BMP images and requires signing them programmatically using Aspose.Imaging for .NET to prevent unauthorized modifications.
 * 4. When creating a test suite for image‑security features that programmatically creates a BMP, signs it, and confirms that verification fails with a wrong password, ensuring robust error handling.
 * 5. When integrating image processing workflows that need to programmatically generate BMP graphics, embed a secure digital signature, and validate the signature handling logic for compliance or audit purposes.
 */