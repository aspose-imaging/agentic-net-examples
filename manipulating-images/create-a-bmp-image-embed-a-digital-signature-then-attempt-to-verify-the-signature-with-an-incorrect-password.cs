// HOW-TO: Create BMP Image, Embed Digital Signature and Test Wrong Password in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "images/original.bmp";
        string signedPath = "images/signed.bmp";

        try
        {
            // Ensure output directory for the original image
            Directory.CreateDirectory(Path.GetDirectoryName(inputPath));

            // Create a BMP image (minimum 200x200)
            int width = 200;
            int height = 200;
            var createSource = new FileCreateSource(inputPath, false);
            var createOptions = new BmpOptions { Source = createSource };
            using (BmpImage bmpImage = (BmpImage)Aspose.Imaging.Image.Create(createOptions, width, height))
            {
                // Fill with a simple gradient
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        int hue = (255 * x) / width;
                        bmpImage.SetPixel(x, y, Aspose.Imaging.Color.FromArgb(255, hue, 0, 0));
                    }
                }
                // Save the created image (bound to the source)
                bmpImage.Save();
            }

            // Verify the created image exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the image and embed a digital signature with a valid password
            using (Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
            {
                raster.EmbedDigitalSignature("secure123");

                // Ensure output directory for the signed image
                Directory.CreateDirectory(Path.GetDirectoryName(signedPath));

                var signedSource = new FileCreateSource(signedPath, false);
                var signedOptions = new BmpOptions { Source = signedSource };
                raster.Save(signedPath, signedOptions);
            }

            // Verify the signed image exists
            if (!File.Exists(signedPath))
            {
                Console.Error.WriteLine($"File not found: {signedPath}");
                return;
            }

            // Load the signed image and attempt verification with an incorrect password
            using (Aspose.Imaging.RasterImage signedRaster = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(signedPath))
            {
                bool isSigned = signedRaster.IsDigitalSigned("123");
                Console.WriteLine($"Signature verification with incorrect password: {isSigned}");
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
 * 1. When you need to generate a BMP file programmatically and protect it with a password‑protected digital signature before distribution.
 * 2. When you want to embed a secure digital signature into an existing bitmap to ensure its authenticity in a .NET application.
 * 3. When you need to demonstrate how a verification routine fails when an incorrect password is supplied for a signed image.
 * 4. When building a workflow that creates placeholder images, signs them, and validates the signature as part of a quality‑assurance process.
 * 5. When integrating Aspose.Imaging into a C# service that must create, sign, and test image integrity for compliance or audit purposes.
 */
