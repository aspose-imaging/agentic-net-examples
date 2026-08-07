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
            // Define output path (ensure it includes a directory)
            string outputPath = "output\\signed.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a BMP image of size 200x200 (minimum for digital signature)
            using (BmpImage bmpImage = new BmpImage(200, 200))
            {
                // Fill the image with a simple gradient
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

                // Embed digital signature with password "Secure123"
                bmpImage.EmbedDigitalSignature("Secure123");

                // Verify the signature using the same password
                bool isSigned = bmpImage.IsDigitalSigned("Secure123");
                Console.WriteLine($"Digital signature embedded: {isSigned}");

                // Save the signed BMP image
                bmpImage.Save(outputPath);
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
 * 1. When a developer needs to generate a BMP thumbnail for a document management system and ensure its authenticity by embedding a password‑protected digital signature using Aspose.Imaging for .NET.
 * 2. When a C# application must create a simple gradient BMP image for a UI preview and protect it against tampering by adding and later verifying a digital signature with a known password.
 * 3. When an automated reporting tool has to produce BMP charts that can be validated later by auditors, embedding a secure signature with the password “Secure123” and checking it before distribution.
 * 4. When a software solution stores BMP icons in a shared folder and wants to guarantee that only authorized users can confirm the image’s integrity by verifying the embedded digital signature in C#.
 * 5. When a developer is building a compliance‑focused image processing pipeline that creates BMP files, embeds a password‑protected digital signature, and programmatically verifies the signature before archiving the files.
 */