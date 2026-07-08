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
            // Define paths
            string outputDir = "output";
            string bmpPath = Path.Combine(outputDir, "original.bmp");
            string signedPath = Path.Combine(outputDir, "signed.bmp");

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(bmpPath));
            Directory.CreateDirectory(Path.GetDirectoryName(signedPath));

            // Create a BMP image (200x200)
            int width = 200;
            int height = 200;
            using (BmpImage bmpImage = new BmpImage(width, height))
            {
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        int hue = (255 * x) / width;
                        bmpImage.SetPixel(x, y, Aspose.Imaging.Color.FromArgb(255, hue, 0, 0));
                    }
                }
                bmpImage.Save(bmpPath);
            }

            // Verify the created image exists before loading
            if (!File.Exists(bmpPath))
            {
                Console.Error.WriteLine($"File not found: {bmpPath}");
                return;
            }

            // Embed a digital signature with a valid password
            string validPassword = "secure123";
            using (Image img = Image.Load(bmpPath))
            {
                RasterImage raster = (RasterImage)img;
                raster.EmbedDigitalSignature(validPassword);
                raster.Save(signedPath);
            }

            // Verify the signed image exists before loading
            if (!File.Exists(signedPath))
            {
                Console.Error.WriteLine($"File not found: {signedPath}");
                return;
            }

            // Attempt to embed with an invalid password and handle the expected exception
            using (Image img2 = Image.Load(signedPath))
            {
                RasterImage raster2 = (RasterImage)img2;
                try
                {
                    raster2.EmbedDigitalSignature("123");
                }
                catch (Aspose.Imaging.CoreExceptions.ImageException ex)
                {
                    Console.WriteLine($"HANDLED: {ex.Message}");
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
 * 1. When a developer needs to generate a BMP thumbnail for a document management system and protect it with a digital signature to ensure authenticity.
 * 2. When an application must embed a cryptographic signature into a raster image using Aspose.Imaging for .NET to comply with regulatory audit trails.
 * 3. When a software solution creates a custom BMP graphic, signs it with a password, and later validates that an incorrect password triggers a controlled exception for robust error handling.
 * 4. When a C# program automates the creation of color‑gradient BMP files and secures them with a password‑protected digital signature before distributing them to external partners.
 * 5. When a developer wants to test the failure path of the EmbedDigitalSignature method by intentionally using a wrong password to confirm that the library returns the expected error response.
 */