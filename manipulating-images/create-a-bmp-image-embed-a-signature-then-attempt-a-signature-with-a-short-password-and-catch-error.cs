// HOW-TO: Embed Digital Signature in BMP Image with Password Validation in C# (Aspose.Imaging for .NET)
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
            string inputImagePath = "input.jpg";
            string outputImagePath = "output.bmp";

            if (!File.Exists(inputImagePath))
            {
                Console.Error.WriteLine($"File not found: {inputImagePath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputImagePath));

            using (RasterImage image = (RasterImage)Image.Load(inputImagePath))
            {
                string validPassword = "StrongPass";
                image.EmbedDigitalSignature(validPassword);

                Source outSource = new FileCreateSource(outputImagePath, false);
                BmpOptions bmpOptions = new BmpOptions() { Source = outSource };
                image.Save(outputImagePath, bmpOptions);
            }

            using (RasterImage image2 = (RasterImage)Image.Load(inputImagePath))
            {
                string shortPassword = "abc";
                try
                {
                    image2.EmbedDigitalSignature(shortPassword);
                    Console.WriteLine("Embedded with short password (unexpected).");
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"Error embedding with short password: {ex.Message}");
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
 * 1. When you need to protect a BMP image by embedding a digital signature using a strong password before distribution.
 * 2. When converting a JPEG file to BMP format while ensuring the output file includes a tamper‑detectable signature.
 * 3. When you want to verify that a password meets the minimum length required for embedding a digital signature in an image.
 * 4. When handling image processing errors, such as missing source files or invalid signature passwords, in a C# application.
 * 5. When you need to programmatically create a BMP file, embed security metadata, and gracefully handle failures during the signing process.
 */
