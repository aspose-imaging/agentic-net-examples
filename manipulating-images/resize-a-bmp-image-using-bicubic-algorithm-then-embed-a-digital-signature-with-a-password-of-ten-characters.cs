// HOW-TO: Resize BMP Image With Bicubic Algorithm And Add Password Protected Signature In C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.bmp";
            string outputPath = "output.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (BmpImage image = (BmpImage)Image.Load(inputPath))
            {
                // Resize using Bicubic (CubicConvolution) algorithm
                int newWidth = image.Width / 2;
                int newHeight = image.Height / 2;
                image.Resize(newWidth, newHeight, ResizeType.CubicConvolution);

                // Embed digital signature with a 10-character password
                string password = "Passw0rd12";
                image.EmbedDigitalSignature(password);

                // Save the processed image
                BmpOptions options = new BmpOptions();
                image.Save(outputPath, options);
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
 * 1. When a developer needs to shrink a large BMP file for faster web loading while preserving quality using the bicubic (cubic convolution) resize method.
 * 2. When a developer wants to embed a digital signature into a BMP to verify authenticity and protect it with a ten‑character password.
 * 3. When a legacy application requires BMP assets at half size and signed to prevent tampering before distribution.
 * 4. When a batch processing tool must resize multiple BMPs and secure each with a simple password‑based signature for compliance.
 * 5. When an image‑processing pipeline needs to combine high‑quality scaling and cryptographic signing in a single C# routine.
 */
