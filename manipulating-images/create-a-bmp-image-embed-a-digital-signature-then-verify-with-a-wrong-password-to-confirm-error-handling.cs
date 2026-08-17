// HOW-TO: Create BMP Image, Embed Digital Signature, and Test Wrong Password in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output\\signed.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a BMP image 200x200 pixels
            using (var bmp = new BmpImage(200, 200))
            {
                int width = bmp.Width;
                int height = bmp.Height;
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        int hue = (255 * x) / width;
                        bmp.SetPixel(x, y, Aspose.Imaging.Color.FromArgb(255, hue, 0, 0));
                    }
                }

                // Embed digital signature with a valid password
                bmp.EmbedDigitalSignature("secure123");

                // Save the signed image
                bmp.Save(outputPath);
            }

            // Load the saved image and attempt to embed with an invalid password
            using (var img = Aspose.Imaging.Image.Load(outputPath))
            {
                var raster = (Aspose.Imaging.RasterImage)img;
                try
                {
                    raster.EmbedDigitalSignature("123");
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
 * 1. When you need to generate a BMP file programmatically and protect it with a password‑protected digital signature.
 * 2. When you want to ensure that a signed image cannot be altered without the correct password.
 * 3. When you need to demonstrate error handling by attempting to embed a signature using an incorrect password.
 * 4. When you are building a workflow that creates custom graphics and secures them for compliance or authenticity.
 * 5. When you are testing Aspose.Imaging’s digital signature API to verify that invalid passwords raise the expected exception.
 */
