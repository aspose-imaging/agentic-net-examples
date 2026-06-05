using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded paths
            string originalPath = "original.bmp";
            string signedPath = "signed.bmp";
            string password = "Secure123";

            // Create a simple BMP image (100x100, 24bpp)
            int width = 100;
            int height = 100;
            var bmpCreateOptions = new BmpOptions
            {
                BitsPerPixel = 24
            };
            using (var image = (RasterImage)Image.Create(bmpCreateOptions, width, height))
            {
                // Fill with a solid color (e.g., light gray)
                image.Save(originalPath);
            }

            // Ensure the original file exists before loading
            if (!File.Exists(originalPath))
            {
                Console.Error.WriteLine($"File not found: {originalPath}");
                return;
            }

            // Load the original image, embed digital signature, and save as signed image
            using (var image = (RasterImage)Image.Load(originalPath))
            {
                image.EmbedDigitalSignature(password);
                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(signedPath) ?? string.Empty);
                image.Save(signedPath);
            }

            // Verify the digital signature on the signed image
            if (!File.Exists(signedPath))
            {
                Console.Error.WriteLine($"File not found: {signedPath}");
                return;
            }

            using (var signedImage = (RasterImage)Image.Load(signedPath))
            {
                bool isSigned = signedImage.IsDigitalSigned(password);
                Console.WriteLine(isSigned
                    ? "The image is digitally signed and verification succeeded."
                    : "The image is NOT digitally signed or verification failed.");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}