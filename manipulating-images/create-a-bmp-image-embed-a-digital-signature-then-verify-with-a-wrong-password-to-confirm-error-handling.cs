using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define output path
            string outputPath = "output.bmp";

            // Create a BMP image 100x100 pixels
            using (var bmpImage = new BmpImage(100, 100))
            {
                // Fill with a simple red gradient
                for (int y = 0; y < bmpImage.Height; y++)
                {
                    for (int x = 0; x < bmpImage.Width; x++)
                    {
                        int hue = (255 * x) / bmpImage.Width;
                        bmpImage.SetPixel(x, y, Color.FromArgb(255, hue, 0, 0));
                    }
                }

                // Embed digital signature with a valid password
                string validPassword = "secure123";
                bmpImage.EmbedDigitalSignature(validPassword);

                // Ensure output directory exists
                string outDir = Path.GetDirectoryName(outputPath);
                if (!string.IsNullOrEmpty(outDir))
                    Directory.CreateDirectory(outDir);

                // Save the BMP image
                bmpImage.Save(outputPath);
            }

            // Verify the file exists
            if (!File.Exists(outputPath))
            {
                Console.Error.WriteLine($"File not found: {outputPath}");
                return;
            }

            // Load the saved image
            using (var loadedImage = Image.Load(outputPath))
            {
                var raster = (RasterImage)loadedImage;

                // Attempt to embed with an invalid password to trigger error handling
                try
                {
                    raster.EmbedDigitalSignature("123");
                }
                catch (Aspose.Imaging.CoreExceptions.ImageException ex)
                {
                    Console.WriteLine($"HANDLED: {ex.Message}");
                }

                // Check signature with wrong password
                bool isSignedWrong = raster.IsDigitalSigned("123");
                Console.WriteLine($"Is signed with wrong password: {isSignedWrong}");

                // Check signature with correct password
                bool isSignedCorrect = raster.IsDigitalSigned("secure123");
                Console.WriteLine($"Is signed with correct password: {isSignedCorrect}");
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
 * 1. When a developer needs to generate a BMP thumbnail for a document and protect it with a digital signature to ensure authenticity.
 * 2. When an application must embed a secure hash into a BMP image for tamper‑evidence and later verify that the signature cannot be altered with an incorrect password.
 * 3. When building a workflow that creates custom gradient BMP graphics for branding and requires password‑protected signing to comply with corporate security policies.
 * 4. When testing the error‑handling path of Aspose.Imaging’s EmbedDigitalSignature method by intentionally using a wrong password after saving the image.
 * 5. When integrating BMP image generation into a C# service that stores signed images on disk and needs to confirm that loading the file and re‑signing with an invalid password throws a predictable ImageException.
 */